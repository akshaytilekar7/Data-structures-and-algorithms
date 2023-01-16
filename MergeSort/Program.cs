namespace MergeSort
{
    public static class Client
    {
        public static void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Zip zip = new Zip();


            foreach (var item in arr)
                Console.Write(" [{0}] ", item);

            Console.WriteLine();
            zip.ZipArray(arr);

            foreach (var item in arr)
                Console.Write(" [{0}] ", item);
        }
    }
}
