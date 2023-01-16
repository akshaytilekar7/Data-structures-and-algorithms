namespace MergeSort
{
    public static class Client
    {
        public static void Main()
        {
            int[] arr = { 1, -98, 65, 64, -76, 43, 0, 54, 6, 6, 6, 6, 34, 34, 65, 123, 54, 98, 63, 21, 5, 9, 78, 4, 6, 2 };

            //Zip zip = new Zip();
            //zip.ZipArray(arr);

            MergeSort mergeSort = new MergeSort();
            mergeSort.Sort(arr);
            mergeSort.Print(arr);
        }
    }
}
