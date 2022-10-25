namespace AllCoreFiles.CSharp.GraphDSA.GraphManagement
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

        public readonly Graph _graph;
        public GraphService()
        {
            _graph = new Graph();
            _graph.Root = GetNewVertex(-1);
        }
        private VertexNode GetNewVertex(int data)
        {
            var x = new VertexNode();
            x.LinkList = GetNewListNode(-1);
            x.Vertex = data;
            x.Prev = x;
            x.Next = x;
            return x;
        }
        private LinkList GetNewListNode(int data)
        {
            var x = new LinkList();
            x.Vertex = data;
            x.Prev = x;
            x.Next = x;
            return x;
        }
        public int AddVertex(int data)
        {
            if (IsVertexExist(_graph.Root, data))
                return VertexAlreadyExist;

            InsertAtEndVertex(_graph.Root, data);
            _graph.TotalVertex++;
            return SUCCESS;
        }
        private bool IsVertexExist(VertexNode node, int data)
        {
            var traverse = node.Next;
            while (traverse != node)
            {
                if (traverse.Vertex == data)
                    return true;
                traverse = traverse.Next;
            }
            return false;
        }
        private void InsertAtEndVertex(VertexNode node, int data)
        {
            GenericInsert(node.Prev, GetNewVertex(data), node);
        }
        private void GenericInsert(VertexNode prev, VertexNode node, VertexNode next)
        {
            node.Next = next;
            node.Prev = prev;
            prev.Next = node;
            next.Prev = node;
        }
        public VertexNode SearchVertexNode(VertexNode node, int data)
        {
            var traverse = node.Next;
            while (traverse != node)
            {
                if (traverse.Vertex == data)
                    return traverse;
                traverse = traverse.Next;
            }
            return null;
        }
        public LinkList SearchVertexLinkList(LinkList node, int data)
        {
            var traverse = node.Next;
            while (traverse != node)
            {
                if (traverse.Vertex == data)
                    return traverse;
                traverse = traverse.Next;
            }
            return null;
        }
        public int AddEdge(int vertexStart, int vertexEnd, int weight)
        {
            var vStart = SearchVertexNode(_graph.Root, vertexStart);
            if (vStart == null)
                return InvalidVertex;

            var vEnd = SearchVertexNode(_graph.Root, vertexEnd);
            if (vEnd == null)
                return InvalidVertex;

            var edgeInStart = SearchVertexLinkList(vStart.LinkList, vertexEnd);
            var edgeInEnd = SearchVertexLinkList(vEnd.LinkList, vertexStart);

            if (edgeInStart != null && edgeInEnd != null)
                return EdgeAlreadyExists;

            if (edgeInStart != null ^ edgeInEnd != null)
                return GraphIsCorrupted;

            InsertAtEndLinkList(vStart.LinkList, vertexEnd, weight);
            InsertAtEndLinkList(vEnd.LinkList, vertexStart, weight);

            _graph.TotalEdge++;
            return SUCCESS;
        }
        public void InsertAtEndLinkList(LinkList linkList, int data, int weight)
        {
            var newNode = GetNewListNode(data);
            newNode.Weight = weight;
            GenericInsert(linkList.Prev, newNode, linkList);
        }
        private void GenericInsert(LinkList prev, LinkList node, LinkList next)
        {
            node.Prev = prev;
            node.Next = next;

            prev.Next = node;
            next.Prev = node;
        }
        public void RemoveVertex(int data)
        {
            var vertex = SearchVertexNode(_graph.Root, data);

            var traverse = vertex.LinkList.Next;
            while (traverse != vertex.LinkList)
            {
                var traverseNext = traverse.Next;
                var adjecencyVertexNode = SearchVertexNode(_graph.Root, traverse.Vertex);
                var linkListNode = SearchVertexLinkList(adjecencyVertexNode.LinkList, data);
                //GenericDeleteLinkList(linkListNode.Prev, linkListNode, linkListNode.Next);
                RemoveEdge(traverse.Vertex, data);
                traverse = traverseNext;
            }

            GenericDeleteVertex(vertex.Prev, vertex, vertex.Next);
            _graph.TotalVertex--;
        }
        public int RemoveEdge(int vertexStart, int vertexEnd)
        {
            var vStart = SearchVertexNode(_graph.Root, vertexStart);
            if (vStart == null)
                return InvalidVertex;

            var vEnd = SearchVertexNode(_graph.Root, vertexEnd);
            if (vEnd == null)
                return InvalidVertex;

            var edgeInStart = SearchVertexLinkList(vStart.LinkList, vertexEnd);
            var edgeInEnd = SearchVertexLinkList(vEnd.LinkList, vertexStart);

            GenericDeleteLinkList(edgeInStart.Prev, edgeInStart, edgeInStart);
            GenericDeleteLinkList(edgeInEnd.Prev, edgeInEnd, edgeInEnd);
            _graph.TotalEdge--;
            return SUCCESS;
        }
        private void GenericDeleteVertex(VertexNode prev, VertexNode toBeDeleted, VertexNode next)
        {
            prev.Next = next;
            next.Prev = prev;
        }
        private void GenericDeleteLinkList(LinkList prev, LinkList deletedNode, LinkList next)
        {
            deletedNode.Prev.Next = deletedNode.Next;
            deletedNode.Next.Prev = deletedNode.Prev;
        }
        public void Print(string msg)
        {
            Console.Write(msg);
            PrintVertexNode(_graph.Root);
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
        public void PrintLinkListNode(LinkList linkListNode)
        {
            LinkList travese = linkListNode.Next;
            while (travese != linkListNode)
            {
                Console.Write(" " + travese.Vertex + " ");
                travese = travese.Next;
            }
            Console.Write("\n");
        }
        public Edge GetEdge(int vertexStart, int vertexEnd, int weight)
        {
            Edge edge = null;
            var vStart = SearchVertexNode(_graph.Root, vertexStart);
            var vEnd = SearchVertexLinkList(vStart.LinkList, vertexEnd);
            if (vEnd.Weight == weight)
            {
                edge = new Edge()
                {
                    VertexStart = vertexStart,
                    VertexEnd = vertexEnd,
                    Weight = weight
                };
            }
            return edge;
        }
    }

}
