namespace AvlTree
{
    public static class Client
    {
        public static void Main()
        {
            Console.WriteLine("AvlTree");

            AvlTreeService tree = new AvlTreeService();

            int[] arr = { 980, 34, 64, 8, 2, 43, 94, 28, -98, 43, 2, 32, 100, 50, 150, 40, 60, 30, 45, 55, 65, 20, 46, 140, 145, 5, 35, -65, 500, 89, 14, 12, 12 };

            for (int i = 0; i < arr.Length; i++)
                tree.Insert(arr[i]);

            Random r = new Random();
            arr = arr.OrderBy(x => r.Next()).ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                tree.Delete(arr[i]);
                tree.Inorder("After delete : " + arr[i]);
                Console.WriteLine("Height is : {0}", tree.GetHeight());
                Console.WriteLine();
            }

            Console.WriteLine("Height is : " + tree.GetHeight());
        }
    }
}
