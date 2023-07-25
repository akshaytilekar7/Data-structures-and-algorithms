namespace MergeSort
{

    /*
    1   closed interval 
    2   Open interval 
    3   Semi open
            [nl n2] nEN :  n1 <= N <= n2
            (n1 n2) nEN :  n1 <  N < n2
            [n1 n2) nEN :  n1 <= N < n2
            (n1 n2] nEN :  n1 <  N <= n2
    
            length (a b] => b - a
            length [a b) => b - a
            length [a b] => b - a + 1
            length (a b) => b - a - 1

    merge - divide until single element
                
    */
    public class MergeSort
    {
        public void Sort(int[] array)
        {
            Merge(array, 0, array.Length - 1);
        }

        private void Merge(int[] arr, int start, int end)
        {
            if (start < end) // NO SORTING REQUIRE FOR SINGLE ELEMENT
            {
                int mid = (start + end) / 2;
                Merge(arr, start, mid); // divide
                Merge(arr, mid + 1, end); // divide
                MergeProcedure(arr, start, mid, end); // Merge divide element array
            }
            //else
            //{
            //    Console.WriteLine($" ELSE {start}  {end}");
            //}
        }

        private void MergeProcedure(int[] mainArr, int start, int mid, int end)
        {
            int i, j, k;

            int size1 = mid - start + 1; // IMP // include start to min
            int size2 = end - mid; // IMP  // from mid + 1 to end

            int[] arr1 = new int[size1];
            int[] arr2 = new int[size2];

            for (i = 0; i < size1; i++)
                arr1[i] = mainArr[start + i];

            for (i = 0; i < size2; i++)
                arr2[i] = mainArr[mid + 1 + i]; // IMP

            i = 0;
            j = 0;
            k = start;

            while (true) // IMP
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
