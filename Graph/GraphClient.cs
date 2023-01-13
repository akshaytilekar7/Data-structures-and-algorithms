namespace Graph
{
    public class GraphClient
    {
        private static List<Edge> AddEdge(List<Edge> edges, int start, int end, int weight)
        {
            edges.Add(new Edge { VertexStart = start, VertexEnd = end, Weight = weight });
            return edges;
        }
        public static void Main()
        {
            int i;
            int[] V = { 1, 2, 3, 4 };
            List<Edge> E = new List<Edge>();

            E = AddEdge(E, 1, 2, 5);
            E = AddEdge(E, 2, 3, 1);
            E = AddEdge(E, 2, 4, 5);
            E = AddEdge(E, 3, 4, 1);

            GraphService graphService = new GraphService();
            AlgoDijkastra algoDijkastra = new AlgoDijkastra(graphService);
            AlgoPrims algoPrims = new AlgoPrims(graphService);
            AlgoKruskals algoKruskals = new AlgoKruskals(graphService);
            AlgoBellman algoBellman = new AlgoBellman(graphService);

            for (i = 0; i < V.Length; ++i)
                graphService.AddVertex(V[i]);

            for (i = 0; i < E.Count; ++i)
                graphService.AddEdge(E[i].VertexStart, E[i].VertexEnd, E[i].Weight);

            graphService.Print("Initial State:");

            Console.WriteLine("\nDFS");
            graphService.ResetColor();
            graphService.DFS(graphService.GetVerticleNode(1));

            Console.WriteLine("\nBFS");
            graphService.ResetColor();
            graphService.BFS(graphService.GetVerticleNode(1));

            algoDijkastra.RunAlog(1, 4);
            algoPrims.RunAlog(1);
            algoKruskals.RunAlog();
            algoBellman.RunAlog(1, 4);

            Console.WriteLine();

            Console.Write("\n************ C# END SUCCESS ************");
            Console.ReadLine();
        }
    }
}
