namespace BinarySearchTree
{
    public class BinarySearchTree
    {
        public Node Root{ get; set; }
    }
    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Parent { get; set; }
    }
}
