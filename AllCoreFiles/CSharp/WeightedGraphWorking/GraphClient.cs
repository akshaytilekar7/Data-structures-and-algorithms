namespace GraphAlgo
{
    public class GraphTest
    {
        static void Main(string[] args)
        {
            int i;

            int[] V = { 1, 2, 3, 4 };
            Edge[] E = {
                new Edge() { VertexStart = 1, VertexEnd = 2, Weight = 5 },
                new Edge() { VertexStart = 2, VertexEnd = 3, Weight = 5 },
                new Edge() { VertexStart = 2, VertexEnd = 4, Weight = 1 },
                new Edge() { VertexStart = 4, VertexEnd = 3, Weight = 1 }
            };

            GraphManagement graphManagement = new GraphManagement();
            Graph graph = graphManagement.CreateGraph();

            for (i = 0; i < 4; ++i)
                graphManagement.AddVertex(graph, V[i]);

            for (i = 0; i < 4; ++i)
                graphManagement.AddEdge(graph, E[i].VertexStart, E[i].VertexEnd, E[i].Weight);

            graphManagement.Print(graph, "Initial State:");
            Console.WriteLine("TotalVertex " + graph.TotalVertex);
            Console.WriteLine("TotalEdges " + graph.TotalEdges);

            GraphAlgorithm graphAlgorithm = new GraphAlgorithm();
            
            var destVer = graphManagement.SearchVertex(graph.VertexNode, 3);
            graphAlgorithm.Dijkstra(graph, destVer.Vertex);
            var srcVer = graphManagement.SearchVertex(graph.VertexNode, 1);
            graphAlgorithm.PrintShortestPath(srcVer);
            //graphAlgorithm.PrintAllShortestPaths(graph);

            //graphAlgorithm.Prims(graph, 1);
            //graphAlgorithm.PrintMST(graph, 1);

            Console.Write("\n########### END SUCCESS #$$$$$$$$$$$");

        }
    }
}
