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
        public void InsertMineWorking(int data)
        {
            if (RbTree.Root == RbTree.Nil)
            {
                RbTree.Root = GetNode(data, RbTree.Nil);
                RbTree.Count++;
                return;
            }

            InsertHelperMineWorking(RbTree.Root, data);
            RbTree.Count++;
            return;
        }
        private Node InsertHelperMineWorking(Node currnetNode, int newData)
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
                    currnetNode.Right = InsertHelperMineWorking(currnetNode.Right, newData);
                    currnetNode.Right.Parent = currnetNode;
                    //InsertFixupOld(currnetNode.Right);
                }
                else
                {
                    currnetNode.Left = InsertHelperMineWorking(currnetNode.Left, newData);
                    currnetNode.Left.Parent = currnetNode;
                }
            }
            rb_insert_fixup(currnetNode);
            return currnetNode;///////////
        }
        private void InsertFixupOldNotWorking(Node z)
        {
            Node y = null;
            while (z.Parent.Color == Color.RED)
            {
                if (z.Parent == z.Parent.Parent.Left)
                {
                    y = z.Parent.Parent.Right;
                    if (y.Color == Color.RED)
                    {
                        z.Parent.Color = Color.BLACK;
                        y.Color = Color.BLACK;
                        z.Parent.Parent.Color = Color.RED;
                        z = z.Parent.Parent;
                    }
                    else
                    {
                        if (z == z.Parent.Right)
                        {
                            z = z.Parent;
                            LeftRotate(z);
                        }
                        z.Parent.Color = Color.BLACK;
                        z.Parent.Parent.Color = Color.RED;
                        RightRotate(z.Parent.Parent);
                    }
                }
                else
                {
                    y = z.Parent.Parent.Left; //
                    if (y.Color == Color.RED)
                    {
                        z.Parent.Color = Color.BLACK;
                        y.Color = Color.BLACK;
                        z.Parent.Parent.Color = Color.RED;
                        z = z.Parent.Parent;
                    }
                    else
                    {
                        if (z == z.Parent.Left) //
                        {
                            z = z.Parent;
                            RightRotate(z);
                        }
                        z.Parent.Color = Color.BLACK;
                        z.Parent.Parent.Color = Color.RED;
                        LeftRotate(z.Parent.Parent);
                    }
                }
            }
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
            if (y.Right != RbTree.Nil) //
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
        Node GetMaxNode(Node node)
        {
            Node travel = node;
            while (travel.Right != RbTree.Nil) //
                travel = travel.Right;
            return travel;
        }
        Node GetMinNode(Node node)
        {
            Node travel = node;
            while (travel.Left != RbTree.Nil)
                travel = travel.Left;
            return travel;
        }
        int GetHeight(Node node)
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

        #endregion #region traversal

        #region SIR

        void rb_insert_fixupSIRworking(Node z)
        {
            Node y = null;

            while (z.Parent.Color == Color.RED)
            {
                if (z.Parent == z.Parent.Parent.Left)
                {
                    y = z.Parent.Parent.Right;
                    if (y.Color == Color.RED)
                    {
                        z.Parent.Color = Color.BLACK;
                        y.Color = Color.BLACK;
                        z.Parent.Parent.Color = Color.RED;
                        z = z.Parent.Parent;
                    }
                    else
                    {
                        if (z == z.Parent.Right)
                        {
                            z = z.Parent;
                            LeftRotate(z);
                        }

                        z.Parent.Color = Color.BLACK;
                        z.Parent.Parent.Color = Color.RED;
                        RightRotate(z.Parent.Parent);
                    }
                }
                else
                {
                    y = z.Parent.Parent.Left;
                    if (y.Color == Color.RED)
                    {
                        z.Parent.Color = Color.BLACK;
                        y.Color = Color.BLACK;
                        z.Parent.Parent.Color = Color.RED;
                        z = z.Parent.Parent;
                    }
                    else
                    {
                        if (z == z.Parent.Left)
                        {
                            z = z.Parent;
                            RightRotate(z);
                        }

                        z.Parent.Color = Color.BLACK;
                        z.Parent.Parent.Color = Color.RED;
                        LeftRotate(z.Parent.Parent);
                    }
                }
            }

            RbTree.Root.Color = Color.BLACK;
        }


        public int InsertSirWorking(int data)
        {
            if (RbTree.Root == RbTree.Nil)
            {
                RbTree.Root = GetNode(data, RbTree.Nil);
                RbTree.Count++;
                return 1;
            }

            InsertNodeSirWorking(RbTree.Root, data);
            RbTree.Count++;
            return 1;
        }
        public Node InsertNodeSirWorking(Node currnetNode, int newData)
        {
            if (currnetNode == RbTree.Nil)
            {
                currnetNode = GetNode(newData, RbTree.Nil);
                return currnetNode;
            }
            if (currnetNode.Data < newData)
            {
                currnetNode.Right = InsertNodeSirWorking(currnetNode.Right, newData);
                currnetNode.Right.Parent = currnetNode;
                //rb_insert_fixup(root.Right);
            }
            else
            {
                currnetNode.Left = InsertNodeSirWorking(currnetNode.Left, newData);
                currnetNode.Left.Parent = currnetNode;
                //rb_insert_fixup(root.Left);
            }
            rb_insert_fixup(currnetNode);
            return currnetNode;
        }
        #endregion
    }
}
