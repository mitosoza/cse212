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
        // create an empty array of doubles of size length
        // start with the number and create a loop that multiplies the number by the loop index
        // store each result in the array and return the array
        double[] multiplesList = new double[length];
        for (int i = 0; i < length; i++)
        {
            multiplesList[i] = number * (i + 1);
        }
        return multiplesList;
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
        // create a list1 and add the values in data
        // create a list2 and add the values in list1 starting at the index of data.Count - amount to the end of list1
        // remove the values added to list2 from list1
        // add the remaining values in list1 to list2

        var list1 = new List<int>(data);
            var list2 = new List<int>();

        for (int i = data.Count - amount; i < list1.Count; i++)
        {
            list2.Add(list1[i]);
        }

        list1.RemoveRange(data.Count - amount, amount);
        list2.AddRange(list1);

        data.Clear();
        data.AddRange(list2);
    }
}
