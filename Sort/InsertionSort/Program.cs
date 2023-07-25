namespace InsertionSort
{
    public static class Client
    {
        public static void Main()
        {
            InsertionSort sort = new InsertionSort();
            int[] arr1 = { 980, 34, 64, 8, 2, 43, 94, 28, -98, 43, 2, 32, 100, 50, 165, 20, 46, 140, 145, 5, 35, -65, 500, 89, 14, 12, 12 };
            sort.InsertionSort1(arr1);
            sort.Print(arr1);
        }
    }
}
