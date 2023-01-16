namespace BubbleSort
{
    public static class Client
    {
        public static void Main()
        {
            BubbleSort sort = new BubbleSort();
            int[] arr1 = { 980, 34, 64, 8, 2, 43, 94, 28, -98, 43, 2, 32, 100, 50, 165, 20, 46, 140, 145, 5, 35, -65, 500, 89, 14, 12, 12 };
            sort.BubbleSortAlgo1(arr1);
            sort.Print(arr1);

            int[] arr2 = { 980, 34, 64, 8, 2, 43, 94, 28, -98, 43, 2, 32, 100, 50, 165, 20, 46, 140, 145, 5, 35, -65, 500, 89, 14, 12, 12 };
            sort.BubbleSortAlgo2(arr2);
            sort.Print(arr2);

            int[] arr3 = { 980, 34, 64, 8, 2, 43, 94, 28, -98, 43, 2, 32, 100, 50, 165, 20, 46, 140, 145, 5, 35, -65, 500, 89, 14, 12, 12 };
            sort.BubbleSortAlgo3(arr3);
            sort.Print(arr3);


        }
    }
}
