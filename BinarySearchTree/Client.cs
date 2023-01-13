namespace BinarySearchTree
{
    public static class Client
    {
        public static void Main()
        {
            BstService tree = new BstService();

            int[] arr1 = { 100, 150, 75, 200, 125, 85, 50, 65, 130, 129, 127, 128 };

            for (int i = 0; i < arr1.Length; i++)
                tree.Insert(arr1[i]);

            tree.Inorder();

            Console.WriteLine(tree.IsExist(0));
            Console.WriteLine(tree.IsExist(100));
            Console.WriteLine(tree.IsExist(128));
            Console.WriteLine(tree.IsExist(125));
            Console.WriteLine(tree.IsExist(-125));
        }
    }
}
