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
                Console.WriteLine("height at node= {0} : H = {1}\n", item, avlManagement.GetHeight(avlManagement._avlTree.Root));
            }
            avlManagement.Inorder();

        }


    }
}
