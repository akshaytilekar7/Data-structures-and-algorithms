namespace PracticeProject;

public class Node
{
    public string Data { get; set; }
    public Node Next { get; set; }
}
// TC O(n sqaure * L)
// where n is the number of lists, and L is the average length of the lists.
// This accounts for both intersection checks and cycle detection in the lists.
// SC O (n)
public class FinalPractise
{
    public Dictionary<string, Node> graph { get; set; } = new Dictionary<string, Node>();

    // TC and SC both are O(1) 
    public void AddNew(string current, string next)
    {
        if (!graph.ContainsKey(current))
            graph[current] = new Node() { Data = current };
        if (!graph.ContainsKey(next))
            graph[next] = new Node() { Data = next };
        graph[current].Next = graph[next];
    }

    // TC O(n Square * L)  considering cycle detection for each list and the nested intersection checks.
    // SC O (n)
    public bool LinkedListIntersection(IEnumerable<string> arr, Dictionary<string, Node> graph)
    {
        List<Node> nodes = arr.Select(x => graph[x]).ToList(); // IMP

        foreach (var node in nodes)
        {
            try
            {
                CycleDetection(node);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Cycle detected.")
                    throw new InvalidOperationException("Cycle detected.");
            }
        }


        // way 1 -  SC O (n) and TC O(n sqaure * L)
        for (int i = 0; i < nodes.Count; i++)
        {
            for (int j = i + 1; j < nodes.Count; j++)
            {
                var result = DoIntersect(nodes[i], nodes[j]);
                if (result) return true;
            }
        }

        // way 2
        var visitedNodes = new HashSet<Node>();
        foreach (var listStart in arr)
            if (graph.TryGetValue(listStart, out var node))
                if (HasIntersection(node, visitedNodes))
                    return true; 

        return false;
    }

    private bool HasIntersection(Node node, HashSet<Node> visitedNodes)
    {
        Node traverse = node;
        while (traverse != null)
        {
            if (visitedNodes.Contains(traverse))
                return true;
            visitedNodes.Add(traverse);
            traverse = traverse.Next;
        }
        return false; 
    }

    // TC (l + m)
    // SC O(1)
    private bool DoIntersect(Node head1, Node head2)
    {
        if (head1 == null) return false;
        if (head2 == null) return false;

        var ptrA = head1;
        var ptrB = head2;

        while (ptrA != ptrB)
        {
            ptrA = ptrA is null ? head2 : ptrA.Next;
            ptrB = ptrB is null ? head1 : ptrB.Next;
        }

        return ptrA != null;  // imp
    }


    // TC (n)
    // SC O(1)
    private void CycleDetection(Node head)
    {
        if (head is null) return;
        var slow = head;
        var fast = head;

        while (fast is not null && fast.Next is not null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
            if (slow == fast)
                throw new InvalidOperationException($"Cycle detected.");
        }
    }

}
