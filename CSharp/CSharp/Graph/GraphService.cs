namespace CSharp.Graph
{
    public class GraphService
    {
        const int SUCCESS = 1;
        const int TRUE = 1;
        const int FALSE = 0;
        const int VertexAlreadyExist = 2;
        const int EdgeAlreadyExists = 3;
        const int InvalidVertex = 4;
        const int InvalidEdge = 5;
        const int GraphIsCorrupted = 6;
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
        public int AddEdge(Graph graph, int vertexStart, int vertexEnd)
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

            InsertAtEndNode(vertexStartHead.LinkList, vertexEnd);
            InsertAtEndNode(vertexEndHead.LinkList, vertexStart);

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
            Console.Write(msg);
            PrintVertexNode(graph.VertexNode);
        }
        public void PrintVertexNode(VertexNode vertexNode)
        {
            Console.Write("[START] \n");
            VertexNode travese = vertexNode.Next;
            while (travese != vertexNode)
            {
                Console.Write(" " + travese.Vertex + " ");
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
                Console.Write(" " + travese.Vertex + " ");
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
        public LinkListNode SearchNode(LinkListNode linkListNode, int vertex)
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
        public void InsertAtEndNode(LinkListNode linkListNode, int vertex)
        {
            LinkListNode newNode = CreateNode();
            newNode.Vertex = vertex;
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
        public void PrintDFS(Graph graph)
        {
            Console.Write("\nDFS STARTED: \n");

            ResetColor(graph);
            VertexNode traverse = graph.VertexNode.Next;
            int connectedComponentCount = 0;
            while (traverse != graph.VertexNode)
            {
                if (traverse.Color == Color.WHITE)
                {
                    Console.Write("connected component: " + (++connectedComponentCount) + "\n");
                    Console.Write("[START]. ");
                    DFS(graph, traverse);
                    Console.Write(" <-[END]\n");
                }
                traverse = traverse.Next;
            }

            Console.Write("DFS END: \n");
        }
        public void DFS(Graph graph, VertexNode vertexNode)
        {
            vertexNode.Color = Color.GRAY;
            Console.Write(vertexNode.Vertex + " ");

            LinkListNode linkListNode = vertexNode.LinkList.Next;
            while (linkListNode != vertexNode.LinkList)
            {

                VertexNode node = SearchVertex(graph.VertexNode, linkListNode.Vertex);
                if (node.Color == Color.WHITE)
                    DFS(graph, node);
                linkListNode = linkListNode.Next;
            }
            vertexNode.Color = Color.BLACK;
        }

        public void PrintBFS(Graph graph)
        {
            Console.Write("\n[BFS START] \n");
            ResetColor(graph);
            VertexNode traverse = graph.VertexNode.Next;
            int connectedComponentCount = 0;
            while (traverse != graph.VertexNode)
            {
                if (traverse.Color == Color.WHITE)
                {
                    Console.Write("connected component: " + (++connectedComponentCount) + "\n");
                    Console.Write("[START] ->\n");
                    BFS(graph, traverse);
                    Console.Write("\n<-[END]\n");
                }
                traverse = traverse.Next;
            }
            Console.Write("\n[BFS BFS BFS END] \n");
        }

        public void BFS(Graph graph, VertexNode vertexNode)
        {
            int newLine = 0;
            Queue<VertexNode> queue = new Queue<VertexNode>();
            vertexNode.Color = Color.GRAY;
            queue.Enqueue(vertexNode);
            while (queue.Count > 0)
            {
                VertexNode node = queue.Dequeue();
                //newLine--;
                node.Color = Color.GRAY;
                Console.Write(node.Vertex + " ");
                //if(newLine <= 0)
                //    Console.WriteLine();
                LinkListNode traverse = node.LinkList.Next;
                while (traverse != node.LinkList)
                {
                    //newLine++;
                    VertexNode vNode = SearchVertex(graph.VertexNode, traverse.Vertex);
                    if (vNode.Color == Color.WHITE && !queue.Contains(vNode))
                        queue.Enqueue(vNode);
                    traverse = traverse.Next;
                }
                node.Color = Color.BLACK;
            }
        }
    }
}
