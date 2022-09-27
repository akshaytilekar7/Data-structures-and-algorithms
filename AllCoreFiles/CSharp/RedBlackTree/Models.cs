namespace AllCoreFiles.CSharp.RedBlackTree
{
    public enum Color
    {
        RED = 0,
        BLACK
    };

    public class Node
    {
        public int Data;
        public Color Color; 
        public Node Left;
        public Node Right;
        public Node Parent;
    };

    public class RbTree
    {
        public Node Root;
        public Node Nil; 
        public int Count;
    };
}
