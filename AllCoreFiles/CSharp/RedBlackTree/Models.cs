// https://www.youtube.com/watch?v=C6NOlAPo5_o

namespace AllCoreFiles.CSharp.RedBlackTree1
{
    public enum Color
    {
        RED = 0,
        BLACK
    };

    public class Node
    {
        public int Data { get; set; }
        public Color Color { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Parent { get; set; }
    };

    public class RbTree
    {
        public Node Root { get; set; }
        public Node Nil = new Node(); 
        public int Count;
    };
}
