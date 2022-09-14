using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllCoreFiles.CSharp.RedBlackTree
{
    public class RBTServices
    {
        public readonly RbTree p_rb_tree;
        public RbNode GetRBTreeNode(int data, Color color, RbNode p_nil)
        {
            RbNode p_rb_node = new RbNode();
            p_rb_node.Data = data;
            p_rb_node.Color = color;
            p_rb_node.Left = p_nil;
            p_rb_node.Right = p_nil;
            p_rb_node.Parent = p_nil;
            return p_rb_node;
        }

        public RBTServices()
        {
            p_rb_tree = new RbTree();
            p_rb_tree.Root = null;
            p_rb_tree.Nil = GetRBTreeNode(-1, Color.BLACK, null);
        }
    }
}
