namespace SelectionSort
{
    public static class Client
    {
        public static void Main()
        {
            int[] arr = { 980, 34, 64, 8, 2, 43, 94, 28, -98, 43, 2, 32, 100, 50, 165, 20, 46, 140, 145, 5, 35, -65, 500, 89, 14, 12, 12 };
            BubbleSort sort = new BubbleSort();

            sort.BubbleSortAlgo(arr);

            foreach (var item in arr)
                Console.Write(" [{0}] ", item);
        }
    }
}
