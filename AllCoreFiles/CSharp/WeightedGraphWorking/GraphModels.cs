namespace GraphAlgo
{
    public class Graph
    {
        public int TotalVertex;
        public int TotalEdges;
        public VerticleVertexNode VertexNode;
    };

    public class HorizontalLinkListNode
    {
        public int Vertex;
        public int Weight;
        public HorizontalLinkListNode Prev;
        public HorizontalLinkListNode Next;
    };

    public enum Color
    {
        WHITE = 0,
        GRAY,
        BLACK
    };

    public class VerticleVertexNode
    {
        public int Vertex;
        public HorizontalLinkListNode LinkList;

        public VerticleVertexNode Prev;
        public VerticleVertexNode Next;

        public Color Color;
        public VerticleVertexNode PrevShortest;
        public int Distance;

        public override string ToString()
        {
            var s = PrevShortest == null ? -1 : PrevShortest.Vertex;
            return "vertex " + Vertex + " distance: " + Distance + " Prev:" + s;
        }
    }
    public class Edge
    {
        public int VertexStart;
        public int VertexEnd;
        public int Weight;
    };
}