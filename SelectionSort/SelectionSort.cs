namespace SelectionSort
{
    public class SelectionSort
    {
        // https://www.youtube.com/watch?v=9oWd4VJOwr0
        public void SelectionSortAlgo(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)  // required n - 1 pass as last one element is no need to sort
            {
                int maxEndIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                    if (array[j] < array[maxEndIndex])
                        maxEndIndex = j;

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
