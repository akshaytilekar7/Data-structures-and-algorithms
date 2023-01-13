namespace BinarySearchTree
{
    public static class Client
    {
        public static void Main()
        {
            BstService tree = new BstService();

            int[] arr = { 20, 8, 22, 4, 12, 10, 14, 25, 23, 540, 0, 123, 5464, -98 };

            for (int i = 0; i < arr.Length; i++)
                tree.Insert(arr[i]);

            tree.Inorder();

            //Console.WriteLine(tree.IsExist(0));
            //Console.WriteLine(tree.IsExist(100));
            //tree.BFS();
            //tree.LevelOrderTraverser();

            Random r = new Random();
            arr = arr.OrderBy(x => r.Next()).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                tree.Delete(arr[i]);
                tree.Inorder("after delete " + arr[i]);
                Console.WriteLine();
            }

            tree.Inorder("FINAL");
        }
    }
}
