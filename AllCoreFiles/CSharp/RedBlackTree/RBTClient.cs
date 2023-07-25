namespace AllCoreFiles.CSharp.RedBlackTree1
{
    public class RBTClient
    {
        public static void Main()
        {
            RBTServices rbtServices = new RBTServices();
            //TreeOperations treeOperations = new TreeOperations();

            int[] arr = { 100, 50, 150, 40, 60, 30, 45, 55, 65, 20, 46, 140, 145 };

            foreach (var item in arr)
            {
                //treeOperations.Insert(item);
                rbtServices.Insert(item);
                Console.WriteLine("Height : " + rbtServices.GetHeight(rbtServices.RbTree.Root));
                // Console.WriteLine("Normal height is : " + treeOperations.GetHeight(BST.root));
            }
            rbtServices.Inorder();
            // Random rnd = new Random();
            // var MyRandomArray = arr.OrderBy(x => rnd.Next()).ToList();
            int[] MyRandomArray = { 145, 60, 100, 45, 46, 30, 20, 50, 65, 150, 140, 55, 40 };
            foreach (var item in MyRandomArray)
            {
                var node = rbtServices.GetNode(item);
                if (node != null)
                {
                    rbtServices.Delete(node);
                    Console.WriteLine("Removed data: {0}", item);
                    Console.WriteLine("Height : " + rbtServices.GetHeight(rbtServices.RbTree.Root));
                }
                //rbtServices.Inorder();
                //var node2 = treeOperations.GetNode(item);
                //treeOperations.Delete(node2);
                //Console.WriteLine("RB height is : " + rbtServices.GetHeight(rbtServices.RbTree.Root));
                //Console.WriteLine("Normal height is : " + treeOperations.GetHeight(BST.root));
            }

            Console.WriteLine("DONE DONE DONE");
            Console.ReadLine();
        }
    }
}
