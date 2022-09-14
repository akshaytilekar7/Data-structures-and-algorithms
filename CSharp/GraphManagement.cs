/*

    Dijkstras algorithm 
        is used only to find shortest path.

    Minimum Spanning tree (Prim's or Kruskal's algorithm) 
        get minimum egdes with minimum edge value.

    Prim [ w(u,v) ] and Dijkstra [ w(u,v) + u.key ] 
        algorithms are almost the same, except for the "relax function".

    GMST and MSTPrim
        MSTPrim ha GMST ahe
 
*/
namespace GraphAlgo
{
    public class GraphManagement
    {
        int SUCCESS = 1;
        int VertexAlreadyExist = 2;
        int EdgeAlreadyExists = 3;
        int InvalidVertex = 4;
        int InvalidEdge = 5;
        int GraphIsCorrupted = 6;

        public readonly Graph graph;
        public GraphManagement()
        {
            graph = new Graph();
            graph.VertexNode = CreateHeadNode();
            graph.TotalEdges = 0;
            graph.TotalVertex = 0;
        }
        public VerticleVertexNode CreateHeadNode()
        {
            VerticleVertexNode vertexNode = new VerticleVertexNode();
            vertexNode.LinkList = CreateNode();
            vertexNode.Next = vertexNode;
            vertexNode.Prev = vertexNode;
            vertexNode.Vertex = 0;
            vertexNode.Color = Color.WHITE;
            return vertexNode;
        }
        public HorizontalLinkListNode CreateNode()
        {
            HorizontalLinkListNode linkListNode = new HorizontalLinkListNode();
            linkListNode.Next = linkListNode;
            linkListNode.Prev = linkListNode;
            linkListNode.Vertex = 0;
            linkListNode.Weight = 0;
            return linkListNode;
        }
        public int AddVertex(int vertex)
        {
            if (IsVertexExist(graph.VertexNode, vertex))
                return VertexAlreadyExist;

            InsertAtEndVertex(graph.VertexNode, vertex);
            graph.TotalVertex++;
            return SUCCESS;
        }
        public int AddEdge(int vertexStart, int vertexEnd, int weight)
        {
            VerticleVertexNode vertexStartHead = SearchVertex(graph.VertexNode, vertexStart);
            if (vertexStartHead == null)
                return (InvalidVertex);

            VerticleVertexNode vertexEndHead = SearchVertex(graph.VertexNode, vertexEnd);
            if (vertexEndHead == null)
                return (InvalidVertex);

            HorizontalLinkListNode edgeInStart = SearchNode(vertexStartHead.LinkList, vertexEnd);
            HorizontalLinkListNode edgeInEnd = SearchNode(vertexEndHead.LinkList, vertexStart);

            if (edgeInStart != null && edgeInEnd != null)
                return (EdgeAlreadyExists);

            if ((edgeInStart != null) ^ (edgeInEnd != null))
                return (GraphIsCorrupted);

            InsertAtEndNode(vertexStartHead.LinkList, vertexEnd, weight);
            InsertAtEndNode(vertexEndHead.LinkList, vertexStart, weight);

            graph.TotalEdges++;

            return SUCCESS;
        }
        public int RemoveVertexOtherWay(int vertex)
        {
            VerticleVertexNode deletedHeadNode = SearchVertex(graph.VertexNode, vertex);
            if (deletedHeadNode == null)
                return (InvalidVertex);

            HorizontalLinkListNode traverse = deletedHeadNode.LinkList.Next;
            while (traverse != deletedHeadNode.LinkList)
            {
                HorizontalLinkListNode traverseNext = traverse.Next;
                RemoveEdge(traverse.Vertex, vertex);
                traverse = traverseNext;
            }

            GenericDeleteVertex(deletedHeadNode);
            graph.TotalVertex--;
            return SUCCESS;
        }
        public int RemoveVertex(int vertex)
        {
            VerticleVertexNode deletedHeadNode = SearchVertex(graph.VertexNode, vertex);
            if (deletedHeadNode == null)
                return (InvalidVertex);

            HorizontalLinkListNode traverse = deletedHeadNode.LinkList.Next;
            while (traverse != deletedHeadNode.LinkList)
            {
                HorizontalLinkListNode traverseNext = traverse.Next;
                VerticleVertexNode adjecencyVertex = SearchVertex(graph.VertexNode, traverse.Vertex);
                HorizontalLinkListNode edge = SearchNode(adjecencyVertex.LinkList, vertex);
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
        public int RemoveEdge(int vertexStart, int vertexEnd)
        {
            VerticleVertexNode vertexStartHead = SearchVertex(graph.VertexNode, vertexStart);
            if (vertexStartHead == null)
                return (InvalidVertex);

            VerticleVertexNode vertexEndHead = SearchVertex(graph.VertexNode, vertexEnd);
            if (vertexEndHead == null)
                return (InvalidVertex);

            HorizontalLinkListNode edgeInStart = SearchNode(vertexStartHead.LinkList, vertexEnd);
            HorizontalLinkListNode edgeInEnd = SearchNode(vertexEndHead.LinkList, vertexStart);

            if (edgeInStart == null && edgeInEnd == null)
                return (InvalidEdge);

            if ((edgeInStart != null) ^ (edgeInEnd != null))
                return (GraphIsCorrupted);

            GenericDeleteNode(edgeInStart);
            GenericDeleteNode(edgeInEnd);
            graph.TotalEdges--;

            return SUCCESS;
        }
        public void Print(string msg)
        {
            Console.WriteLine(msg);
            PrintVertexNode(graph.VertexNode);
        }
        public void PrintVertexNode(VerticleVertexNode vertexNode)
        {
            Console.Write("[START] \n");
            VerticleVertexNode travese = vertexNode.Next;
            while (travese != vertexNode)
            {
                Console.Write(" [" + travese.Vertex + "] . ");
                PrintLinkListNode(travese.LinkList);
                travese = travese.Next;
            }
            Console.Write("[END]\n");
        }
        public void PrintLinkListNode(HorizontalLinkListNode linkListNode)
        {
            HorizontalLinkListNode travese = linkListNode.Next;
            while (travese != linkListNode)
            {
                Console.Write(" [" + travese.Vertex + "] ");
                travese = travese.Next;
            }
            Console.Write("\n");
        }
        public bool IsVertexExist(VerticleVertexNode vertexNode, int vertex)
        {
            return SearchVertex(vertexNode, vertex) != null;
        }
        public VerticleVertexNode SearchVertex(VerticleVertexNode vertexNode, int vertex)
        {
            VerticleVertexNode traverse = vertexNode.Next;

            while (traverse != vertexNode)
            {
                if (traverse.Vertex == vertex)
                    return traverse;

                traverse = traverse.Next;
            }
            return null;
        }
        public void GenericInsertVertex(VerticleVertexNode prev, VerticleVertexNode newNode, VerticleVertexNode Next)
        {
            newNode.Next = Next;
            newNode.Prev = prev;
            prev.Next = newNode;
            Next.Prev = newNode;
        }
        public void GenericDeleteVertex(VerticleVertexNode deletedNode)
        {
            deletedNode.Prev.Next = deletedNode.Next;
            deletedNode.Next.Prev = deletedNode.Prev;
        }
        public void InsertAtEndVertex(VerticleVertexNode vertexNode, int vertex)
        {
            VerticleVertexNode newNode = CreateHeadNode();
            newNode.Vertex = vertex;
            GenericInsertVertex(vertexNode.Prev, newNode, vertexNode);
        }
        public bool IsNodeExist(HorizontalLinkListNode linkListNode, int vertex)
        {
            return SearchNode(linkListNode, vertex) != null;
        }
        public HorizontalLinkListNode SearchNode(HorizontalLinkListNode linkListNode, int vertex)
        {
            HorizontalLinkListNode traverse = linkListNode.Next;

            while (traverse != linkListNode)
            {
                if (traverse.Vertex == vertex)
                    return traverse;

                traverse = traverse.Next;
            }
            return null;
        }
        public void GenericInsertNode(HorizontalLinkListNode prev, HorizontalLinkListNode newNode, HorizontalLinkListNode Next)
        {
            newNode.Next = Next;
            newNode.Prev = prev;
            prev.Next = newNode;
            Next.Prev = newNode;
        }
        public void GenericDeleteNode(HorizontalLinkListNode deletedNode)
        {
            deletedNode.Prev.Next = deletedNode.Next;
            deletedNode.Next.Prev = deletedNode.Prev;
        }
        public void InsertAtEndNode(HorizontalLinkListNode linkListNode, int vertex, int weight)
        {
            HorizontalLinkListNode newNode = CreateNode();
            newNode.Vertex = vertex;
            newNode.Weight = weight;
            GenericInsertNode(linkListNode.Prev, newNode, linkListNode);
        }
    }
}