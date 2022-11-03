using CSharp.Leetcode.Stack;

namespace CSharp.AvlTree1
{
    public class AvlClient
    {
        public static void Main()
        {
            AvlManagement avlManagement = new AvlManagement();
            TreeOperations treeOperations = new TreeOperations();
            BST BST = treeOperations.Create();

            int[] arr = { 100, 50, 150, 40, 60, 30, 45, 55, 65, 20, 46, 140, 145 };

            foreach (var item in arr)
            {
                treeOperations.Insert(BST, item);
                avlManagement.Insert(item);
                avlManagement.Inorder();
                var node = avlManagement.GetNode(item);
                Console.WriteLine("AVL height is : " + avlManagement.GetHeight(avlManagement._avlTree.Root));
                Console.WriteLine("Normal height is : " + treeOperations.GetHeight(BST.root));
            }

            Random rnd = new Random();
            var MyRandomArray = arr.OrderBy(x => rnd.Next()).ToList();
            Console.WriteLine("START");
            MyRandomArray.ForEach(x => Console.Write(" " + x + " "));
            Console.WriteLine("END");

            foreach (var item in MyRandomArray)
            {
                var node1 = avlManagement.GetNode(item);
                avlManagement.Delete(node1);
                var node2 = treeOperations.GetNode(item);
                treeOperations.Delete(node2);
                avlManagement.Inorder();
                Console.WriteLine("delete height is : " + avlManagement.GetHeight(avlManagement._avlTree.Root));
                Console.WriteLine("Normal height is : " + treeOperations.GetHeight(BST.root));

            }

            Console.WriteLine("DONE DONE DONE");
            Console.ReadLine();
        }

    }
}


/*
 
Not working see
*/ 