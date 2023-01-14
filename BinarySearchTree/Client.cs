namespace BinarySearchTree
{
    public static class Client
    {
        public static void Main()
        {
            BstService bstService = new BstService();

            int[] arr = { 20, 8, 22, 4, 12, 10, 14, 35, 30 };

            for (int i = 0; i < arr.Length; i++)
                bstService.Insert(arr[i]);

            bstService.Inorder();

            Console.WriteLine(bstService.IsExist(0));
            Console.WriteLine(bstService.IsExist(100));
            bstService.BFS();
            bstService.LevelOrderTraverser();
            bstService.SpiralPrint();

            //Random r = new Random();
            //arr = arr.OrderBy(x => r.Next()).ToArray();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    bstService.Delete(arr[i]);
            //    bstService.Inorder("after delete " + arr[i]);
            //    Console.WriteLine();
            //}

            Console.WriteLine("Height is : {0}", bstService.GetHeight());
            Console.WriteLine("Width is : {0}", bstService.GetWidth());
            Console.WriteLine("Diameter is : {0}", bstService.GetDiameter());

            // bstService.Inorder("C# Done");
        }
    }
}
