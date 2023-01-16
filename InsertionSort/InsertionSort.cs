namespace InsertionSort
{
    public class InsertionSort
    {
        public void InsertionSort1(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int pivot = array[i];
                int j = i - 1;
                while (j > 0 && array[j] > pivot)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = pivot;
            }
        }

        public void Print(int[] array)
        {
            Console.WriteLine();
            foreach (var item in array)
                Console.Write(" [{0}] ", item);
            Console.WriteLine();
        }

    }
}
