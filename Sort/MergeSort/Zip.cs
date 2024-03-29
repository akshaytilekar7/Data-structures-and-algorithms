﻿namespace MergeSort
{
    //  [a, b] = b - a + 1
    //	(a, b) = b - a - 1
    //	(a, b] = b - a
    //	[a, b) = b - a
    public class Zip
    {
        public void ZipArray(int[] mainArray)
        {
            int length = mainArray.Length;

            int mid = length / 2;
            int[] array1 = new int[mid - 1 + 1];
            int[] array2 = new int[length - mid];
            int j = 0, k = 0;
            int i;
            for (i = 0; i < array1.Length; i++)
                array1[i] = mainArray[i];

            for (i = 0; i < array2.Length; i++)
                array2[i] = mainArray[i + length - mid];
            i = 0;
            while (true)
            {
                if (k % 2 == 0)
                {
                    mainArray[k++] = array1[i++];
                    if (i == array1.Length)
                    {
                        while (j < array2.Length)
                            mainArray[k++] = array2[j++];
                        break;
                    }
                }
                else
                {
                    mainArray[k++] = array2[j++];
                    if (j == array2.Length)
                    {
                        while (i < array1.Length)
                            mainArray[k++] = array1[i++];
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
