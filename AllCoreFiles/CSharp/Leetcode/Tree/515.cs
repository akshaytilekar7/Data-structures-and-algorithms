// https://leetcode.com/problems/find-largest-value-in-each-tree-row/
// 515. Find Largest Value in Each Tree Row
// https://leetcode.com/problems/find-largest-value-in-each-tree-row/discuss/2398103/C

/*
Runtime: 140 ms, faster than 100.00% of C# online submissions for Find Largest Value in Each Tree Row.
Memory Usage: 45.3 MB, less than 6.73% of C# online submissions for Find Largest Value in Each Tree Row.
*/


namespace CSharp
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class Program
    {
        public IList<int> LargestValues(TreeNode root)
        {
            IList<int> result = new List<int>();
            if (root == null)
                return result;

            Queue<TreeNode> queueTreeNodes = new Queue<TreeNode>();
            queueTreeNodes.Enqueue(root);

            while (queueTreeNodes.Count() != 0)
            {
                int len = queueTreeNodes.Count();
                int max = int.MinValue;

                for (int i = 0; i < len; i++) // BEST
                {
                    var node = queueTreeNodes.Dequeue();

                    if (node.left != null)
                        queueTreeNodes.Enqueue(node.left);
                    if (node.right != null)
                        queueTreeNodes.Enqueue(node.right);

                    if (node.val > max)
                        max = node.val;
                }
                result.Add(max);
            }
            return result;
        }
        public static void Main()
        {
            TreeNode node = new TreeNode(1);
            node.left = new TreeNode(3, new TreeNode(5), new TreeNode(3));
            node.right = new TreeNode(2, null, new TreeNode(9));
            var p = new Program();
            var res = p.LargestValues(node);
            Console.WriteLine("CSharp Hello");
        }
    }
}
