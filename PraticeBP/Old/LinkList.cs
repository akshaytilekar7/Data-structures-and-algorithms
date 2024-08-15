namespace PraticeBP.Old;

public class Node
{
    public string Data { get; set; }
    public Node Next { get; set; }
}

public class LinkListMine
{
    public Dictionary<string, Node> graph { get; set; } = new Dictionary<string, Node>();

    // TC O(n) SC O(1)
    public void CycleDetect(Node head)
    {
        if (head is null) return;

        var slow = head;
        var fast = head;

        while (fast is not null && fast.Next is not null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
            if (slow == fast)
                throw new InvalidOperationException("Cycle detected");
        }
    }

    // TC O(1)  SC O(1) 
    public void Add(string current, string next)
    {
        if (!graph.ContainsKey(current))
            graph[current] = new Node() { Data = current };
        if (!graph.ContainsKey(next))
            graph[next] = new Node() { Data = next };
        graph[current].Next = graph[next];
    }

    // SC O(n) TC O(len * input)
    public bool LinkedListIntersection(List<string> arr)
    {
        List<Node> nodes = arr.Select(x => graph[x]).ToList();

        foreach (var n in nodes)
            CycleDetect(n);

        HashSet<Node> visited = new HashSet<Node>();

        foreach (var n in nodes)
        {
            var traverse = n;
            while (traverse is not null)
            {
                if (visited.Contains(traverse))
                    return true;
                visited.Add(traverse);
                traverse = traverse.Next;
            }
        }
        return false;
    }


}
