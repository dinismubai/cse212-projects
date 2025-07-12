using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities and remove them
    // Expected Result: Items with highest priority are removed first
    // Defect(s) Found: DMM - Fixed Dequeue to consider all items and remove the correct one
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items with the same highest priority
    // Expected Result: The one added first among ties is removed first (FIFO)
    // Defect(s) Found: DMM - Loop logic updated to preserve FIFO tie-breaking
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 4);

        Assert.AreEqual("A", priorityQueue.Dequeue()); // Same priority, FIFO
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to Dequeue from an empty queue
    // Expected Result: Throws InvalidOperationException
    // Defect(s) Found: None
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Add many elements, ensure order still based on highest priority
    // Expected Result: Highest-priority element always dequeued first
    // Defect(s) Found: None
    public void TestPriorityQueue_MultipleItems()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("X", 1);
        priorityQueue.Enqueue("Y", 10);
        priorityQueue.Enqueue("Z", 5);
        priorityQueue.Enqueue("W", 10); // Same as Y

        Assert.AreEqual("Y", priorityQueue.Dequeue());
        Assert.AreEqual("W", priorityQueue.Dequeue());
        Assert.AreEqual("Z", priorityQueue.Dequeue());
        Assert.AreEqual("X", priorityQueue.Dequeue());
    }
}
