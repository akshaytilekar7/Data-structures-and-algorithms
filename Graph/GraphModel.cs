namespace Graph
{
    public class Graph
    {
        public VerticleLL Head { get; set; }
        public int TotalVerticleVertex { get; set; }
        public int TotalHorizontalVertex { get; set; }
    }

    public class VerticleLL
    {
        public int DataNode { get; set; }
        public HorizontalLL HorizontalLL { get; set; }
        public VerticleLL Next { get; set; }
        public VerticleLL Prev { get; set; }
        public Color Color { get; set; }
        public VerticleLL Predecessor { get; set; }
        public int Distance { get; set; }

    }

    public enum Color
    {
        Untouch = 0,
        Visited = 1,
    }
    public class HorizontalLL
    {
        public int DataNode { get; set; }
        public HorizontalLL Next { get; set; }
        public HorizontalLL Prev { get; set; }
        public int Weight { get; set; }
        public Color ForKruskals { get; set; }
    }

    public class Edge
    {
        public int VertexStart;
        public int VertexEnd;
        public int Weight;
    }
}
