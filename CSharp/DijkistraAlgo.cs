
namespace GraphAlgo
{
    public class DijkistraAlgo
    {
        public Graph graph { get; }
        public GraphManagement graphManagement { get; }

        int infinity = 100;
        int singleSource = 0;
        public DijkistraAlgo(GraphManagement graphManagement)
        {
            graph = graphManagement.graph;
            this.graphManagement = graphManagement;
        }
        public void PrintShortestPath(int dest)
        {
            var src = graphManagement.SearchVertex(graph.VertexNode, dest);

            Console.WriteLine("\nDijkistraAlgo");
            Console.WriteLine("From vertex " + singleSource + " to " + dest);
            Console.WriteLine("Total Distance: " + src.Distance);
            Console.WriteLine("start");

            Stack<VerticleVertexNode> stack = new Stack<VerticleVertexNode>();

            while (src != null)
            {
                stack.Push(src);
                src = src.PrevShortest;
            }
            while (stack.Count != 0)
                Console.Write("->" + stack.Pop().Vertex);

            Console.WriteLine("\nend");

        }
        public void PrintAllShortestPaths()
        {
            for (VerticleVertexNode traverse = graph.VertexNode.Next; traverse != graph.VertexNode; traverse = traverse.Next)
                PrintShortestPath(traverse.Vertex);
        }
        public void Dijkistra(int src)
        {
            singleSource = src;
            var srcVertex = graphManagement.SearchVertex(graph.VertexNode, src);

            var pq = InitializeSingleSource(graph, srcVertex);

            while (pq.Count != 0)
            {
                var min = pq.PopMin();
                var traverse = min.LinkList.Next;
                while (traverse != min.LinkList)
                {
                    var adjNode = graphManagement.SearchVertex(graph.VertexNode, traverse.Vertex);
                    Relax(min, adjNode);
                    traverse = traverse.Next;
                }
            }

            pq.Clear();

        }
        private void Relax(VerticleVertexNode src, VerticleVertexNode dest)
        {
            var path = graphManagement.SearchNode(src.LinkList, dest.Vertex);

            if (dest.Distance > src.Distance + path.Weight)
            {
                dest.Distance = src.Distance + path.Weight;
                dest.PrevShortest = src;
            }
        }
        private List<VerticleVertexNode> InitializeSingleSource(Graph graph, VerticleVertexNode src)
        {
            List<VerticleVertexNode> pq = new List<VerticleVertexNode>();
            var traverse = graph.VertexNode.Next;
            while (traverse != graph.VertexNode)
            {
                traverse.PrevShortest = null;
                traverse.Distance = infinity;
                pq.Add(traverse);
                traverse = traverse.Next;
            }
            src.Distance = 0;
            return pq;
        }
    }
}
