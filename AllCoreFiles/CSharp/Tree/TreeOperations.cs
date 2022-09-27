using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Leetcode.Stack
{
    public class TreeOperations
    {
        public BST Create()
        {

            BST tree = new BST();
            tree.count = 0;
            return tree;
        }

        public Node GetNewNode(int data)
        {
            Node root = new Node();
            root.Data = data;
            return root;
        }

        public Node InsertNode(Node root, int data)
        {
            if (root == null)
            {
                root = GetNewNode(data);
                return root;
            }
            if (root.Data < data)
            {
                root.Right = InsertNode(root.Right, data);
                root.Right.Parent = root;
            }
            else
            {
                root.Left = InsertNode(root.Left, data);
                root.Left.Parent = root;
            }
            return root;
        }

        public int Insert(BST tree, int data)
        {
            if (tree.root == null)
            {
                tree.root = GetNewNode(data);
                tree.count++;
                return 1;
            }

            InsertNode(tree.root, data);
            tree.count++;
            return 1;
        }

        public static void InorderHelper(Node root)
        {
            if (root != null)
            {
                InorderHelper(root.Left);
                InorderHelper(root.Right);
                Console.Write(" " + root.Data);
            }
        }

        public void Inorder(BST tree)
        {
            Console.Write("[IN]");
            InorderHelper(tree.root);
            Console.Write(" [END]\n");
        }

        public void PostorderIterative(BST tree)
        {
            Dictionary<Node, int> dict = new Dictionary<Node, int>();
            List<Node> compltedNodes = new List<Node>();
            Node root = tree.root;
            Console.Write("[IN]");
            while (true)
            {
                while (root != null)
                {
                    dict.Add(root, 1); // visit 1
                    root = root.Left;
                }
                if (dict.Count == 0) break;

                int last = dict.Values.Last();
                dict[dict.Keys.Last()] = last + 1; // visit 2nd or 3rd

                root = dict.Keys.Last();

                if (dict[dict.Keys.Last()] == 3)
                {
                    Console.Write(" " + dict.Keys.Last().Data);
                    compltedNodes.Add(dict.Keys.Last()); // node done, add in completed list
                    dict.Remove(dict.Keys.Last()); // already done, remove from dict
                }

                // if root.right is complted dont consider ie, null
                if (compltedNodes.Contains(root.Right))
                    root = null;
                else
                    root = root.Right;
            }
            Console.WriteLine(" [END]");
        }

        public void PostorderIterativeNewNotWorking(BST tree)
        {
            Dictionary<Node, int> dict = new Dictionary<Node, int>();
            Node root = tree.root;
            Console.Write("[IN]");
            while (true)
            {
                while (root != null)
                {
                    dict.Add(root, 1);
                    root = root.Left;
                }
                if (dict.Count == 0) break;

                int last = dict.Values.Last();
                dict[dict.Keys.Last()] = last + 1;

                root = dict.Keys.Last();

                if (dict[dict.Keys.Last()] == 3)
                {
                    Console.Write(" " + dict.Keys.Last().Data);
                    //dict.Remove(dict.Keys.Last());
                }

                if (root.Right != null && dict.ContainsKey(root.Right) && dict[root.Right] == 3)
                    root = null;
                else
                    root = root.Right;
            }
            Console.WriteLine(" [END]");
        }

    }
}