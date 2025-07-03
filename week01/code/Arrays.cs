public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Solution Steps:
        // 1. Create an array of doubles with the specified length.
        // 2. Use a loop to iterate from 0 to length - 1.
        // 3. In each iteration, calculate the multiple of 'number' by multiplying it
        //    by the current index + 1 (to start from 1).
        // 4. Assign the calculated value to the corresponding index in the array.
        double[] multiples = new double[length];
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }
        return multiples;

    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Solution Steps:
        // 1. Calculate the effective rotation amount by taking the modulus of the amount with the      
        //    data.Count to handle cases where amount is greater than the list size.
        // 2. If the effective amount is 0, return early as no rotation is needed.
        // 3. Split the list into two parts: the last 'amount' elements and the rest of the list.
        // 4. Concatenate the two parts in reverse order to achieve the right rotation. 
        int effectiveAmount = amount % data.Count;
        if (effectiveAmount == 0)
        {
            return; // No rotation if effective amount is 0
        }
        List<int> rotatedPart = data.GetRange(data.Count - effectiveAmount, effectiveAmount);
        List<int> remainingPart = data.GetRange(0, data.Count - effectiveAmount);
        data.Clear(); // Clearing the original list
        data.AddRange(rotatedPart); // Adding the rotated part first
        data.AddRange(remainingPart); // Adding the remaining part after
    }
}


