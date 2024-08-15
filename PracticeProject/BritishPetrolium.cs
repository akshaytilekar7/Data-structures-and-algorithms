using static System.Net.Mime.MediaTypeNames;

namespace BritishPetrolium;

public class Node
{
    public string Data { get; set; }
    public Node Next { get; set; }
    public Node() { }
    public Node(string id, Node next = null)
    {
        Data = id;
        Next = next;
    }
}
public class GraphManagement
{
    public Dictionary<string, Node> graph { get; set; } = new Dictionary<string, Node>();
    public void AddNew(string current, string next)
    {
        if (!graph.ContainsKey(current))
            graph[current] = new Node() { Data = current };
        if (!graph.ContainsKey(next))
            graph[next] = new Node() { Data = next };
        graph[current].Next = graph[next];
    }
    private bool Intersect(Node head1, Node head2)
    {
        HashSet<Node> nodes = new HashSet<Node>();
        var traverse = head1;
        while (traverse != null)
        {
            nodes.Add(traverse);
            traverse = traverse.Next;
        }

        traverse = head2;
        while (traverse is not null)
        {
            if (nodes.Contains(traverse))
                return true;
            traverse = traverse.Next;
        }
        return false;
    }
    private void CycleChek(Node head)
    {
        var slow = head;
        var fast = head;
        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;

            if (slow == fast)
                throw new InvalidOperationException("Cycle detected");
        }
    }
    public bool LinkedListIntersection(IEnumerable<string> arr, Dictionary<string, Node> graph)
    {
        List<Node> vertexes = arr.Select(x => graph[x]).ToList();

        for (int i = 0; i < vertexes.Count; i++)
        {
            for (int j = i + 1; j < vertexes.Count; j++)
            {
                if (Intersect(vertexes[i], vertexes[j]))
                    return true;
            }
        }
        return false;
    }


}
