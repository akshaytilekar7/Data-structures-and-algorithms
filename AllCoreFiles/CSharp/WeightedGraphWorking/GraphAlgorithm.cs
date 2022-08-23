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
            VertexNode traverse = graph.VertexNode.Next;
            while (traverse != graph.VertexNode)
            {
                traverse.Color = Color.WHITE;
                traverse = traverse.Next;
            }
        }
        public int Dijkstra(Graph graph, int src)
        {
            VertexNode srcVertex = graphManagement.SearchVertex(graph.VertexNode, src);
            if (srcVertex == null)
                return InvalidVertex;

            InitializeSingleSource(graph, srcVertex);

            List<VertexNode> priorityQueue = new List<VertexNode>();
            for (VertexNode traverse = graph.VertexNode.Next; traverse != graph.VertexNode; traverse = traverse.Next)
                priorityQueue.Add(traverse);

            while (priorityQueue.Count != 0)
            {
                VertexNode vertexNode = priorityQueue.PopMin();
                for (LinkListNode traverse = vertexNode.LinkList.Next; traverse != vertexNode.LinkList; traverse = traverse.Next)
                {
                    VertexNode adjecencyListVertex = graphManagement.SearchVertex(graph.VertexNode, traverse.Vertex);
                    Relax(vertexNode, adjecencyListVertex);
                }
            }
            priorityQueue.Clear();
            return (SUCCESS);
        }
        public void PrintShortestPath(Graph g, VertexNode pv_node)
        {
            Stack<VertexNode> pvq_stack = new Stack<VertexNode>();
            int curr_vertex_number = pv_node.Vertex;
            double d = pv_node.Distance;

            while (pv_node != null)
            {
                pvq_stack.Push(pv_node);
                pv_node = pv_node.UPrev;
            }

            Console.Write("Shortest path to [" + curr_vertex_number + "]\n");
            Console.Write("[BEGINNING]<.");
            while (pvq_stack.Count != 0)
            {
                VertexNode pv_poped_node = pvq_stack.Pop();
                Console.Write("[" + pv_poped_node.Vertex + "]<.");
            }
            Console.Write("[COST:" + d + "]\n");
            Console.WriteLine("[END]");

            pvq_stack.Clear();
        }
        public void PrintAllShortestPaths(Graph g)
        {
            for (VertexNode pv_node = g.VertexNode.Next; pv_node != g.VertexNode; pv_node = pv_node.Next)
                PrintShortestPath(g, pv_node);
        }
        void InitializeSingleSource(Graph graph, VertexNode src)
        {
            VertexNode pv_run = graph.VertexNode.Next;
            while (pv_run != graph.VertexNode)
            {
                pv_run.Distance = INFINITY;
                pv_run.UPrev = null;
                pv_run = pv_run.Next;
            }
            src.Distance = 0;
        }
        void Relax(VertexNode src, VertexNode dest)
        {
            LinkListNode node = graphManagement.SearchNode(src.LinkList, dest.Vertex);
            int weight = node.Weight;

            if (dest.Distance > src.Distance + weight)
            {
                dest.Distance = src.Distance + weight;
                dest.UPrev = src;
            }
        }
        public void Prims(Graph graph, int src)
        {
            VertexNode srcVertex = graphManagement.SearchVertex(graph.VertexNode, src);

            List<VertexNode> priorityQueue = new List<VertexNode>();

            InitializeSingleSource(graph, srcVertex);

            for (VertexNode traverse = graph.VertexNode.Next; traverse != graph.VertexNode; traverse = traverse.Next)
                priorityQueue.Add(traverse);

            while (priorityQueue.Count != 0)
            {
                VertexNode vertexNode = priorityQueue.PopMin();

                // vertexNode sagle neghbours / adj list in PQ madhe ahe - te CROSSING EDGES thartat
                // and we select least weight edge - which is safe edge - GMST
                for (LinkListNode traverse = vertexNode.LinkList.Next; traverse != vertexNode.LinkList; traverse = traverse.Next)
                {
                    if (priorityQueue.Any(x => x.Vertex == traverse.Vertex)) // NEW
                    {
                        var adjecencyListVertex = graphManagement.SearchVertex(graph.VertexNode, traverse.Vertex);
                        if (adjecencyListVertex.Distance > traverse.Weight) // NEW 
                        {
                            adjecencyListVertex.UPrev = vertexNode;
                            adjecencyListVertex.Distance = traverse.Weight;
                        }
                    }
                }
            }
            priorityQueue.Clear();
        }
        public void PrintMST(Graph graph, int src)
        {
            VertexNode srcVertex = graphManagement.SearchVertex(graph.VertexNode, src);

            Console.WriteLine("Vertices in spanning tree");
            Console.Write("[START]<.");
            for (VertexNode traverse = graph.VertexNode.Next; traverse != graph.VertexNode; traverse = traverse.Next)
                Console.Write("[" + traverse.Vertex + "]<.");
            Console.WriteLine("[END]");

            Console.Write("Edges in spanning tree");
            Console.Write("[START]<.");
            for (VertexNode traverse = graph.VertexNode.Next; traverse != graph.VertexNode; traverse = traverse.Next)
                if (traverse != srcVertex)
                    Console.Write("[" + traverse.Vertex + "-" + traverse.UPrev.Vertex + "]<.");
            Console.WriteLine("[END]");
        }
    }

    public static class Extention
    {
        public static VertexNode PopMin(this List<VertexNode> priorityQueue)
        {
            var min = priorityQueue.OrderBy(p => p.Distance).First();
            priorityQueue.Remove(min);
            return min;
        }
    }
}