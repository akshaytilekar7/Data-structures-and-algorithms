using AllCoreFiles.CSharp.GraphDSA.GraphManagement;

namespace AllCoreFiles.CSharp.GraphDSA.GraphAlgorithms
{
    public class Prims
    {
        private readonly GraphService _graphManagement;
        private const int Infinity = 1000;
        public Prims(GraphService graphManagement)
        {
            _graphManagement = graphManagement;
        }

        public void PrimsMST(int data)
        {
            var pq = InitilizeSingleSource(data);

            while (pq.Count != 0)
            {
                var src = pq.PopMin();
                var traverse = src.LinkList.Next;

                // src sagle neghbours / adj list in PQ madhe ahe - te CROSSING EDGES thartat
                // and we select least weight edge - which is safe edge - GMST
                while (traverse != src.LinkList)
                {
                    if (pq.Any(x => x.Vertex == traverse.Vertex)) // NEW
                    {
                        var dest = _graphManagement.SearchVertexNode(_graphManagement._graph.Root, traverse.Vertex);
                        Relax(src, dest, traverse.Weight);
                    }
                    traverse = traverse.Next;
                }
            }
            pq.Clear();
        }

        private static void Relax(VertexNode src, VertexNode dest, int weight)
        {
            if (dest.Distance > weight) // NEW 
            {
                dest.Predecessor = src;
                dest.Distance = weight;
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
        public void PrintPrims(int src)
        {
            var srcVertex = _graphManagement.SearchVertexNode(_graphManagement._graph.Root, src);

            Console.WriteLine("Vertices in spanning tree");
            Console.Write("[START]<.");
            for (var traverse = _graphManagement._graph.Root.Next; traverse != _graphManagement._graph.Root; traverse = traverse.Next)
                Console.Write("[" + traverse.Vertex + "]<.");
            Console.WriteLine("[END]");

            Console.Write("Edges in spanning tree");
            Console.Write("[START]<.");
            for (var traverse = _graphManagement._graph.Root.Next; traverse != _graphManagement._graph.Root; traverse = traverse.Next)
                if (traverse != srcVertex)
                    Console.Write("[" + traverse.Vertex + "-" + traverse.Predecessor.Vertex + "]<.");
            Console.WriteLine("[END]");
        }

    }
}
