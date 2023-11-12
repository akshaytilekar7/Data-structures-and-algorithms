namespace SegmentTree;

public class SegmentTree
{
    Node root;
    public SegmentTree(int[] arr)
    {
        this.root = ConstructTree(arr, 0, arr.Length - 1);
    }
    private Node ConstructTree(int[] arr, int start, int end)
    {
        if (start == end) // means u r at leaf node
        {
            Node leafNode = new Node(start, end);
            leafNode.Data = arr[start];
            return leafNode;
        }

        Node node = new Node(start, end);

        int mid = (start + end) / 2;

        node.Left = this.ConstructTree(arr, start, mid);
        node.Right = this.ConstructTree(arr, mid + 1, end);
        node.Data = node.Left.Data + node.Right.Data;
        
        return node;
    }
    public void Display()
    {
        Display(root);
    }
    private void Display(Node node)
    {
        string str = string.Empty;

        if (node.Left != null)
            str = str + "Interval=[" + node.Left.StartInterval + "-" + node.Left.EndInterval + "] and data: " + node.Left.Data + " => ";
        else
            str = str + "No left child";

        str = str + "Interval=[" + node.StartInterval + "-" + node.EndInterval + "] and data: " + node.Data + " <= ";

        if (node.Right != null)
            str = str + "Interval=[" + node.Right.StartInterval + "-" + node.Right.EndInterval + "] and data: " + node.Right.Data;
        else
            str = str + "No right child";

        Console.WriteLine(str + '\n');

        if (node.Left != null)
            Display(node.Left);

        if (node.Right != null)
            Display(node.Right);
    }
    public int Query(int qStartInterval, int qEndInterval)
    {
        return this.Query(this.root, qStartInterval, qEndInterval);
    }
    private int Query(Node node, int qStartInterval, int qEndInterval)
    {
        if (node.StartInterval >= qStartInterval && node.EndInterval <= qEndInterval) // node is completely lying inside query
            return node.Data;  
        else if (node.StartInterval > qEndInterval || node.EndInterval < qStartInterval) // completely outside
            return 0;    
        else
            return this.Query(node.Left, qStartInterval, qEndInterval)  // Overlapping
                + this.Query(node.Right, qStartInterval, qEndInterval);
    }
    public void Update(int index, int value)
    {
        this.root.Data = Update(this.root, index, value);
    }
    private int Update(Node node, int index, int value)
    {
        if (index >= node.StartInterval && index <= node.EndInterval)  // node is completely lying inside query
        {
            if (index == node.StartInterval && index == node.EndInterval)
            {
                node.Data = value;
                return node.Data;
            }
            else
            {
                int leftAns = Update(node.Left, index, value);
                int rightAns = Update(node.Right, index, value);
                node.Data = leftAns + rightAns;
                return node.Data;
            }
        }
        return node.Data;
    }
}
