namespace MergeSort
{
    public class MergeSort
    {
        public void Sort(int[] array)
        {
            Merge(array, 0, array.Length - 1);
        }

        private void Merge(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;
                Merge(arr, start, mid);
                Merge(arr, mid + 1, end);
                MergeProcedure(arr, start, mid, end);
            }
        }

        private void MergeProcedure(int[] mainArr, int start, int mid, int end)
        {
            int i, j, k;

            int size1 = mid - start + 1;
            int size2 = end - mid;

            int[] arr1 = new int[size1];
            int[] arr2 = new int[size2];

            for (i = 0; i < size1; i++)
                arr1[i] = mainArr[start + i];

            for (i = 0; i < size2; i++)
                arr2[i] = mainArr[mid + 1 + i];

            i = 0;
            j = 0;
            k = start;

            while (true)
            {
                if (arr1[i] <= arr2[j])
                {
                    mainArr[k++] = arr1[i++];
                    if (i == size1)
                    {
                        while (j < size2)
                            mainArr[k++] = arr2[j++];
                        break;
                    }
                }
                else
                {
                    mainArr[k++] = arr2[j++];
                    if (j == size2)
                    {
                        while (i < size1)
                            mainArr[k++] = arr1[i++];
                        break;
                    }
                }
            }
        }

        public void Print(int[] arr)
        {
            Console.WriteLine();
            foreach (var item in arr)
                Console.Write(" [{0}] ", item);
            Console.WriteLine();
        }
    }
}
