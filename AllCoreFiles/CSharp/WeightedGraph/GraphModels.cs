namespace GraphAlgoWeightedGraph
{
    public class Graph
    {
        public int TotalVertex;
        public int TotalEdges;
        public VertexNode VertexNode;
    };

    public class LinkListNode
    {
        public int Vertex;
        public int Weight;
        public LinkListNode Prev;
        public LinkListNode Next;
    };

    public enum Color
    {
        WHITE = 0,
        GRAY,
        BLACK
    };

    public class VertexNode
    {
        public int Vertex;
        public LinkListNode LinkList;
        
        public Color Color;
        public VertexNode UPrev;
        public int Distance;

        public VertexNode Prev;
        public VertexNode Next;
    };

    public class Edge
    {
        public int VertexStart;
        public int VertexEnd;
        public int Weight;
    };
}