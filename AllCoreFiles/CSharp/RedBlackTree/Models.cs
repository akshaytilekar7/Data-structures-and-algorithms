namespace AllCoreFiles.CSharp.RedBlackTree
{
    public enum Color
    {
        RED = 0,
        BLACK
    };

    public class RbNode
    {
        public int Data;
        public Color Color; // Added extra 
        public RbNode Left;
        public RbNode Right;
        public RbNode Parent;
    };

    public class RbTree
    {
        public RbNode Root;
        public RbNode Nil; // Added extra for Sentinal node
        public int Count;
    };
}
