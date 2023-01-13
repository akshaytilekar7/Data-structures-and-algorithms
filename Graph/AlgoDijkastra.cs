namespace Graph
{
    public class AlgoDijkastra
    {
        private readonly GraphService graphService;

        int INFY = 10000;
        public AlgoDijkastra(GraphService graphService)
        {
            this.graphService = graphService;
        }

        public void RunAlog(int src, int dest)
        {
            Console.WriteLine("\n\nShortest Path by Dijkastra START");
            Dijkastra(src);
            Print(src, dest);
            Console.WriteLine("Shortest Path by Dijkastra END\n\n");
        }

        private List<VerticleLL> InitilizeSingleSource(int src)
        {
            List<VerticleLL> pq = new List<VerticleLL>();
            var verticle = graphService.GetVerticleNode(src);

            var traverse = graphService.graph.Head.Next;
            while (traverse != graphService.graph.Head)
            {
                traverse.Predecessor = null;
                traverse.Distance = INFY;
                pq.Add(traverse);
                traverse = traverse.Next;
            }

            verticle.Distance = 0;
            return pq;
        }

        private void Dijkastra(int data)
        {
            var pq = InitilizeSingleSource(data);

            while (pq.Count != 0)
            {
                var src = pq.PopMin();
                var traverse = src.HorizontalLL.Next;
                while (traverse != src.HorizontalLL)
                {
                    var dest = graphService.GetVerticleNode(traverse.DataNode);
                    Relax(src, dest, traverse.Weight);
                    traverse = traverse.Next;
                }
            }
        }

        private void Relax(VerticleLL src, VerticleLL dest, int distanceSrcToDist)
        {
            if (dest.Distance > src.Distance + distanceSrcToDist)
            {
                dest.Distance = src.Distance + distanceSrcToDist;
                dest.Predecessor = src;
            }
        }

        public void Print(int src, int dest)
        {
            var destVertex = graphService.GetVerticleNode(dest);

            Console.WriteLine("Total Cost from [" + src + "] to [" + dest + "] : " + destVertex.Distance);
            Console.Write(" START ");

            Stack<VerticleLL> stack = new Stack<VerticleLL>();
            while (destVertex != null)
            {
                stack.Push(destVertex);
                destVertex = destVertex.Predecessor;
            }

            while (stack.Count != 0)
                Console.Write("->" + stack.Pop().DataNode);

            Console.Write(" END \n");
        }
    }

    public static class Extentions
    {
        public static VerticleLL PopMin(this List<VerticleLL> priorityQueue)
        {
            var min = priorityQueue.OrderBy(p => p.Distance).First();
            priorityQueue.Remove(min);
            return min;
        }
    }
}
