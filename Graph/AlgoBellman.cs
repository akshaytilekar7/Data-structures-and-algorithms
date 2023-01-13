namespace Graph
{
    // not sure about working
    public class AlgoBellman
    {
        private readonly GraphService graphService;

        int INFY = int.MaxValue;
        public AlgoBellman(GraphService graphService)
        {
            this.graphService = graphService;
        }

        public void RunAlog(int src, int dest)
        {
            Console.WriteLine("\n\nShortest Path by Bellman START");
            var isValid = Bellman(src);

            if (isValid)
                Print(src, dest);
            else
                Console.WriteLine("Negative cycle exist, cant proceeds further");

            Console.WriteLine("Shortest Path by Bellman END\n\n");
        }

        public bool Bellman(int startNode)
        {
            var verticleNode = graphService.GetVerticleNode(startNode);
            var pq = InitilizeSingleSource(verticleNode);

            while (pq.Count() != 0)
            {
                var src = pq.PopMin();

                var traverse = src.HorizontalLL.Next;
                while (traverse != src.HorizontalLL)
                {
                    if (pq.Any(x => x.DataNode == traverse.DataNode))
                    {
                        var dest = graphService.GetVerticleNode(traverse.DataNode);
                        Relax(src, dest, traverse.Weight);
                    }
                    traverse = traverse.Next;
                }
            }

            var edges = graphService.GetEdgesByDescendingOrder();

            // main new addtion
            foreach (var edge in edges)
            {
                var vertexStart = graphService.GetVerticleNode(edge.VertexStart);
                var vertexEnd = graphService.GetVerticleNode(edge.VertexEnd);

                if (vertexEnd.Distance > vertexStart.Distance + edge.Weight)
                {
                    Console.WriteLine("Graph contains negative weight cycle");
                    return false;
                }
            }
            return true;
        }

        private void Relax(VerticleLL src, VerticleLL dest, int distanceSrcToDist)
        {
            if (dest.Distance > src.Distance + distanceSrcToDist)
            {
                dest.Distance = src.Distance + distanceSrcToDist;
                dest.Predecessor = src;
            }
        }

        private List<VerticleLL> InitilizeSingleSource(VerticleLL src)
        {
            List<VerticleLL> pq = new List<VerticleLL>();

            var traverse = graphService.graph.Head.Next;
            while (traverse != graphService.graph.Head)
            {
                traverse.Predecessor = null;
                traverse.Distance = INFY;
                pq.Add(traverse);
                traverse = traverse.Next;
            }
            src.Distance = 0;

            return pq;
        }

        public void Print(int src, int dest)
        {
            var destVertex = graphService.GetVerticleNode(dest);

            Console.WriteLine("Total Cost from [" + src + "] to [" + dest + "] : " + destVertex.Distance);
            Console.Write(" START ");

            Stack<VerticleLL> stack = new Stack<VerticleLL>();
            while (destVertex != null)
            {
                stack.Push(destVertex);
                destVertex = destVertex.Predecessor;
            }

            while (stack.Count != 0)
                Console.Write("->" + stack.Pop().DataNode);

            Console.Write(" END \n");
        }
    }
}
