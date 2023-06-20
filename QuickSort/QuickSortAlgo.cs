namespace QuickSort
{
    public class QuickSortAlgo
    {
        public void Sort(int[] array)
        {
            QuickSorting(array, 0, array.Length - 1);
        }

        public void Print(int[] array)
        {
            Console.WriteLine();
            foreach (var item in array)
                Console.Write(" [{0}] ", item);
            Console.WriteLine();

        }
        private void Swap(int[] arr, int x, int y)
        {
            int tmp = arr[x];
            arr[x] = arr[y];
            arr[y] = tmp;
        }

        private int Partition(int[] arr, int start, int end)
        {
            int pivot = arr[end];
            int partitionIndex = start;

            for (int i = start; i < end; i++)
            {
                if (arr[i] <= pivot)
                {
                    Swap(arr, i, partitionIndex);
                    partitionIndex++;
                }
            }

            Swap(arr, partitionIndex, end);
            return partitionIndex;
        }

        private void QuickSorting(int[] arr, int start, int end)
        {
            if (start < end) // main
            {
                int partitionIndex = Partition(arr, start, end);
                QuickSorting(arr, start, partitionIndex - 1);
                QuickSorting(arr, partitionIndex + 1, end);
            }
        }

    }
}
