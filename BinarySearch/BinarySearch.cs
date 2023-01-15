namespace BinarySearch
{
    public class BinarySearch
    {
        public int BinarySearchIterative(int[] array, int value)
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

        public int BinarySearchRecursive(int[] array, int value)
        {
            return BinarySearchRecursive(array, value, 0, array.Length - 1);
        }
        private int BinarySearchRecursive(int[] array, int value, int start, int end)
        {
            if (start > end)
                return -1;

            int midIndex = (start + end) / 2;

            if (value == array[midIndex])
                return midIndex;
            else if (value < array[midIndex])
                return BinarySearchRecursive(array, value, start, midIndex - 1);
            else
                return BinarySearchRecursive(array, value, midIndex + 1, end);
        }
    }
}
