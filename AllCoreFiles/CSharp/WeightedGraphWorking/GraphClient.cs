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

            for (i = 0; i < 4; ++i)
                graphManagement.AddVertex(V[i]);

            for (i = 0; i < 4; ++i)
                graphManagement.AddEdge(E[i].VertexStart, E[i].VertexEnd, E[i].Weight);

            graphManagement.Print("Initial State:");

            DijkistraAlgo dijkistraAlgo = new DijkistraAlgo(graphManagement);

            dijkistraAlgo.Dijkistra(3);
            dijkistraAlgo.PrintAllShortestPaths();

            Console.Write("\n########### END SUCCESS #$$$$$$$$$$$");

        }
    }
}
