using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AvlTree
{
    public class AvlManagement
    {
        private readonly AvlTree _avlTree;
        public AvlManagement()
        {
            this._avlTree = new AvlTree();
        }
        public Node GetNewNode(int data)
        {
            return new Node() { Data = data };
        }
        public void Insert(int data)
        {
            if (_avlTree.Root == null)
            {
                _avlTree.Root = GetNewNode(data);
                return;
            }
            var node = _avlTree.Root;
            while (true)
            {
                if (data < node.Data)
                {
                    if (node.Left == null)
                    {
                        node.Left = GetNewNode(data);
                        node.Left.Parent = node;
                        break;
                    }
                    node = node.Left;
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = GetNewNode(data);
                        node.Right.Parent = node;
                        break;
                    }
                    node = node.Right;
                }
            }
        }
        public void Inorder()
        {
            Console.WriteLine("[START]");
            Inorder(_avlTree.Root);
            Console.WriteLine("[END]");
        }
        private void Inorder(Node node)
        {
            if (node != null)
            {
                Inorder(node.Left);
                Console.Write(" [{0}] ", node.Data);
                Inorder(node.Right);
            }
        }
        public Node GetMax()
        {
            var node = _avlTree.Root;
            while (node.Right != null)
                node = node.Right;
            return node;
        }
        public Node GetMin()
        {
            var node = _avlTree.Root;
            while (node.Left != null)
                node = node.Left;
            return node;
        }
        public Node GetNode(int data)
        {
            if (_avlTree.Root == null)
                return null;
            var node = _avlTree.Root;
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
        private void LeftRotate(Node x)
        {
            var y = x.Right;
            x.Right = y.Left;
            if (y.Left != null)
                y.Left.Parent = x;

            y.Parent = x.Parent;

            if (x.Parent == null)
                _avlTree.Root = y;
            else if (x == x.Parent.Left)
                x.Parent.Left = y;
            else if (x == x.Parent.Right)
                x.Parent.Right = y;

            y.Left = x;
            x.Parent = y;
        }
        private void RightRotate(Node x)
        {
            var y = x.Left;
            x.Left = y.Right;
            if (y.Right != null)
                y.Right.Parent = x;

            y.Parent = x.Parent;

            if (x.Parent == null)
                _avlTree.Root = y;
            else if (x == x.Parent.Right)
                x.Parent.Right = y;
            else if (x == x.Parent.Left)
                x.Parent.Left = y;

            y.Right = x;
            x.Parent = y;
        }
        public int GetHeight(Node node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        }

        public int GetBalanceOfNode(Node node)
        {
            if (node == null) return 0;
            int leftHeight = GetHeight(node.Left);
            int rightHeight = GetHeight(node.Right);
            return leftHeight - rightHeight;
        }

        public Node GetUpperImbalanceNode(Node node)
        {
            var travel = node;
            while (travel != null)
            {
                int imbalnceCount = GetBalanceOfNode(travel);
                if (imbalnceCount < -1 || imbalnceCount > 1)
                    return travel;
                travel = travel.Parent;
            }
            return null;
        }

    }
}
