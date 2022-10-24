namespace CSharp.WeightedGraphAlgo
{
    public class AlgoDijkistra
    {
        private readonly GraphManagement _graphManagement;
        private const int Infinity = 1000;
        public AlgoDijkistra(GraphManagement graphManagement)
        {
            _graphManagement = graphManagement;
        }

        public void FindShortestPathFrom(int data)
        {
            var pq = InitilizeSingleSource(data);

            while (pq.Count() != 0)
            {
                var src = pq.PopMin();
                var traverse = src.LinkList.Next;
                while (traverse != src.LinkList)
                {
                    var dest = _graphManagement.SearchVertexNode(_graphManagement._graph.Root, traverse.Vertex);
                    Relax(src, dest, traverse.Weight);
                    traverse = traverse.Next;
                }
            }
        }
        private List<VertexNode> InitilizeSingleSource(int src)
        {
            List<VertexNode> pq = new List<VertexNode>();
            var srcVertex = _graphManagement.SearchVertexNode(_graphManagement._graph.Root, src);

            var traverse = _graphManagement._graph.Root.Next;
            while (traverse != _graphManagement._graph.Root)
            {
                traverse.Distance = Infinity;
                traverse.Predecessor = null;
                pq.Add(traverse);
                traverse = traverse.Next;
            }
            srcVertex.Distance = 0;
            return pq;
        }
        private void Relax(VertexNode src, VertexNode dest, int weight)
        {
            if (dest.Distance > src.Distance + weight)
            {
                dest.Distance = src.Distance + weight;
                dest.Predecessor = src;
            }
        }
        public void PrintShortestPathFrom(int src, int dest)
        {
            var destVertex = _graphManagement.SearchVertexNode(_graphManagement._graph.Root, dest);

            Console.WriteLine("Total Cost from [" + src + "] to [" + dest + "] : " + destVertex.Distance);
            Console.Write(" START ");

            Stack<VertexNode> stack = new Stack<VertexNode>();
            while (destVertex != null)
            {
                stack.Push(destVertex);
                destVertex = destVertex.Predecessor;
            }

            while (stack.Count != 0)
                Console.Write("->" + stack.Pop().Vertex);

            Console.Write(" END \n");
        }
        public void PrintAllShortestPath(int src)
        {
            for (var traverse = _graphManagement._graph.Root.Next; traverse != _graphManagement._graph.Root; traverse = traverse.Next)
                PrintShortestPathFrom(src, traverse.Vertex);
        }
    }

    public static class Extentions
    {
        public static VertexNode PopMin(this List<VertexNode> priorityQueue)
        {
            var min = priorityQueue.OrderBy(p => p.Distance).First();
            priorityQueue.Remove(min);
            return min;
        }
    }
}
