namespace SelectionSort
{
    public class SelectionSort
    {
        public void SelectionSortAlgo(int[] array)
        {
            for (int i = 0; i < array.Length ; i++)
            {
                for (int j = i + 1; j < array.Length ; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}
