// https://leetcode.com/problems/path-sum-ii/submissions/
// 113. Path Sum II
// https://leetcode.com/problems/path-sum-ii/discuss/2402478/C-DFS-RECUSRIVE

/*
Runtime: 148 ms, faster than 96.77% of C# online submissions for Path Sum II.
Memory Usage: 51.7 MB, less than 5.91% of C# online submissions for Path Sum II.
*/


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

public class TreeNodeService
{
    public IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
        IList<IList<int>> mainLst = new List<IList<int>>();
        if (root == null) return mainLst;
        PathSum(root, targetSum, new List<int>(), mainLst);
        return mainLst;
    }

    public void PathSum(TreeNode root, int targetSum, List<int> lst, IList<IList<int>> mainLst)
    {
        lst.Add(root.val);

        if (root.left == null && root.right == null && lst.Sum() == targetSum)
            mainLst.Add(lst);

        if (root.left != null)
            PathSum(root.left, targetSum, new List<int>(lst), mainLst);
        if (root.right != null)
            PathSum(root.right, targetSum, new List<int>(lst), mainLst);
    }

}
public class Program
{
    public static void Main()
    {
        int[] arr = { 5, 4, 8, 11, 13, 4, 7, 2, 5, 1 };
        TreeNodeService service = new TreeNodeService();

        TreeNode treeNode =
                    new TreeNode(5,
                    new TreeNode(4, new TreeNode(11, new TreeNode(7), new TreeNode(2))),
                    new TreeNode(8, new TreeNode(13), new TreeNode(4, new TreeNode(5), new TreeNode(1)))); ;
        var res = service.PathSum(treeNode, 22);
        Console.WriteLine(res);
        Console.ReadLine();
    }
}
