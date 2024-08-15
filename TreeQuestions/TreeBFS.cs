namespace Trees;

public class TreeBFS
{
    public bool IsSymmetric(TreeNode root)
    {
        if (root == null) return false;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root.left);
        queue.Enqueue(root.right);
        while (queue.Count > 0)
        {
            var left = queue.Dequeue();
            var right = queue.Dequeue();

            if (left == null && right == null) continue;

            if (left == null || right == null) return false;

            if (left.val != right.val) return false;

            queue.Enqueue(left.left);
            queue.Enqueue(right.right);
            queue.Enqueue(left.right);
            queue.Enqueue(right.left);

            // OR
            //queue.Enqueue(left.right);
            //queue.Enqueue(right.left);
            //queue.Enqueue(right.right);
            //queue.Enqueue(left.left); 
        }
        return true;
    }

    // Two nodes of a binary tree are cousins if they have the same depth with different parents.
    public bool IsCousins(TreeNode root, int x, int y)
    {
        if (root == null) return false;

        int xDepth = -1, yDepth = -1;
        TreeNode xParent = null, yParent = null;

        DepthAndParent(root, 0, null);
        return xDepth == yDepth && xParent != yParent; // same depth and not same parents.

        void DepthAndParent(TreeNode node, int depth, TreeNode parent)
        {
            if (node == null) return;

            if (node.val == x)
            {
                xDepth = depth;
                xParent = parent;
            }
            else if (node.val == y)
            {
                yDepth = depth;
                yParent = parent;
            }

            DepthAndParent(node.left, depth + 1, node);
            DepthAndParent(node.right, depth + 1, node);
        }
    }

    public int GetHeight(TreeNode root)
    {
        if (root == null)
            return -1; 

        int leftHeight = GetHeight(root.left);
        int rightHeight = GetHeight(root.right);

        return Math.Max(leftHeight, rightHeight) + 1;
    }

    public IList<int> RightSideView(TreeNode root)
    {
        IList<int> list = new List<int>();
        if (root == null) return list;
        Queue<TreeNode> queue = new Queue<TreeNode>();

        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var cnt = queue.Count();
            for (int i = 0; i < cnt; i++)
            {
                var ele = queue.Dequeue();
                if (i == cnt - 1)
                    list.Add(ele.val);

                if (ele.left != null)
                    queue.Enqueue(ele.left);
                if (ele.right != null)
                    queue.Enqueue(ele.right);
            }
        }
        return list;
    }

    public IList<IList<int>> LevelOrderBottom(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (root == null) return result;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            var child = new List<int>();
            int cnt = queue.Count;
            for (int i = 0; i < cnt; i++)
            {
                var node = queue.Dequeue();
                child.Add(node.val);

                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);

            }
            result.Insert(0, child);
        }

        return result;
    }

    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (root == null) return result;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        bool flag = false;

        while (queue.Count != 0)
        {
            var child = new List<int>();
            int cnt = queue.Count;
            for (int i = 0; i < cnt; i++)
            {
                var node = queue.Dequeue();
                child.Add(node.val);

                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);

            }
            if (flag)
                child.Reverse();
            flag = !flag;
            result.Add(child);
        }

        return result;
    }

    public List<List<int>> zigzagLevelOrder(TreeNode root)
    {
        List<List<int>> result = new List<List<int>>();

        if (root == null)
            return result;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var reverse = false;

        while (queue.Count() > 0)
        {
            int cnt = queue.Count();
            List<int> child = new List<int>();
            for (int i = 0; i < cnt; i++)
            {
                if (!reverse)
                {
                    TreeNode currentNode = queue.Dequeue();
                    child.Add(currentNode.val);
                    if (currentNode.left != null)
                        queue.Enqueue(currentNode.left);
                    if (currentNode.right != null)
                        queue.Enqueue(currentNode.right);
                }
                else
                {
                    TreeNode currentNode = queue.Dequeue();
                    child.Add(currentNode.val);
                    if (currentNode.right != null)
                        queue.Enqueue(currentNode.right);
                    if (currentNode.left != null)
                        queue.Enqueue(currentNode.left);
                }
            }
            reverse = !reverse;
            result.Add(child);
        }
        return result;
    }

    //the node that appears right after the given node in the level order traversal.
    public int LevelOrderSuccessor(TreeNode root, int val)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var ele = queue.Dequeue();
            if (ele.left != null) queue.Enqueue(ele.left);
            if (ele.right != null) queue.Enqueue(ele.right);
            if (ele.val == val)
                return queue.Count > 0 ? queue.Dequeue().val : 0;
        }
        return 0;
    }

    public IList<double> AverageOfLevels(TreeNode root)
    {
        IList<double> result = new List<double>();

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);


        while (queue.Count > 0)
        {
            var cnt = queue.Count();
            double sum = 0;
            for (int i = 0; i < cnt; i++)
            {
                var ele = queue.Dequeue();
                if (ele.left != null) queue.Enqueue(ele.left);
                if (ele.right != null) queue.Enqueue(ele.right);
                sum += ele.val;
            }
            result.Add(sum / cnt);
        }

        return result;
    }

    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        List<IList<int>> list = new List<IList<int>>();
        if (root == null) return list;
        Queue<TreeNode> queue = new Queue<TreeNode>();

        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var child = new List<int>();
            var cnt = queue.Count();
            for (int i = 0; i < cnt; i++)
            {
                var ele = queue.Dequeue();
                child.Add(ele.val);
                if (ele.left != null)
                    queue.Enqueue(ele.left);
                if (ele.right != null)
                    queue.Enqueue(ele.right);
            }
            list.Add(child);
        }
        return list;
    }
}
