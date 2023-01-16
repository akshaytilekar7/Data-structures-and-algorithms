namespace SelectionSort
{
    public class SelectionSort
    {
        // https://www.youtube.com/watch?v=9oWd4VJOwr0
        // 1 FIND MIN FROM UNSORTED ARRAY AND
        // 2 SWAP WITH START OF UNSORTED ARRAY 
        public void SelectionSortAlgo(int[] array)
        {
            // required n - 1 pass as last one element is no need to sort
            for (int i = 0; i < array.Length - 1; i++) 
            {
                // FIND MIN FROM UNSORTED ARRAY AND
                int maxEndIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                    if (array[j] < array[maxEndIndex])
                        maxEndIndex = j;

                // SWAP WITH START OF UNSORTED ARRAY 
                if (maxEndIndex != i)
                {
                    int temp = array[maxEndIndex];
                    array[maxEndIndex] = array[i];
                    array[i] = temp;
                }
            }
        }
    }
}
