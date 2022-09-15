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
            RbTree.Root = null;
            RbTree.Nil = GetNode(-1, Color.BLACK, null);
        }
        public Node GetNode(int data, Color color, Node p_nil)
        {
            Node p_rb_node = new Node();
            p_rb_node.Data = data;
            p_rb_node.Color = color;
            p_rb_node.Left = p_nil;
            p_rb_node.Right = p_nil;
            p_rb_node.Parent = p_nil;
            return p_rb_node;
        }
        Node GetMaxNode(Node node)
        {
            Node travel = node;
            while (travel.Right != RbTree.Nil)
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
        public void Preorder()
        {
            PreorderHelper(RbTree.Root, RbTree.Nil);
        }
        private void PreorderHelper(Node rbTree, Node nilNode)
        {
            while (rbTree != nilNode)
            {
                Console.Write(rbTree.Data + "<->");
                PreorderHelper(rbTree.Left, nilNode);
                PreorderHelper(rbTree.Right, nilNode);
            }
        }
        public void Inorder()
        {
            InorderHelper(RbTree.Root, RbTree.Nil);
        }
        private void InorderHelper(Node rbTree, Node nilNode)
        {
            while (rbTree != nilNode)
            {
                InorderHelper(rbTree.Left, nilNode);
                Console.Write(rbTree.Data + "<->");
                InorderHelper(rbTree.Right, nilNode);
            }
        }
        public void Postorder()
        {
            PostorderHelper(RbTree.Root, RbTree.Nil);
        }
        private void PostorderHelper(Node rbTree, Node nilNode)
        {
            while (rbTree != nilNode)
            {
                Console.Write(rbTree.Data + "<->");
                PostorderHelper(rbTree.Left, nilNode);
                PostorderHelper(rbTree.Right, nilNode);
            }
        }

        #endregion #region traversal
    }
}
