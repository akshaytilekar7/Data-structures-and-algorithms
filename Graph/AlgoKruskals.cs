namespace Graph
{
    public class AlgoKruskals
    {
        private readonly GraphService graphService;
        private readonly DcdsService dcdsService;
        public AlgoKruskals(GraphService graphService)
        {
            this.graphService = graphService;
            dcdsService = new DcdsService();
        }
        public void RunAlog()
        {
            Console.WriteLine("\n\nMST by Kruskals DCDS START");
            var edges = Kruskals();
            Print(edges);
            Console.WriteLine("MST by Kruskals DCDS END\n\n");
        }

        private List<Edge> Kruskals()
        {
            // order by desc, safe edge with min weight appears first
            var edges = graphService.GetEdgesByDescendingOrder();
            List<Edge> resultEdges = new List<Edge>();

            var travels = graphService.graph.Head.Next;
            while (travels != graphService.graph.Head)
            {
                dcdsService.Create(travels.DataNode);
                travels = travels.Next;
            }

            foreach (var edge in edges)
            {
                var vertexStartEndpointSet = dcdsService.GetSetByValue(edge.VertexStart);
                var vertexEndEndpointSet = dcdsService.GetSetByValue(edge.VertexEnd);

                // not equal means, its a crossing edge so make union
                if (vertexStartEndpointSet != vertexEndEndpointSet)
                {
                    dcdsService.MakeUnion(vertexStartEndpointSet.Pk, vertexEndEndpointSet.Pk);
                    resultEdges.Add(edge);
                }
            }
            return resultEdges;
        }

        private void Print(List<Edge> edges)
        {
            foreach (var edge in edges)
                Console.WriteLine(edge.VertexStart + " -  " + edge.VertexEnd + "[" + edge.Weight + "]");
            Console.WriteLine("Total Sum " + edges.Sum(x => x.Weight));
        }
    }
}
