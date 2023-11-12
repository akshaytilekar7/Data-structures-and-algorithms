namespace SegmentTree;

public class Node
{
    public int Data { get; set; }
    public int StartInterval { get; set; }
    public int EndInterval { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public Node(int startInterval, int endInterval)
    {
        this.StartInterval = startInterval;
        this.EndInterval = endInterval;
    }
}
