namespace BucketRadixSort
{
    public static class Client
    {
        public static void Main()
        {
            BucketRadixSort sort = new BucketRadixSort();
            int[] arr1 = { 1, 1, 2, 2, 2, 6, 6, 10, 15, 2 };
            sort.Sort(arr1);
            sort.Print(arr1);
        }
    }
}
