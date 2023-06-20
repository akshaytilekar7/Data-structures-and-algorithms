namespace Graph
{
    public class GraphService : GraphInfrastructure
    {
        public void AddVertex(int data)
        {
            graph.TotalVerticleVertex++;
            InsertVerticleNode(data);
        }
        public void RemoveVertex(int data)
        {
            var node = GetVerticleNode(data);

            var traverse = node.HorizontalLL.Next;
            while (traverse != node.HorizontalLL)
            {
                var tempTraverse = traverse.Next;
                var verticleNode = GetVerticleNode(traverse.DataNode);
                var nodeToBeDeleted = GetHorizontal(verticleNode.HorizontalLL, data);
                RemoveHorizontal(nodeToBeDeleted);
                graph.TotalHorizontalVertex--;
                traverse = tempTraverse;
            }
            RemoveVerticle(node);
            graph.TotalVerticleVertex--;

        }
        public void AddEdge(int verticleData, int HorizontalData, int weight)
        {
            var verticleNode1 = GetVerticleNode(verticleData);
            var verticleNode2 = GetVerticleNode(HorizontalData);

            if (verticleNode1 == null || verticleNode2 == null)
                throw new InvalidOperationException("Verticle node not exist");

            var edgeInVerticleNode1 = GetHorizontal(verticleNode1.HorizontalLL, HorizontalData);
            var edgeInVerticleNode2 = GetHorizontal(verticleNode2.HorizontalLL, verticleData);

            if (edgeInVerticleNode1 != null && edgeInVerticleNode2 != null)
                throw new InvalidOperationException("Horizontal node not exist");

            InsertAtEnd(verticleNode1.HorizontalLL, CreateHorizontalLL(HorizontalData, weight));
            InsertAtEnd(verticleNode2.HorizontalLL, CreateHorizontalLL(verticleData, weight));

            graph.TotalHorizontalVertex++;

        }
        public void RemoveEdge(int start, int end)
        {
            var startVerticle = GetVerticleNode(start);
            var endVerticle = GetVerticleNode(end);

            if (startVerticle == null || endVerticle == null)
                throw new ArgumentException("cant remove");

            var endNodeInStartVerticle = GetHorizontal(startVerticle.HorizontalLL, end);
            var startNodeInEndVerticle = GetHorizontal(endVerticle.HorizontalLL, start);

            if (endNodeInStartVerticle == null || startNodeInEndVerticle == null)
                throw new ArgumentException("cant remove edge is currupted");

            RemoveHorizontal(endNodeInStartVerticle);
            RemoveHorizontal(startNodeInEndVerticle);
            graph.TotalHorizontalVertex--;
        }
        public void Print(string message = "")
        {
            Console.WriteLine(message);
            Console.WriteLine("Total Verticle Vertex : " + graph.TotalVerticleVertex);
            Console.WriteLine("Total Horizontal Vertex : " + graph.TotalHorizontalVertex);

            Console.WriteLine(message);

            var traverse = graph.Head.Next;
            while (traverse != graph.Head)
            {
                Console.Write(traverse.DataNode + "  ->  ");
                PrintHorizontal(traverse.HorizontalLL);
                traverse = traverse.Next;
            }
        }
        public void DFS(VerticleLL verticle)
        {
            verticle.Color = Color.Visited;
            Console.Write(verticle.DataNode + "  ");

            var traverse = verticle.HorizontalLL.Next;
            while (traverse != verticle.HorizontalLL)
            {
                var tempVerticle = GetVerticleNode(traverse.DataNode);
                if (tempVerticle.Color == Color.Untouch)
                    DFS(tempVerticle);
                traverse = traverse.Next;
            }
        }
        public void BFS(VerticleLL verticle)
        {
            Console.WriteLine();
            Queue<VerticleLL> queue = new Queue<VerticleLL>();
            queue.Enqueue(verticle);
            verticle.Color = Color.Visited;

            while (queue.Count > 0)
            {
                var vert = queue.Dequeue();
                vert.Color = Color.Visited;
                Console.Write(vert.DataNode + "  ");
                var traverse = vert.HorizontalLL.Next;
                while (traverse != vert.HorizontalLL)
                {
                    var tempVerticle = GetVerticleNode(traverse.DataNode);
                    if (tempVerticle.Color == Color.Untouch && !queue.Contains(tempVerticle))
                        queue.Enqueue(tempVerticle);
                    traverse = traverse.Next;
                }
            }
        }
        public void BFSMoreRedable(int data = -1)
        {
            var vNode = data == -1 ? graph.Head : GetVerticleNode(data);
            Queue<VerticleLL> queue = new Queue<VerticleLL>();

            queue.Enqueue(vNode);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node.Color == Color.Untouch)
                {
                    node.Color = Color.Visited;
                    Console.Write($"   {node.DataNode}   ");
                }
                var traverse = node.HorizontalLL.Next;
                while (traverse != node.HorizontalLL)
                {
                    var vvNode = GetVerticleNode(traverse.DataNode);
                    if (vvNode.Color == Color.Untouch)
                        queue.Enqueue(vvNode);
                    traverse = traverse.Next;
                }
            }
            Console.WriteLine("BFS ");
        }
        public void ResetColor()
        {
            var traverse = graph.Head.Next;
            while (traverse != graph.Head)
            {
                traverse.Color = Color.Untouch;
                traverse = traverse.Next;
            }
        }
        private void PrintHorizontal(HorizontalLL horizontal)
        {
            var traverse = horizontal.Next;
            while (traverse != horizontal)
            {
                Console.Write("" + traverse.DataNode + "(" + traverse.Weight + ")" + "   ");
                traverse = traverse.Next;
            }
            Console.WriteLine();
        }
    }
}