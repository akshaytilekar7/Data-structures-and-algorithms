namespace BinarySearchTree
{
    public static class Client
    {
        public static void Main()
        {
            Console.WriteLine("BinarySearchTree");
            BstService bstService = new BstService();
            BstService tree = new BstService();

            int[] arr = { 100, 50, 150, 40, 60, 30, 45, 55, 65, 20, 46, 140, 145, 5, 35, -65, 500, 89, 14, 12, 12 };

            for (int i = 0; i < arr.Length; i++)
                bstService.Insert(arr[i]);

            //Random r = new Random();
            //arr = arr.OrderBy(x => r.Next()).ToArray();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    tree.Delete(arr[i]);
            //    tree.Inorder("After delete : " + arr[i]);
            //    Console.WriteLine("Height is : {0}", tree.GetHeight());
            //    Console.WriteLine();
            //}

            //bstService.LevelOrderTraverser1();
            //bstService.PrintLevelOrderTraverser2();
            //bstService.PrintAverageOfLevels();

            bstService.SpiralPrint1();
            bstService.SpiralPrint2();

            //Console.WriteLine(bstService.IsExist(0));
            //Console.WriteLine(bstService.IsExist(100));
            //bstService.BFS();
            //bstService.LevelOrderTraverser();
            //bstService.SpiralPrint();

            //Random r = new Random();
            //arr = arr.OrderBy(x => r.Next()).ToArray();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    bstService.Delete(arr[i]);
            //    bstService.Inorder("after delete " + arr[i]);
            //    Console.WriteLine();
            //}

            //Console.WriteLine("Height is : {0}", bstService.GetHeight());
            //Console.WriteLine("Width is : {0}", bstService.GetWidth());
            //Console.WriteLine("Diameter is : {0}", bstService.GetDiameter());

            // bstService.Inorder("C# Done");

            Console.ReadLine();
        }
    }
}
