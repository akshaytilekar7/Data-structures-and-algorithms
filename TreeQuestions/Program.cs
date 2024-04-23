using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees;

namespace Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeDFS treeDFS = new TreeDFS();
            var root = new TreeNode(1, new TreeNode(2, new TreeNode(3), new TreeNode(4)), new TreeNode(5, null, new TreeNode(6)));
            var x = treeDFS.BinaryTreePaths(root);
            Console.ReadLine();
        }
    }
}
