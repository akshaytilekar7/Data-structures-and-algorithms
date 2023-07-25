namespace QuickSort
{
    /*
        -   work on postioning, in each iteration one element places at exact rigth postion
            then again same process is apply for partition : left side and right side

        -   working
            select any element and placed into correct postion
            so we called ->  int partitionIndex = Partition(arr, start, end);
            which return partitionIndex means that index has correct value
            then we call remaing 2 sides -> left and right 
                QuickSorting(arr, start, partitionIndex - 1);  // -1
                QuickSorting(arr, partitionIndex + 1, end);   // +1

        -   In PartionMethod
            pivot -> as last element
            partiotionIndex -> as start element
                
            for loop from start to end and comapre pivot with each arr[i]
            if less SWAP arr[i] and partionIndex
            then partionIndex++

        -   at last swap arr[end] with arr[partionIndex]
                

    */
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
                QuickSorting(arr, start, partitionIndex - 1);  // -1
                QuickSorting(arr, partitionIndex + 1, end);   // +1
            }
        }

    }
}
