using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Leetcode.Stack
{
    public class TreeOperations
    {
        public readonly BST tree;

        public TreeOperations()
        {
            tree = new BST();
            tree.count = 0;
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

        public int Insert(int data)
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

        public void Inorder()
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

        public int GetHeight(Node node)
        {
            if (node == null) return 0;
            return 1 + GetHeight(node.Left) + GetHeight(node.Right);
        }

        public void Delete(Node z)
        {
            if (z.Left == null)
            {
                if (tree.root == z)
                    tree.root = z.Right;
                else if (z == z.Parent.Left)
                    z.Parent.Left = z.Right;
                else if (z == z.Parent.Right)
                    z.Parent.Right = z.Right;
                if (z.Right != null)
                    z.Right.Parent = z.Parent;
            }
            else if (z.Right == null)
            {
                if (tree.root == z)
                    tree.root = z.Left;
                else if (z == z.Parent.Left)
                    z.Parent.Left = z.Left;
                else if (z == z.Parent.Right)
                    z.Parent.Right = z.Left;
                if (z.Left != null)
                    z.Left.Parent = z.Parent;
            }
            else
            {
                var w = z.Right;
                while (w.Left != null)
                    w = w.Left;

                if (z.Right != w)
                {
                    w.Parent.Left = w.Right;
                    if (w.Right != null)
                        w.Right.Parent = w.Parent;

                    w.Right = z.Right;
                    w.Right.Parent = w;
                }

                w.Left = z.Left;
                w.Left.Parent = w;

                if (tree.root == z)
                    tree.root = w;
                else if (z == z.Parent.Left)
                    z.Parent.Left = w;
                else if (z == z.Parent.Right)
                    z.Parent.Right = w;

                w.Parent = z.Parent;
            }
        }

        public Node GetNode(int data)
        {
            if (tree.root == null)
                return null;
            var node = tree.root;
            while (true)
            {
                if (node == null)
                    return null;

                if (node.Data == data)
                    return node;

                if (data < node.Data)
                    node = node.Left;
                else
                    node = node.Right;
            }
        }

    }
}