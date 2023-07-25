namespace BinarySearch
{
    public class BinarySearch
    {
        public int Search(int[] array, int value)
        {
            var start = 0;
            var end = array.Length - 1;

            while (start <= end)
            {
                var mid = (end + start) / 2;
                if (array[mid] == value)
                    return mid;

                if (value < array[mid])
                    end = mid - 1;
                else
                    start = mid + 1;
            }
            return -1;
        }
        public int SearchRecursive(int[] array, int value)
        {
            return SearchRecursive(array, value, 0, array.Length - 1);

        }
        private int SearchRecursive(int[] array, int value, int start, int end)
        {
            if (start <= end) // IMP  + <=
            {
                int mid = (end + start) / 2; // IMP  + 
                if (array[mid] == value)
                    return mid;
                if (value < array[mid])
                    SearchRecursive(array, value, start, mid - 1);
                else
                    SearchRecursive(array, value, mid + 1, end);
            }
            return -1;
        }
    }
}
