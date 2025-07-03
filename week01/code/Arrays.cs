public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // THE PLAN:
        // Step 1: Create a new array of doubles with the size of 'length'
        // Step 2: Use a for loop to fill the array
        // Step 3: On each iteration i (from 0 to length-1), store (number * (i + 1)) in the array
        // Step 4: Return the filled array

        // Step 1
        double[] result = new double[length];

        // Step 2
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1); // Step 3
        }

        return result; // Step 4
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is {1, 2, 3, 4, 5, 6, 7, 8, 9} and amount is 3, 
    /// the result should be {7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        //  THE PLAN:
        // Step 1: Get the last 'amount' of items from the list using GetRange
        // Step 2: Get the remaining elements from the start up to data.Count - amount
        // Step 3: Clear the original list
        // Step 4: Add the 'last' part first (which becomes the new front)
        // Step 5: Then add the remaining 'first' part to complete the rotated list

        // Step 1
        List<int> lastPart = data.GetRange(data.Count - amount, amount);

        // Step 2
        List<int> firstPart = data.GetRange(0, data.Count - amount);

        // Step 3
        data.Clear();

        // Step 4
        data.AddRange(lastPart);

        // Step 5
        data.AddRange(firstPart);
    }
}
