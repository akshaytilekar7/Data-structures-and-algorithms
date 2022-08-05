namespace CSharp.Graph
{
    public class Graph
    {
        public int TotalEdges;
        public int TotalVertex;
        public VertexNode VertexNode;
    }

    public class LinkListNode
    {
        public int Vertex;
        public LinkListNode Prev;
        public LinkListNode Next;
    }

    public enum Color
    {
        WHITE = 0,
        GRAY,
        BLACK
    }

    public class VertexNode
    {
        public int Vertex;
        public VertexNode Prev;
        public VertexNode Next;
        public LinkListNode LinkList;
        public Color Color;
    }

    public class Edge
    {
        public int VertexStart;
        public int VertexEnd;
    }
}