using CSharp.Leetcode.Stack;

namespace CSharp.AvlTreeNew
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
                var node = avlManagement.GetNode(item);
                Console.WriteLine("AVL height is : " + avlManagement.GetHeight(avlManagement._avlTree.Root));
                Console.WriteLine("Normal height is : " + treeOperations.GetHeight(BST.root));
            }
            avlManagement.Inorder();

            Random rnd = new Random();
            var MyRandomArray = arr.OrderBy(x => rnd.Next()).ToList();

            foreach (var item in MyRandomArray)
            {
                avlManagement.Delete(item);
                var node2 = treeOperations.GetNode(item);
                treeOperations.Delete(node2);
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