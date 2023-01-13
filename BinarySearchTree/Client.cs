namespace BinarySearchTree
{
    public static class Client
    {
        public static void Main()
        {
            BstService tree = new BstService();

            int[] arr1 = { 20, 8, 22, 4, 12, 10, 14, 25, 23 };

            for (int i = 0; i < arr1.Length; i++)
                tree.Insert(arr1[i]);

            tree.Inorder();

            Console.WriteLine(tree.IsExist(0));
            Console.WriteLine(tree.IsExist(100));

            tree.BFS();
            tree.LevelOrderTraverser();


        }
    }
}
