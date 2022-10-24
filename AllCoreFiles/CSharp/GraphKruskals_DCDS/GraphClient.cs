using CSharp.DCDS;
using CSharp.WeightedGraphAlgo;

namespace CSharp.Graph
{
    public class GraphClient
    {
        public static void Main()
        {
            Console.Write("\nNEW NEW NEW");

            int i;
            int[] V = { 1, 2, 3, 4 };
            WeightedGraphAlgo.Edge[] E = {
                new WeightedGraphAlgo.Edge() { VertexStart = 1, VertexEnd = 2, Weight = 5 },
                new WeightedGraphAlgo.Edge() { VertexStart = 2, VertexEnd = 3, Weight = 5 },
                new WeightedGraphAlgo.Edge() { VertexStart = 2, VertexEnd = 4, Weight = 1 },
                new WeightedGraphAlgo.Edge() { VertexStart = 4, VertexEnd = 3, Weight = 1 }
            };

            GraphManagement graphManagement = new GraphManagement();

            for (i = 0; i < V.Length; ++i)
                graphManagement.AddVertex(V[i]);

            for (i = 0; i < E.Length; ++i)
                graphManagement.AddEdge(E[i].VertexStart, E[i].VertexEnd, E[i].Weight);

            graphManagement.Print("Initial State:");

            AlgoDijkistra dijkistraAlgo = new AlgoDijkistra(graphManagement);
            AlgoPrims primsAlgo = new AlgoPrims(graphManagement);
            AlgoKruskals algoKruskals = new AlgoKruskals(graphManagement);
            Console.WriteLine("FIND SHORTEST PATH FROM 3");

            dijkistraAlgo.FindShortestPathFrom(3);
            dijkistraAlgo.PrintShortestPathFrom(3, 1);
            dijkistraAlgo.PrintAllShortestPath(3);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("PRIMS 3");

            primsAlgo.Prims(3);
            primsAlgo.PrintPrims(3);

            Console.WriteLine("Algo Kruskals");
            var list = algoKruskals.kruskal();
            foreach (var item in list)
                Console.WriteLine(item.VertexStart + " - " + item.VertexEnd);


            Console.Write("\n************ C# END SUCCESS ************");
            Console.ReadLine();
        }
    }
}
