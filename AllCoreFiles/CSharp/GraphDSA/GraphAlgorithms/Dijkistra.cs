using AllCoreFiles.CSharp.GraphDSA.GraphManagement;

namespace AllCoreFiles.CSharp.GraphDSA.GraphAlgorithms
{
    /*

    Dijkstras algorithm 
        is used only to find shortest path.

    Minimum Spanning tree (Prim's or Kruskal's algorithm) 
        get minimum egdes with minimum edge value.

    Prim [ w(u,v) ] and Dijkstra [ w(u,v) + u.key ] 
        algorithms are almost the same, except for the "relax function".

    GMST and MSTPrim
        MSTPrim ha GMST ahe
 
*/
    public class Dijkistra
    {
        private readonly GraphService _graphManagement;
        private const int Infinity = 1000;
        public Dijkistra(GraphService graphManagement)
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
