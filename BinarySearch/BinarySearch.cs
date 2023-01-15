﻿namespace BinarySearch
{
    public class BinarySearch
    {
        public int Search(int[] array, int value)
        {
            int start = 0;
            int end = array.Length - 1;
            while (start <= end)
            {
                int midIndex = (start + end) / 2;
                if (value == array[midIndex])
                    return midIndex;
                else if (value < array[midIndex])
                    end = midIndex - 1;
                else
                    start = midIndex + 1;
            }
            return -1;
        }

        public int SearchRecursive(int[] array, int value)
        {
            return SearchRecursive(array, value, 0, array.Length - 1);
        }
        private int SearchRecursive(int[] array, int value, int start, int end)
        {
            if (start > end)
                return -1;

            int midIndex = (start + end) / 2;

            if (value == array[midIndex])
                return midIndex;
            else if (value < array[midIndex])
                return SearchRecursive(array, value, start, midIndex - 1);
            else
                return SearchRecursive(array, value, midIndex + 1, end);
        }
    }
}
