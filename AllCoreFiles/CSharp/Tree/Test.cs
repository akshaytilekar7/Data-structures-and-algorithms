﻿namespace CSharp.Leetcode.Stack
{
    public class Test
    {
        static void Main1123(string[] args)
        {
            TreeOperations tree = new TreeOperations();

            int[] arr1 = { 100, 150, 75, 200, 125, 85, 50, 65, 130, 129, 127, 128 };

            for (int i = 0; i < arr1.Length; i++)
                tree.Insert(arr1[i]);


            tree.Inorder();
            System.Console.WriteLine("********");
            //tree.PostorderIterative(BST);
            System.Console.WriteLine("********");
            // tree.PostorderIterativeNewNotWorking(BST);

            System.Console.WriteLine("DONE");
        }
    }
}