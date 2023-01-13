using AllCoreFiles.CSharp.GraphDSA.GraphAlgorithms;

namespace AllCoreFiles.CSharp.GraphDSA.GraphManagement
{
    public class GraphClient
    {
        public static void Main()
        {
            Console.Write("\nNEW NEW NEW");

            int i;
            int[] V = { 1, 2, 3, 4 };
            Edge[] E = {
                new Edge() { VertexStart = 1, VertexEnd = 2, Weight = 5 },
                new Edge() { VertexStart = 2, VertexEnd = 3, Weight = 1 },
                new Edge() { VertexStart = 2, VertexEnd = 4, Weight = 5 },
                new Edge() { VertexStart = 4, VertexEnd = 3, Weight = 1 }
            };

            GraphService graphManagement = new GraphService();

            for (i = 0; i < V.Length; ++i)
                graphManagement.AddVertex(V[i]);

            for (i = 0; i < E.Length; ++i)
                graphManagement.AddEdge(E[i].VertexStart, E[i].VertexEnd, E[i].Weight);

            graphManagement.Print("Initial State:");

            Dijkistra dijkistraAlgo = new Dijkistra(graphManagement);
            Prims primsAlgo = new Prims(graphManagement);
            Kruskals algoKruskals = new Kruskals(graphManagement);
            Console.WriteLine("FIND SHORTEST PATH FROM 3");

            //dijkistraAlgo.FindShortestPathFrom(3);
            //dijkistraAlgo.PrintShortestPathFrom(3, 1);
            //dijkistraAlgo.PrintAllShortestPath(3);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //Console.WriteLine("PRIMS 3");
            //primsAlgo.GenerateMSTByPrims(3);
            //primsAlgo.Print(3);

            Console.WriteLine("Algo Kruskals");
            var list = algoKruskals.kruskal();
            foreach (var item in list)
                Console.WriteLine(item.VertexStart + " - " + item.VertexEnd);


            Console.Write("\n************ C# END SUCCESS ************");
            Console.ReadLine();
        }
    }
}
