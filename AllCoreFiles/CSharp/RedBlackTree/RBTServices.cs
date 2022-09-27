using System;
using System.Collections.Generic;
using System.Linq;
namespace AllCoreFiles.CSharp.RedBlackTree
{
    public class RBTServices
    {
        public readonly RbTree RbTree;

        public RBTServices()
        {
            RbTree = new RbTree();
            RbTree.Nil = new Node();
            RbTree.Nil.Color = Color.BLACK;
            RbTree.Nil.Data = -1;
            RbTree.Nil.Left = null;
            RbTree.Nil.Right = null;
            RbTree.Nil.Parent = null;
            //RbTree.Nil = null;
            RbTree.Root = RbTree.Nil;
        }
        public Node GetNode(int data, Node pNil)
        {
            Node newNode = new Node();
            newNode.Data = data;
            newNode.Color = Color.RED;
            newNode.Left = pNil;
            newNode.Right = pNil;
            newNode.Parent = pNil;
            return newNode;

            //Node node = new Node();
            //node.Data = data;
            //return node;
        }
        public void Insert(int data)
        {
            if (RbTree.Root == RbTree.Nil)
            {
                RbTree.Root = GetNode(data, RbTree.Nil);
                RbTree.Count++;
                return;
            }

            InsertHelper(RbTree.Root, data);
            RbTree.Count++;
            return;
        }
        public Node GetMaxNode(Node node)
        {
            Node travel = node;
            while (travel.Right != RbTree.Nil) //
                travel = travel.Right;
            return travel;
        }
        public Node GetMinNode(Node node)
        {
            Node travel = node;
            while (travel.Left != RbTree.Nil)
                travel = travel.Left;
            return travel;
        }
        public int GetHeight(Node node)
        {
            if (node == RbTree.Nil)
                return 0;
            return 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        }

        #region traversal
        public void InorderHelper(Node root)
        {
            if (root != RbTree.Nil)
            {
                InorderHelper(root.Left);
                Console.Write(" " + root.Data);
                InorderHelper(root.Right);
            }
        }
        public void Inorder()
        {
            Console.Write("[IN]");
            InorderHelper(RbTree.Root);
            Console.Write(" [END]\n");
        }

        #endregion #region

        private void InsertFixup(Node newNode)
        {
            while (newNode.Parent.Color == Color.RED)
            {
                if (newNode.Parent == newNode.Parent.Parent.Left)
                {
                    var uncle = newNode.Parent.Parent.Right;
                    if (uncle.Color == Color.RED)
                    {
                        newNode.Parent.Color = uncle.Color = Color.BLACK;
                        newNode.Parent.Parent.Color = Color.RED;
                        newNode = newNode.Parent.Parent;
                    }
                    else
                    {
                        if (newNode == newNode.Parent.Right)
                        {
                            newNode = newNode.Parent;
                            LeftRotate(newNode);
                        }
                        newNode.Parent.Color = Color.BLACK;
                        newNode.Parent.Parent.Color = Color.RED;
                        RightRotate(newNode.Parent.Parent);
                    }
                }
                else
                {
                    var uncle = newNode.Parent.Parent.Left;
                    if (uncle.Color == Color.RED)
                    {
                        newNode.Parent.Color = uncle.Color = Color.BLACK;
                        newNode.Parent.Parent.Color = Color.RED;
                        newNode = newNode.Parent.Parent;
                    }
                    else
                    {
                        if (newNode == newNode.Parent.Left)
                        {
                            newNode = newNode.Parent;
                            RightRotate(newNode);
                        }
                        newNode.Parent.Color = Color.BLACK;
                        newNode.Parent.Parent.Color = Color.RED;
                        LeftRotate(newNode.Parent.Parent);
                    }
                }
            }
            RbTree.Root.Color = Color.BLACK;
        }
        private Node InsertHelper(Node currnetNode, int newData)
        {
            if (currnetNode == RbTree.Nil)
            {
                currnetNode = GetNode(newData, RbTree.Nil);
                return currnetNode;
            }
            else
            {
                if (currnetNode.Data < newData)
                {
                    currnetNode.Right = InsertHelper(currnetNode.Right, newData);
                    currnetNode.Right.Parent = currnetNode;
                }
                else
                {
                    currnetNode.Left = InsertHelper(currnetNode.Left, newData);
                    currnetNode.Left.Parent = currnetNode;
                }
            }
            InsertFixup(currnetNode);
            return currnetNode;
        }
        private void LeftRotate(Node x)
        {
            Node y = x.Right;
            x.Right = y.Left;
            if (y.Left != RbTree.Nil)
                y.Left.Parent = x;

            y.Parent = x.Parent;
            if (x.Parent == RbTree.Nil)
                RbTree.Root = y;
            else if (x.Parent.Left == x)
                x.Parent.Left = y;
            else if (x.Parent.Right == x)
                x.Parent.Right = y;

            y.Left = x;
            x.Parent = y;
        }
        private void RightRotate(Node x)
        {
            Node y = x.Left;
            x.Left = y.Right;
            if (y.Right != RbTree.Nil)
                y.Right.Parent = x;

            y.Parent = x.Parent;
            if (x.Parent == RbTree.Nil)
                RbTree.Root = y;
            else if (x.Parent.Right == x)
                x.Parent.Right = y;
            else if (x.Parent.Left == x)
                x.Parent.Left = y;

            y.Right = x;
            x.Parent = y;
        }
    }
}
