using System;
using System.Collections.Generic;
using System.Linq;

namespace NewWayNaBhau
{
    public class Node
    {
        public string Data { get; set; }
        public Node Next { get; set; }

        public Node(string data, Node next = null)
        {
            Data = data;
            Next = next;
        }
    }

    public class FinalPractise
    {
        public Dictionary<string, Node> Graph { get; set; } = new Dictionary<string, Node>();

        public void AddNew(string current, string next)
        {
            if (!Graph.ContainsKey(current))
                Graph[current] = new Node(current);
            if (!Graph.ContainsKey(next))
                Graph[next] = new Node(next);
            Graph[current].Next = Graph[next];
        }

        public bool LinkedListIntersection(IEnumerable<string> arr)
        {
            // First, detect cycles in each list
            foreach (var listStart in arr)
            {
                if (Graph.TryGetValue(listStart, out var node))
                {
                    try
                    {
                        CycleDetection(node);
                    }
                    catch (InvalidOperationException ex) when (ex.Message == "Cycle detected.")
                    {
                        throw new InvalidOperationException("Cycle detected.");
                    }
                }
            }

            // Use a hash set to track visited nodes
            HashSet<Node> visitedNodes = new HashSet<Node>();

            foreach (var listStart in arr)
            {
                if (!Graph.TryGetValue(listStart, out var node))
                    continue;

                while (node != null)
                {
                    if (!visitedNodes.Add(node))
                        return true; 
                    node = node.Next;
                }
            }

            return false; 
        }

        private void CycleDetection(Node head)
        {
            if (head == null) return;

            var slow = head;
            var fast = head;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if (slow == fast)
                    throw new InvalidOperationException("Cycle detected.");
            }
        }
    }

    //public static class Program
    //{
    //    public static void Main()
    //    {
    //        try
    //        {
    //            var lines = new[] {
    //                "a->b",
    //                "r->s",
    //                "b->c",
    //                "x->c",
    //                "q->r",
    //                "y->x",
    //                "w->z",
    //                "a, q, w",
    //                "a, c, r",
    //                "y, z, a, r",
    //                "a, w"
    //            };

    //            var results = GraphTestMethod(lines);
    //            foreach (var result in results)
    //                Console.WriteLine(result);

    //            Console.WriteLine("end");
    //            Console.ReadLine();
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Exception: {ex.Message}");
    //        }
    //    }

    //    public static IEnumerable<string> GraphTestMethod(string[] lines)
    //    {
    //        FinalPractise graphManagement = new FinalPractise();

    //        foreach (var line in lines)
    //        {
    //            if (line.Contains(','))
    //            {
    //                string returnValue;

    //                try
    //                {
    //                    var nodes = line.Split(',').Select(v => v.Trim());
    //                    returnValue = graphManagement.LinkedListIntersection(nodes).ToString();
    //                }
    //                catch (InvalidOperationException ex) when (ex.Message == "Cycle detected.")
    //                {
    //                    returnValue = "Error Thrown!";
    //                }

    //                yield return returnValue;
    //            }
    //            else if (line.Contains("->"))
    //            {
    //                var splitStr = line.Split("->", StringSplitOptions.None);
    //                var current = splitStr[0].Trim();
    //                var next = splitStr[1].Trim();
    //                graphManagement.AddNew(current, next);
    //            }
    //        }
    //    }
    //}
}
