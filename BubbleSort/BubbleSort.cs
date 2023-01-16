namespace BubbleSort
{
    //https://www.youtube.com/watch?v=o4bAoo_gFBU
    public class BubbleSort
    {
        public void BubbleSortAlgo1(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1]) //////// IMP
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        public void BubbleSortAlgo2(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                // array.Length - 1 - i becuase for each iteration element is sort and correctly fixed at its position
                {
                    if (array[j] > array[j + 1]) //////// IMP
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        public void BubbleSortAlgo3(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                bool isSwapDone = false;
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1]) //////// IMP
                    {
                        isSwapDone = true;
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
                if (!isSwapDone) break;
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
