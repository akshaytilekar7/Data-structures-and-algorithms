using CSharp.Leetcode.Stack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllCoreFiles.CSharp.RedBlackTree
{
    public class RBTClient
    {
        public static void Main()
        {
            Console.WriteLine("RB TREE");

            int[] arr = new int[500000];

            Random r = new Random();
            for (int i = 0; i < arr.Length; ++i)
                arr[i] = r.Next(0, 500000);

            RBTServices rbtServices = new RBTServices();
            TreeOperations treeOperations = new TreeOperations();
            var BST = treeOperations.Create();

            for (int i = 0; i < arr.Length; ++i)
            {
                rbtServices.InsertItrative(arr[i]);
                treeOperations.Insert(BST, arr[i]);
            }

            Console.WriteLine("RB TREE");
            //rbtServices.Inorder();
            Console.WriteLine("Height is " + rbtServices.GetHeight(rbtServices.RbTree.Root));

            Console.WriteLine("\n\nBST TREE");
            //treeOperations.Inorder(BST);
            Console.WriteLine("Height is " + treeOperations.GetHeight(BST.root));

        }

    }
}
