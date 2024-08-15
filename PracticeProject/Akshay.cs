using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A;

public class Node
{
    public string Data { get; set; }
    public Node Next { get; set; }
}
public class Akshay
{
    public Dictionary<string, Node> graph { get; set; } = new Dictionary<string, Node>();
    public bool LinkedListIntersection(IEnumerable<string> arr, Dictionary<string, Node> graph)
    {
        List<Node> nodes = arr.Select(x => graph[x]).ToList();

        foreach (Node node in nodes)
        {
            try
            {
                CycelCheck(node);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Cycle Detected");
            }
        }

        //for (int i = 0; i < nodes.Count; i++)
        //{
        //    for (int j = i + 1; j < nodes.Count; j++)
        //    {
        //        if (Intersction(nodes[i], nodes[j]))
        //            return true;
        //    }
        //}
        HashSet<Node> visited = new HashSet<Node>();
        foreach (Node node in nodes)
        {
            var traverse = node;
            while (traverse != null)
            {
                if (visited.Contains(traverse))
                    return true;
                visited.Add(traverse);
                traverse = traverse.Next;
            }
        }
        return false;
    }

    public void AddNew(string cuurent, string next)
    {
        if (!graph.ContainsKey(cuurent))
            graph.Add(cuurent, new Node() { Data = cuurent });
        if (!graph.ContainsKey(next))
            graph.Add(next, new Node() { Data = next });
        graph[cuurent].Next = graph[next];
    }

    public void CycelCheck(Node head)
    {
        if (head == null) return;
        var slow = head;
        var fast = head;

        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
            if (fast == slow)
                throw new InvalidOperationException("No valied");
        }
    }

    public bool Intersction(Node head1, Node head2)
    {
        if (head1 is null) return false;
        if (head2 is null) return false;

        var ptrA = head1;
        var ptrB = head2;

        while (ptrA != ptrB)
        {
            ptrA = ptrA is null ? head2 : ptrA.Next;
            ptrB = ptrB is null ? head1 : ptrB.Next;
        }

        return ptrA != null;
    }

}
