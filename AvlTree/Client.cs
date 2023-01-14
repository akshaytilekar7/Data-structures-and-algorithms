namespace AvlTree
{
    public static class Client
    {
        public static void Main()
        {
            AvlTreeService avlTreeService = new AvlTreeService();

            int[] arr = { 20, 8, 22, 4, 12, 10, 14, 35, 30, -90 , 562 };

            for (int i = 0; i < arr.Length; i++)
                avlTreeService.Insert(arr[i]);

            avlTreeService.Inorder();
        }
    }
}
