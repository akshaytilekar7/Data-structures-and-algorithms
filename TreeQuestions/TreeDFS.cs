namespace Trees;

public class TreeDFS
{
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        if (root == null) return false;
        if (root.left == null && root.right == null && targetSum == 0) return true;

        targetSum = targetSum - root.val;

        return HasPathSum(root.left, targetSum) || HasPathSum(root.right, targetSum);
    }

    public int KthSmallest(TreeNode root, int k)
    {
        return KthSmallestHelper(root, k, 0);
    }

    public int KthSmallestHelper(TreeNode root, int k, int cnt)
    {
        if (root == null) return null;

        var left = KthSmallest(root.left, k);
        if (left != null) return left;
        cnt++;
        if (cnt == k) return root.val;

        return KthSmallest(root.right, k);
    }

    int count = 0;
    int result = -100;

    public int KthSmallest2(TreeNode root, int k)
    {
        Traverse(root, k);
        return result;
    }

    public void Traverse(TreeNode root, int k)
    {
        if (root == null)
            return;
        Traverse(root.left, k);
        count++;
        if (count == k)
        {
            result = root.val;
            return;
        }
        Traverse(root.right, k);
    }

    public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null || root == p || root == q)
            return root;

        TreeNode left = lowestCommonAncestor(root.left, p, q);
        TreeNode right = lowestCommonAncestor(root.right, p, q);

        if (left != null && right != null)
            return root;

        return left != null ? left : right;
    }

    public bool IsValidBST2(TreeNode root)
    {
        //Variable l is holding the value of the last item of the iteration.
        //The line indicates that if the last item of the iteration is greater
        //than the current value then the tree is not valid thus return false
        int? lastValue = null;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode current = root;
        while (current != null || stack.Count() > 0)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }
            current = stack.Pop();
            if (lastValue != null && lastValue >= current.val) return false;
            lastValue = current.val;
            current = current.right;
        }

        return true;
    }

    public bool IsValidBST(TreeNode root)
    {
        return Evaluate(root);
    }

    private bool Evaluate(TreeNode node, long? min = null, long? max = null)
    {
        if (node == null)
            return true;

        if (min != null && node.val <= min) return false;
        if (max != null && node.val >= max) return false;

        var left = Evaluate(node.left, min, node.val);
        var right = Evaluate(node.right, node.val, max);
        return left && right;
    }

    public void Flatten(TreeNode root)
    {
        if (root == null) return;

        var current = root;

        while (current != null)
        {
            if (current.left != null)
            {
                var left = current.left;
                while (left.right != null)
                    left = left.right;

                left.right = current.right;
                current.right = current.left;
                current.left = null;
            }
            current = current.right;
        }
    }

    public void Flatten2(TreeNode root)
    {
        List<TreeNode> treeNodes = new List<TreeNode>();
        Preorder(root, treeNodes);
        for (int i = 0; i < treeNodes.Count - 1; i++)
        {
            var ele = treeNodes[i];
            var next = treeNodes[i + 1];
            ele.right = next;
            ele.left = null;
        }
    }

    public void Preorder(TreeNode root, List<TreeNode> treeNodes)
    {
        if (root == null) return;

        treeNodes.Add(root);
        Preorder(root.left, treeNodes);
        Preorder(root.right, treeNodes);
    }

    public TreeNode Sort(int[] array, int start, int end)
    {
        if (start > end)
            return null;

        int mid = start + (end - start) / 2;

        TreeNode root = new TreeNode(array[mid]);
        root.left = Sort(array, start, mid - 1);
        root.right = Sort(array, mid + 1, end);

        return root;
    }

    public TreeNode SortedArrayToBST(int[] nums)
    {
        return Sort(nums, 0, nums.Length - 1);
    }

    public int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;

        var l = MaxDepth(root.left);
        var r = MaxDepth(root.right);

        return Math.Max(l, r) + 1;
    }

    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null) return root;

        var l = InvertTree(root.left);
        var r = InvertTree(root.right);

        root.left = r;
        root.right = l;

        return root;
    }

    public TreeNode InvertTreeNW(TreeNode root)
    {
        if (root == null) return root;
        if (root.left == null && root.right == null) return root;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        if (root.left != null) queue.Enqueue(root.left);
        if (root.right != null) queue.Enqueue(root.right);

        while (queue.Count > 0)
        {
            var x = queue.Dequeue();
            var y = queue.Dequeue();

            int t = x.val;
            x.val = y.val;
            y.val = t;

            if (x.left != null) queue.Enqueue(x.left);
            if (y.right != null) queue.Enqueue(y.right);
            if (x.right != null) queue.Enqueue(x.right);
            if (y.left != null) queue.Enqueue(y.left);
        }

        return root;
    }

    int d = 0;
    public int DiameterOfBinaryTree(TreeNode root)
    {
        if (root == null) return 0;
        GetHeight(root);
        return d - 1;
    }

    private int GetHeight(TreeNode root)
    {
        if (root == null) return 0;

        var l = GetHeight(root.left);
        var r = GetHeight(root.right);

        int di = l + r + 1;
        d = Math.Max(d, di);

        return Math.Max(l, r) + 1;

    }
}
