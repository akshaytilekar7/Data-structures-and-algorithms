namespace CSharp.AvlTree
{
    public class AvlClient
    {
        public static void Main()
        {
            AvlManagement avlManagement = new AvlManagement();
            int[] arr = { 100, 50, 150, 40, 60, 30, 45, 55, 65, 20, 46, 140, 145 };

            foreach (var item in arr)
            {
                avlManagement.Insert(item);
                Console.WriteLine("insert height is : " + avlManagement.GetHeight(avlManagement._avlTree.Root));
            }
            Random rnd = new Random();
            var MyRandomArray = arr.OrderBy(x => rnd.Next()).ToList();

            Console.WriteLine("START");
            MyRandomArray.ForEach(x => Console.Write( " " + x + " "));
            Console.WriteLine("END");

            foreach (var item in MyRandomArray)
            {
                var node = avlManagement.GetNode(item);
                avlManagement.Delete(node);
                Console.WriteLine("delete height is : " + avlManagement.GetHeight(avlManagement._avlTree.Root));
            }

            Console.WriteLine("DONE DONE DONE");
            Console.ReadLine();
        }

    }
}
