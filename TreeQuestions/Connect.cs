
public class Node
{
    public int val;
    public Node left;
    public Node right;
    public Node next;
    public Node() { }
    public Node(int _val) { val = _val; }

    public Node(int _val, Node _left, Node _right, Node _next)
    {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
   
}

public class Solution
{
    public Node Connect(Node root)
    {
        if (root == null) return root;

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var cnt = queue.Count();
            for (int i = 0; i < cnt; i++)
            {
                var ele = queue.Dequeue();
                if (queue.TryPeek(out var x) && i + 1 != cnt) // i + 1 != cnt skip lat elemenet ie right most
                    ele.next = x;

                if (ele.left != null) queue.Enqueue(ele.left);
                if (ele.right != null) queue.Enqueue(ele.right);
            }
        }
        return root;
    }
}