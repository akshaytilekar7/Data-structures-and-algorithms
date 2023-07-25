// https://leetcode.com/problems/path-sum/submissions/
// 112. Path Sum
// https://leetcode.com/problems/path-sum/discuss/2400620/C-DFS-RECUSIVE

/*
Runtime: 152 ms, faster than 48.08% of C# online submissions for Path Sum.
Memory Usage: 40.2 MB, less than 90.79% of C# online submissions for Path Sum.
*/


namespace CSharp112
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
        public bool HasPathSum(TreeNode root, int sum)
        {
            return HasPathSumHelper(root, 0, sum);
        }

        public bool HasPathSumHelper(TreeNode root, int sum, int targetSum)
        {
            if (root == null)
                return false;

            sum += root.val;

            if (sum == targetSum && root.left == null && root.right == null)
                return true;

            bool x = HasPathSumHelper(root.left, sum, targetSum);
            if (x) return true;
            bool y = HasPathSumHelper(root.right, sum, targetSum);
            if (y) return true;
            return false;
        }
    }
    public class Program
    {
        public static void Main()
        {
            TreeNode node = new TreeNode(1);
            node.left = new TreeNode(2);
            var res = node.HasPathSum(node, 1);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
