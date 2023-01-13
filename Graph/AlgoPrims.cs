namespace Graph
{
    public class AlgoPrims
    {
        private readonly GraphService graphService;

        public AlgoPrims(GraphService graphService)
        {
            this.graphService = graphService;
        }

        public void RunAlog(int src)
        {
            Console.WriteLine("\n\nMST by PRIMS START");
            GenerateMstByPrims(src);
            Print(src);
            Console.WriteLine("MST by PRIMS END\n\n");
        }

        public void GenerateMstByPrims(int startNode)
        {
            var verticleNode = graphService.GetVerticleNode(startNode);
            var pq = InitilizeSingleSource(verticleNode);

            while (pq.Count() != 0)
            {
                var src = pq.PopMin();

                var traverse = src.HorizontalLL.Next;
                while (traverse != src.HorizontalLL)
                {
                    if (pq.Any(x => x.DataNode == traverse.DataNode))
                    {
                        var dest = graphService.GetVerticleNode(traverse.DataNode);
                        Relax(src, dest, traverse.Weight);
                    }
                    traverse = traverse.Next;
                }
            }
        }

        private void Relax(VerticleLL src, VerticleLL dest, int srcToDestDist)
        {
            if (dest.Distance > srcToDestDist)
            {
                dest.Distance = srcToDestDist;
                dest.Predecessor = src;
            }
        }

        private List<VerticleLL> InitilizeSingleSource(VerticleLL src)
        {
            List<VerticleLL> pq = new List<VerticleLL>();

            var traverse = graphService.graph.Head.Next;
            while (traverse != graphService.graph.Head)
            {
                traverse.Predecessor = null;
                traverse.Distance = 5000;
                pq.Add(traverse);
                traverse = traverse.Next;
            }
            src.Distance = 0;

            return pq;
        }

        public void Print(int src)
        {
            var srcVertex = graphService.GetVerticleNode(src);
            
            Console.WriteLine("Vertices in spanning tree");
            Console.Write("[START]<.");
            var traverse = graphService.graph.Head.Next;
            while (traverse != graphService.graph.Head)
            {
                Console.Write("[" + traverse.DataNode + "]<.");
                traverse = traverse.Next;
            }
            Console.WriteLine("[END]");


            Console.Write("Edges in spanning tree");
            Console.Write("[START]<.");

            traverse = graphService.graph.Head.Next;
            while (traverse != graphService.graph.Head)
            {
                if (traverse != srcVertex)
                    Console.Write("[" + traverse.DataNode + "-" + traverse.Predecessor.DataNode + "]<.");
                traverse = traverse.Next;
            }
            Console.WriteLine("[END]");

        }

    }
}
