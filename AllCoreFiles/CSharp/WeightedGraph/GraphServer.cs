namespace GraphAlgoWeightedGraph
{
    using System.Linq;
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
            LinkListNode traverseNext = null, edge = null, traverse = null;
            VertexNode adjecencyVertex = null, deletedHeadNode = null;

            deletedHeadNode = SearchVertex(graph.VertexNode, vertex);
            if (deletedHeadNode == null)
                return (InvalidVertex);

            traverse = deletedHeadNode.LinkList.Next;
            while (traverse != deletedHeadNode.LinkList)
            {
                traverseNext = traverse.Next;
                adjecencyVertex = SearchVertex(graph.VertexNode, traverse.Vertex);
                edge = SearchNode(adjecencyVertex.LinkList, vertex);
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

        public void GenericInsertVertex(VertexNode prev, VertexNode newNode, VertexNode next)
        {
            newNode.Next = next;
            newNode.Prev = prev;
            prev.Next = newNode;
            next.Prev = newNode;
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

        public void GenericInsertNode(LinkListNode prev, LinkListNode newNode, LinkListNode next)
        {
            newNode.Next = next;
            newNode.Prev = prev;
            prev.Next = newNode;
            next.Prev = newNode;
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

        #region SearchAlgo
        public void ResetColor(Graph graph)
        {
            VertexNode traverse = graph.VertexNode.Next;
            while (traverse != graph.VertexNode)
            {
                traverse.Color = Color.WHITE;
                traverse = traverse.Next;
            }
        }

        //public bool IsExist(VertexNode[] arr, int size, VertexNode element)
        //{
        //    for (int i = 0; i < size; i++)
        //    {
        //        if (arr[i] == element)
        //            return true;
        //    }
        //    return false;
        //}

        //public void DijkstraShortestPath(Graph graph, int src)
        //{
        //    // basic init
        //    PriorityQueue<Dijkstra, int> priorityQueue = new PriorityQueue<Dijkstra, int>();
        //    VertexNode travese = graph.VertexNode.Next;

        //    while (travese != graph.VertexNode)
        //    {
        //        Dijkstra temp = new Dijkstra();
        //        temp.Vertex = travese;
        //        temp.Distance = travese.Vertex == src ? 0 : -50000;
        //        temp.Prev = null;
        //        temp.Visited = false;
        //        priorityQueue.Enqueue(temp, temp.Distance);
        //        travese = travese.Next;
        //    }

        //    // priority queue as array
        //    while (priorityQueue.Count != 0)
        //    {
        //        Dijkstra ele = priorityQueue.Dequeue();
        //        LinkListNode traveseLL = ele.Vertex.LinkList.Next;
        //        while (traveseLL != ele.Vertex.LinkList)
        //        {
        //            Dijkstra dest = FindVertex(priorityQueue, graph.TotalVertex, travese.Vertex);
        //            Relax(ele, dest, travese.Weight);
        //            traveseLL = traveseLL.Next;
        //        }
        //    }

        //    PrintDijkstra(priorityQueue, graph.TotalVertex);
        //}

        //public Dijkstra FindVertex(PriorityQueue<Dijkstra, int> arr, int size, int vertex)
        //{
        //    for (int i = 0; i < size; i++)
        //    {
        //        if ((arr[i]).Vertex.Vertex == vertex)
        //            return arr[i];
        //    }
        //    return null;
        //}

        //public void PrintDijkstra(Dijkstra arr, int size)
        //{
        //    Console.WriteLine("Dijkstra Table");
        //    Console.WriteLine("vertex |  dist  |   prev");
        //    for (int i = 0; i < size; i++)
        //    {
        //        int d = arr[i].Prev == null ? 0 : arr[i].Prev.Vertex.Vertex;
        //        Console.Write("%d      |   %d    |    %d\n", arr[i].Vertex.Vertex, arr[i].Distance, d);
        //    }
        //}

        //public void Relax(Dijkstra src, Dijkstra dest, int weight)
        //{
        //    if ((dest).Distance > ((src).Distance) + weight)
        //    {
        //        (dest).Distance = (src).Distance + weight;
        //        (dest).Prev = (src);
        //    }
        //}

        //public Dijkstra GetMin(Dijkstra priorityQueue, int size)
        //{
        //    Dijkstra min = new Dijkstra();
        //    min.Distance = Infinity;
        //    for (int i = 0; i < size; i++)
        //    {
        //        if (priorityQueue[i] != null && !priorityQueue[i].Visited
        //            && priorityQueue[i].Distance < min.Distance)
        //        {
        //            min = priorityQueue[i];
        //            priorityQueue[i].Visited = true;
        //        }
        //    }
        //    return min;
        //}

        //public bool AllProcess(Dijkstra priorityQueue, int size)
        //{
        //    for (int i = 0; i < size; i++)
        //    {
        //        if (priorityQueue[i].Visited == false)
        //            return false;
        //    }
        //    return true;
        //}

        public void InitializeSingleSource(Graph graph, VertexNode vertexNode)
        {
            VertexNode traverse = graph.VertexNode.Next;
            while (traverse != graph.VertexNode)
            {
                traverse.Distance = INFINITY; 
                traverse.UPrev = null;
                traverse = traverse.Next;
            }
            vertexNode.Distance = 0;
        }

        public int Dijkstra(Graph graph, int src)
        {
            VertexNode vertexNode = SearchVertex(graph.VertexNode, src);
            if (vertexNode == null)
                return InvalidVertex;

            InitializeSingleSource(graph, vertexNode);

            PriorityQueue<VertexNode, int> priorityQueue = new PriorityQueue<VertexNode, int>();
            for (VertexNode traverseVertex = graph.VertexNode.Next;
                traverseVertex != graph.VertexNode;
                traverseVertex = traverseVertex.Next)
                priorityQueue.Enqueue(traverseVertex, traverseVertex.Distance);

            while (priorityQueue.Count != 0)
            {
                VertexNode dequeVertexNode = priorityQueue.Dequeue();
                Console.WriteLine("DDDD : " + dequeVertexNode.Vertex);
                for (LinkListNode ph_run = dequeVertexNode.LinkList.Next;
                    ph_run != dequeVertexNode.LinkList; ph_run = ph_run.Next)
                {
                    VertexNode pv_of_ph = SearchVertex(graph.VertexNode, ph_run.Vertex);
                    Relax(graph, dequeVertexNode, pv_of_ph);
			        //Relax(&ele, &dest, travese->Weight);
                }
            }

            return (SUCCESS);
        }

        public void Relax(Graph g, VertexNode vertexNode, VertexNode vertex)
        {
            var ph_node = SearchNode(vertexNode.LinkList, vertex.Vertex);
            int w = ph_node.Weight;

            if (vertex.Distance > vertexNode.Distance + w)
            {
                vertex.Distance = vertexNode.Distance + w;
                vertex.UPrev = vertexNode;
            }
        }

        public void PrintShortestPath(Graph g, VertexNode vertexNode)
        {
            Stack<VertexNode> stack = new Stack<VertexNode>();
            int currVertexNumber;

            currVertexNumber = vertexNode.Vertex;
            int distance = vertexNode.Distance;

            while (vertexNode != null)
            {
                stack.Push(vertexNode);
                vertexNode = vertexNode.UPrev;
            }

            Console.Write("Shortest path to [" + currVertexNumber + "]\n");
            Console.Write("[BEGINNING]<.");
            while (stack.Count != 0)
            {
                VertexNode poppedVertex = stack.Pop();
                Console.Write("[" + poppedVertex.Vertex + "]<.");
            }
            Console.Write("[COST:" + distance + "]\n");
            Console.WriteLine("[END]");
        }

        public void PrintAllShortestPath(Graph g)
        {
            VertexNode vertexNode;
            for (vertexNode = g.VertexNode.Next; vertexNode != g.VertexNode; vertexNode = vertexNode.Next)
            {
                PrintShortestPath(g, vertexNode);
            }
        }

        #endregion
    }
}