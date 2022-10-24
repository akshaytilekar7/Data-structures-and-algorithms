namespace CSharp.WeightedGraphAlgo
{
    public class Graph
    {
        public VertexNode Root { get; set; }
        public int TotalVertex { get; set; }
        public int TotalEdge { get; set; }

    }

    public class VertexNode
    {
        public int Vertex { get; set; }
        public VertexNode Prev { get; set; }
        public VertexNode Next { get; set; }

        public LinkList LinkList { get; set; }

        public int Distance { get; set; }
        public VertexNode Predecessor { get; set; }
    }

    public class LinkList
    {
        public int Vertex { get; set; }
        public LinkList Prev { get; set; }
        public LinkList Next { get; set; }
        public int Weight { get; set; }
    }

    public class Edge
    {
        public int VertexStart;
        public int VertexEnd;
        public int Weight;
    }
}
