
namespace CSharp.AvlTreeNew
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
                avlManagement.Inorder();
                Console.WriteLine("AVL height is : " + avlManagement.GetHeight(avlManagement._avlTree.Root));
            }

            Random rnd = new Random();
            var MyRandomArray = arr.OrderBy(x => rnd.Next()).ToList();

            foreach (var item in MyRandomArray)
            {
                avlManagement.Delete(item);
                avlManagement.Inorder();
                Console.WriteLine("delete height is : " + avlManagement.GetHeight(avlManagement._avlTree.Root));
            }

            Console.WriteLine("DONE DONE DONE");
            Console.ReadLine();
        }

    }
}


/*
 
Not working see
*/ 