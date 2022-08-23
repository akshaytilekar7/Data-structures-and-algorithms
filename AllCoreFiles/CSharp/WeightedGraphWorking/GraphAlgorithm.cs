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
namespace GraphAlgo
{
    public class GraphAlgorithm
    {
        GraphManagement graphManagement = new GraphManagement();
        int SUCCESS = 1;
        int InvalidVertex = 4;
        int INFINITY = 50000;

        public void ResetColor(Graph graph)
        {
            VerticleVertexNode traverse = graph.VertexNode.Next;
            while (traverse != graph.VertexNode)
            {
                traverse.Color = Color.WHITE;
                traverse = traverse.Next;
            }
        }
        public int Dijkstra(Graph graph, int src)
        {
            VerticleVertexNode srcVertex = graphManagement.SearchVertex(graph.VertexNode, src);
            if (srcVertex == null)
                return InvalidVertex;

            // src to 0 and all other to infinity
            InitializeSingleSource(graph, srcVertex);

            // add all vertixes in prioroty queue
            List<VerticleVertexNode> priorityQueue = new List<VerticleVertexNode>();
            for (VerticleVertexNode traverse = graph.VertexNode.Next; traverse != graph.VertexNode; traverse = traverse.Next)
                priorityQueue.Add(traverse);

            while (priorityQueue.Count != 0)
            {
                // Pop min
                VerticleVertexNode min = priorityQueue.PopMin();
                for (HorizontalLinkListNode traverse = min.LinkList.Next; traverse != min.LinkList; traverse = traverse.Next)
                {
                    VerticleVertexNode dest = graphManagement.SearchVertex(graph.VertexNode, traverse.Vertex);
                    Relax(min, dest);
                }
            }
            priorityQueue.Clear();
            return SUCCESS;
        }
        public void PrintShortestPath(VerticleVertexNode vertexNode)
        {
            Stack<VerticleVertexNode> stack = new Stack<VerticleVertexNode>();
            int srcVertexNumber = vertexNode.Vertex;
            int srcVertexDistance = vertexNode.Distance;

            while (vertexNode != null)
            {
                stack.Push(vertexNode);
                vertexNode = vertexNode.PrevShortest;
            }

            Console.Write("Shortest path to [" + srcVertexNumber + "]\n");
            Console.Write("[BEGINNING]<.");
            while (stack.Count != 0)
                Console.Write("[" + stack.Pop().Vertex + "]<.");

            Console.Write("[COST:" + srcVertexDistance + "]\n");
            Console.WriteLine("[END]");

            stack.Clear();
        }
        public void PrintAllShortestPaths(Graph g)
        {
            for (VerticleVertexNode pv_node = g.VertexNode.Next; pv_node != g.VertexNode; pv_node = pv_node.Next)
                PrintShortestPath(pv_node);
        }
        void InitializeSingleSource(Graph graph, VerticleVertexNode src)
        {
            VerticleVertexNode traverse = graph.VertexNode.Next;
            while (traverse != graph.VertexNode)
            {
                traverse.Distance = INFINITY;
                traverse.PrevShortest = null;
                traverse = traverse.Next;
            }
            src.Distance = 0;
        }
        void Relax(VerticleVertexNode srcVertex, VerticleVertexNode destVetex)
        {
            HorizontalLinkListNode destNode = graphManagement.SearchNode(srcVertex.LinkList, destVetex.Vertex);

            if (destVetex.Distance > srcVertex.Distance + destNode.Weight)
            {
                destVetex.Distance = srcVertex.Distance + destNode.Weight;
                destVetex.PrevShortest = srcVertex;
            }
        }
        public void Prims(Graph graph, int src)
        {
            VerticleVertexNode srcVertex = graphManagement.SearchVertex(graph.VertexNode, src);

            List<VerticleVertexNode> priorityQueue = new List<VerticleVertexNode>();

            InitializeSingleSource(graph, srcVertex);

            for (VerticleVertexNode traverse = graph.VertexNode.Next; traverse != graph.VertexNode; traverse = traverse.Next)
                priorityQueue.Add(traverse);

            while (priorityQueue.Count != 0)
            {
                VerticleVertexNode vertexNode = priorityQueue.PopMin();

                // vertexNode sagle neghbours / adj list in PQ madhe ahe - te CROSSING EDGES thartat
                // and we select least weight edge - which is safe edge - GMST
                for (HorizontalLinkListNode traverse = vertexNode.LinkList.Next; traverse != vertexNode.LinkList; traverse = traverse.Next)
                {
                    if (priorityQueue.Any(x => x.Vertex == traverse.Vertex)) // NEW
                    {
                        var adjecencyListVertex = graphManagement.SearchVertex(graph.VertexNode, traverse.Vertex);
                        if (adjecencyListVertex.Distance > traverse.Weight) // NEW 
                        {
                            adjecencyListVertex.PrevShortest = vertexNode;
                            adjecencyListVertex.Distance = traverse.Weight;
                        }
                    }
                }
            }
            priorityQueue.Clear();
        }
        public void PrintMST(Graph graph, int src)
        {
            VerticleVertexNode srcVertex = graphManagement.SearchVertex(graph.VertexNode, src);

            Console.WriteLine("Vertices in spanning tree");
            Console.Write("[START]<.");
            for (VerticleVertexNode traverse = graph.VertexNode.Next; traverse != graph.VertexNode; traverse = traverse.Next)
                Console.Write("[" + traverse.Vertex + "]<.");
            Console.WriteLine("[END]");

            Console.Write("Edges in spanning tree");
            Console.Write("[START]<.");
            for (VerticleVertexNode traverse = graph.VertexNode.Next; traverse != graph.VertexNode; traverse = traverse.Next)
                if (traverse != srcVertex)
                    Console.Write("[" + traverse.Vertex + "-" + traverse.PrevShortest.Vertex + "]<.");
            Console.WriteLine("[END]");
        }
    }

    public static class Extention
    {
        public static VerticleVertexNode PopMin(this List<VerticleVertexNode> priorityQueue)
        {
            var min = priorityQueue.OrderBy(p => p.Distance).First();
            priorityQueue.Remove(min);
            return min;
        }
    }
}