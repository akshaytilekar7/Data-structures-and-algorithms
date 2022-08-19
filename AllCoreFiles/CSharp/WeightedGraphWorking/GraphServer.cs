namespace GraphAlgo
{
    public class GraphServer
    {
        int SUCCESS = 1;
        int VertexAlreadyExist = 2;
        int EdgeAlreadyExists = 3;
        int InvalidVertex = 4;
        int InvalidEdge = 5;
        int GraphIsCorrupted = 6;
        int INFINITY = 50000;
        public Graph CreateGraph()
        {
            Graph graph = new Graph();
            graph.VertexNode = CreateHeadNode();
            graph.TotalEdges = 0;
            graph.TotalVertex = 0;
            return graph;
        }
        public VertexNode CreateHeadNode()
        {
            VertexNode vertexNode = new VertexNode();
            vertexNode.LinkList = CreateNode();
            vertexNode.Next = vertexNode;
            vertexNode.Prev = vertexNode;
            vertexNode.Vertex = 0;
            vertexNode.Color = Color.WHITE;
            return vertexNode;
        }
        public LinkListNode CreateNode()
        {
            LinkListNode linkListNode = new LinkListNode();
            linkListNode.Next = linkListNode;
            linkListNode.Prev = linkListNode;
            linkListNode.Vertex = 0;
            linkListNode.Weight = 0;
            return linkListNode;
        }
        public int AddVertex(Graph graph, int vertex)
        {
            if (IsVertexExist(graph.VertexNode, vertex))
                return VertexAlreadyExist;

            InsertAtEndVertex(graph.VertexNode, vertex);
            graph.TotalVertex++;
            return SUCCESS;
        }
        public int AddEdge(Graph graph, int vertexStart, int vertexEnd, int weight)
        {
            VertexNode vertexStartHead = SearchVertex(graph.VertexNode, vertexStart);
            if (vertexStartHead == null)
                return (InvalidVertex);

            VertexNode vertexEndHead = SearchVertex(graph.VertexNode, vertexEnd);
            if (vertexEndHead == null)
                return (InvalidVertex);

            LinkListNode edgeInStart = SearchNode(vertexStartHead.LinkList, vertexEnd);
            LinkListNode edgeInEnd = SearchNode(vertexEndHead.LinkList, vertexStart);

            if (edgeInStart != null && edgeInEnd != null)
                return (EdgeAlreadyExists);

            if ((edgeInStart != null) ^ (edgeInEnd != null))
                return (GraphIsCorrupted);

            InsertAtEndNode(vertexStartHead.LinkList, vertexEnd, weight);
            InsertAtEndNode(vertexEndHead.LinkList, vertexStart, weight);

            graph.TotalEdges++;

            return SUCCESS;
        }
        public int RemoveVertexOtherWay(Graph graph, int vertex)
        {
            VertexNode deletedHeadNode = SearchVertex(graph.VertexNode, vertex);
            if (deletedHeadNode == null)
                return (InvalidVertex);

            LinkListNode traverse = deletedHeadNode.LinkList.Next;
            while (traverse != deletedHeadNode.LinkList)
            {
                LinkListNode traverseNext = traverse.Next;
                RemoveEdge(graph, traverse.Vertex, vertex);
                traverse = traverseNext;
            }

            GenericDeleteVertex(deletedHeadNode);
            graph.TotalVertex--;
            return SUCCESS;
        }
        public int RemoveVertex(Graph graph, int vertex)
        {
            VertexNode deletedHeadNode = SearchVertex(graph.VertexNode, vertex);
            if (deletedHeadNode == null)
                return (InvalidVertex);

            LinkListNode traverse = deletedHeadNode.LinkList.Next;
            while (traverse != deletedHeadNode.LinkList)
            {
                LinkListNode traverseNext = traverse.Next;
                VertexNode adjecencyVertex = SearchVertex(graph.VertexNode, traverse.Vertex);
                LinkListNode edge = SearchNode(adjecencyVertex.LinkList, vertex);
                if (edge == null)
                    return (GraphIsCorrupted);
                GenericDeleteNode(edge);
                graph.TotalEdges--;
                traverse = traverseNext;
            }

            GenericDeleteVertex(deletedHeadNode);
            graph.TotalVertex--;
            return SUCCESS;

        }
        public int RemoveEdge(Graph graph, int vertexStart, int vertexEnd)
        {
            VertexNode vertexStartHead = SearchVertex(graph.VertexNode, vertexStart);
            if (vertexStartHead == null)
                return (InvalidVertex);

            VertexNode vertexEndHead = SearchVertex(graph.VertexNode, vertexEnd);
            if (vertexEndHead == null)
                return (InvalidVertex);

            LinkListNode edgeInStart = SearchNode(vertexStartHead.LinkList, vertexEnd);
            LinkListNode edgeInEnd = SearchNode(vertexEndHead.LinkList, vertexStart);

            if (edgeInStart == null && edgeInEnd == null)
                return (InvalidEdge);

            if ((edgeInStart != null) ^ (edgeInEnd != null))
                return (GraphIsCorrupted);

            GenericDeleteNode(edgeInStart);
            GenericDeleteNode(edgeInEnd);
            graph.TotalEdges--;

            return SUCCESS;
        }
        public void Print(Graph graph, string msg)
        {
            Console.WriteLine(msg);
            PrintVertexNode(graph.VertexNode);
        }
        public void PrintVertexNode(VertexNode vertexNode)
        {
            Console.Write("[START] \n");
            VertexNode travese = vertexNode.Next;
            while (travese != vertexNode)
            {
                Console.Write(" [" + travese.Vertex + "] . ");
                PrintLinkListNode(travese.LinkList);
                travese = travese.Next;
            }
            Console.Write("[END]\n");
        }
        public void PrintLinkListNode(LinkListNode linkListNode)
        {
            LinkListNode travese = linkListNode.Next;
            while (travese != linkListNode)
            {
                Console.Write(" [" + travese.Vertex + "] ");
                travese = travese.Next;
            }
            Console.Write("\n");
        }
        public bool IsVertexExist(VertexNode vertexNode, int vertex)
        {
            return SearchVertex(vertexNode, vertex) != null;
        }
        public VertexNode SearchVertex(VertexNode vertexNode, int vertex)
        {
            VertexNode traverse = vertexNode.Next;

            while (traverse != vertexNode)
            {
                if (traverse.Vertex == vertex)
                    return traverse;

                traverse = traverse.Next;
            }
            return null;
        }
        public void GenericInsertVertex(VertexNode prev, VertexNode newNode, VertexNode Next)
        {
            newNode.Next = Next;
            newNode.Prev = prev;
            prev.Next = newNode;
            Next.Prev = newNode;
        }
        public void GenericDeleteVertex(VertexNode deletedNode)
        {
            deletedNode.Prev.Next = deletedNode.Next;
            deletedNode.Next.Prev = deletedNode.Prev;
        }
        public void InsertAtEndVertex(VertexNode vertexNode, int vertex)
        {
            VertexNode newNode = CreateHeadNode();
            newNode.Vertex = vertex;
            GenericInsertVertex(vertexNode.Prev, newNode, vertexNode);
        }
        public bool IsNodeExist(LinkListNode linkListNode, int vertex)
        {
            return SearchNode(linkListNode, vertex) != null;
        }
        LinkListNode SearchNode(LinkListNode linkListNode, int vertex)
        {
            LinkListNode traverse = linkListNode.Next;

            while (traverse != linkListNode)
            {
                if (traverse.Vertex == vertex)
                    return traverse;

                traverse = traverse.Next;
            }
            return null;
        }
        public void GenericInsertNode(LinkListNode prev, LinkListNode newNode, LinkListNode Next)
        {
            newNode.Next = Next;
            newNode.Prev = prev;
            prev.Next = newNode;
            Next.Prev = newNode;
        }
        public void GenericDeleteNode(LinkListNode deletedNode)
        {
            deletedNode.Prev.Next = deletedNode.Next;
            deletedNode.Next.Prev = deletedNode.Prev;
        }
        public void InsertAtEndNode(LinkListNode linkListNode, int vertex, int weight)
        {
            LinkListNode newNode = CreateNode();
            newNode.Vertex = vertex;
            newNode.Weight = weight;
            GenericInsertNode(linkListNode.Prev, newNode, linkListNode);
        }
        public void ResetColor(Graph graph)
        {
            VertexNode traverse = graph.VertexNode.Next;
            while (traverse != graph.VertexNode)
            {
                traverse.Color = Color.WHITE;
                traverse = traverse.Next;
            }
        }
        public int Dijkstra(Graph graph, int src)
        {
            VertexNode srcVertex = SearchVertex(graph.VertexNode, src);
            if (srcVertex == null)
                return InvalidVertex;

            InitializeSingleSource(graph, srcVertex);

            List<VertexNode> priorityQueue = new List<VertexNode>();
            for (VertexNode traverse = graph.VertexNode.Next; traverse != graph.VertexNode; traverse = traverse.Next)
                priorityQueue.Add(traverse);

            while (priorityQueue.Count != 0)
            {
                VertexNode vertexNode = priorityQueue.PopMin();
                for (LinkListNode traverse = vertexNode.LinkList.Next; traverse != vertexNode.LinkList; traverse = traverse.Next)
                {
                    VertexNode adjecencyListVertex = SearchVertex(graph.VertexNode, traverse.Vertex);
                    Relax(vertexNode, adjecencyListVertex);
                }
            }
            priorityQueue.Clear();
            return (SUCCESS);
        }
        public void PrintShortestPath(Graph g, VertexNode pv_node)
        {
            Stack<VertexNode> pvq_stack = new Stack<VertexNode>();
            int curr_vertex_number = pv_node.Vertex;
            double d = pv_node.Distance;

            while (pv_node != null)
            {
                pvq_stack.Push(pv_node);
                pv_node = pv_node.UPrev;
            }

            Console.Write("Shortest path to [" + curr_vertex_number + "]\n");
            Console.Write("[BEGINNING]<.");
            while (pvq_stack.Count != 0)
            {
                VertexNode pv_poped_node = pvq_stack.Pop();
                Console.Write("[" + pv_poped_node.Vertex + "]<.");
            }
            Console.Write("[COST:" + d + "]\n");
            Console.WriteLine("[END]");

            pvq_stack.Clear();
        }
        public void PrintAllShortestPaths(Graph g)
        {
            VertexNode pv_node = null;
            for (pv_node = g.VertexNode.Next; pv_node != g.VertexNode; pv_node = pv_node.Next)
            {
                PrintShortestPath(g, pv_node);
            }
        }
        void InitializeSingleSource(Graph g, VertexNode pv_s)
        {
            VertexNode pv_run = g.VertexNode.Next;
            while (pv_run != g.VertexNode)
            {
                pv_run.Distance = INFINITY;
                pv_run.UPrev = null;
                pv_run = pv_run.Next;
            }
            pv_s.Distance = 0;
        }
        void Relax(VertexNode src, VertexNode dest)
        {
            LinkListNode node = SearchNode(src.LinkList, dest.Vertex);
            int weight = node.Weight;

            if (dest.Distance > src.Distance + weight)
            {
                dest.Distance = src.Distance + weight;
                dest.UPrev = src;
            }
        }

    }

    public static class Extenstion
    {
        public static VertexNode PopMin(this List<VertexNode> priorityQueue)
        {
            var min = priorityQueue.OrderBy(p => p.Distance).First();
            priorityQueue.Remove(min);
            return min;
        }
    }
}