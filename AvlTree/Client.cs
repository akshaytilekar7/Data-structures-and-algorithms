namespace AvlTree
{
    public static class Client
    {
        public static void Main()
        {
            Console.WriteLine("AvlTree");

            AvlTreeService avlTreeService = new AvlTreeService();

            int[] arr = { 100, 50, 150, 40, 60, 30, 45, 55, 65, 20, 46, 140, 145, 5, 35, -65, 500, 89, 14, 12, 12 };

            for (int i = 0; i < arr.Length; i++)
                avlTreeService.Insert(arr[i]);

            avlTreeService.Inorder();
            Console.WriteLine("Height is : " + avlTreeService.GetHeight());
        }
    }
}
