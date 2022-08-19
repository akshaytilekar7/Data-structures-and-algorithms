namespace GraphAlgo
{
    public class GraphTest
    {
        static void Main(string[] args)
        {
            int i;
            GraphServer graphServer = new GraphServer();

            int[] V = { 1, 2, 3, 4 };
            Edge[] E = {
                new Edge() { VertexStart = 1, VertexEnd = 2, Weight = 5 },
                new Edge() { VertexStart = 2, VertexEnd = 3, Weight = 5 },
                new Edge() { VertexStart = 2, VertexEnd = 4, Weight = 1 },
                new Edge() { VertexStart = 4, VertexEnd = 3, Weight = 1 }
            };

            Graph graph = graphServer.CreateGraph();

            for (i = 0; i < 4; ++i)
                graphServer.AddVertex(graph, V[i]);

            for (i = 0; i < 4; ++i)
                graphServer.AddEdge(graph, E[i].VertexStart, E[i].VertexEnd, E[i].Weight);

            graphServer.Print(graph, "Initial State:");
            Console.WriteLine("TotalVertex " + graph.TotalVertex);
            Console.WriteLine("TotalEdges " + graph.TotalEdges);

            //graphServer.Dijkstra(graph, 1);
            //graphServer.PrintAllShortestPaths(graph);

            graphServer.Prims(graph, 1);
            graphServer.PrintMST(graph, 1);

            Console.Write("\n########### END SUCCESS #");

        }
    }
}
