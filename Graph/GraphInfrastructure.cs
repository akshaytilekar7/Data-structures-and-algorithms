namespace Graph
{
    public class GraphInfrastructure
    {
        public readonly Graph graph;
        public GraphInfrastructure()
        {
            graph = new Graph();
            graph.Head = CreateVerticleLL(-1);
        }
        protected VerticleLL CreateVerticleLL(int data)
        {
            VerticleLL verticle = new VerticleLL();
            verticle.Next = verticle;
            verticle.Prev = verticle;
            verticle.DataNode = data;
            verticle.Color = Color.Untouch;
            verticle.HorizontalLL = CreateHorizontalLL(-1, 0);
            return verticle;
        }
        protected HorizontalLL CreateHorizontalLL(int data, int weight)
        {
            HorizontalLL horizontal = new HorizontalLL();
            horizontal.Next = horizontal;
            horizontal.Prev = horizontal;
            horizontal.DataNode = data;
            horizontal.Weight = weight;
            return horizontal;
        }
        public void InsertVerticleNode(int data)
        {
            if (IsExistInVerticle(data))
                throw new Exception("Node already exist");
            InsertAtEnd(graph.Head, data);
        }
        public VerticleLL GetVerticleNode(int data)
        {
            var traverse = graph.Head.Next;
            while (traverse != graph.Head)
            {
                if (traverse.DataNode == data)
                    return traverse;
                traverse = traverse.Next;
            }
            return null;
        }
        public HorizontalLL GetHorizontal(HorizontalLL horizontalLL, int data)
        {
            var traverse = horizontalLL.Next;
            while (traverse != horizontalLL)
            {
                if (traverse.DataNode == data)
                    return traverse;
                traverse = traverse.Next;
            }
            return null;
        }
        protected bool IsExistInVerticle(int data)
        {
            return GetVerticleNode(data) != null;
        }
        protected bool IsExistInHorizontal(HorizontalLL horizontalLL, int data)
        {
            return GetHorizontal(horizontalLL, data) != null;
        }
        protected void InsertAtEnd(VerticleLL verticle, int data)
        {
            InsertVerticle(verticle.Prev, CreateVerticleLL(data), verticle);
        }
        protected void InsertVerticle(VerticleLL prev, VerticleLL newNode, VerticleLL next)
        {
            prev.Next = newNode;
            next.Prev = newNode;

            newNode.Next = next;
            newNode.Prev = prev;
        }
        protected void InsertAtEnd(HorizontalLL horizontal, HorizontalLL newNode)
        {
            InsertHorizontal(horizontal.Prev, newNode, horizontal);
        }
        protected void InsertHorizontal(HorizontalLL prev, HorizontalLL newNode, HorizontalLL next)
        {
            prev.Next = newNode;
            next.Prev = newNode;

            newNode.Next = next;
            newNode.Prev = prev;
        }
        protected void RemoveVerticle(VerticleLL nodeToBeDeleted)
        {
            nodeToBeDeleted.Prev.Next = nodeToBeDeleted.Next;
            nodeToBeDeleted.Next.Prev = nodeToBeDeleted.Prev;
        }
        protected void RemoveHorizontal(HorizontalLL nodeToBeDeleted)
        {
            nodeToBeDeleted.Prev.Next = nodeToBeDeleted.Next;
            nodeToBeDeleted.Next.Prev = nodeToBeDeleted.Prev;
        }
        public List<Edge> GetEdgesByDescendingOrder()
        {
            List<Edge> edges = new List<Edge>();
            var verticleTraverse = graph.Head.Next;

            while (verticleTraverse != graph.Head)
            {
                var horizontalTravel = verticleTraverse.HorizontalLL.Next;
                while (horizontalTravel != verticleTraverse.HorizontalLL)
                {
                    if (horizontalTravel.ForKruskals == Color.Untouch)
                    {
                        var x = GetHorizontal(GetVerticleNode(horizontalTravel.DataNode).HorizontalLL, verticleTraverse.DataNode);
                        x.ForKruskals = horizontalTravel.ForKruskals = Color.Visited;
                        edges.Add(new Edge()
                        {
                            VertexStart = verticleTraverse.DataNode,
                            VertexEnd = horizontalTravel.DataNode,
                            Weight = horizontalTravel.Weight
                        });
                    }
                    horizontalTravel = horizontalTravel.Next;
                }
                verticleTraverse = verticleTraverse.Next;
            }

            return edges.OrderBy(x => x.Weight).ToList();
        }

    }
}
