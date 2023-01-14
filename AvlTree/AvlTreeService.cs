namespace AvlTree
{
    public class AvlTreeService
    {
        AvlTree avlTree;
        public AvlTreeService()
        {
            avlTree = new AvlTree();
        }
        public Node GetNewNode(int data)
        {
            var node = new Node();
            node.Data = data;
            return node;
        }
        public int GetHeight()
        {
            return GetHeight(avlTree.Root);
        }
        public int GetHeight(Node node)
        {
            if (node == null)
                return 0;

            return 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        }
        public void Insert(int data)
        {
            var newNode = GetNewNode(data);
            var node = avlTree.Root;
            if (node == null)
            {
                avlTree.Root = newNode;
                return;
            }
            else
            {
                while (true)
                {
                    if (data < node.Data)
                    {
                        if (node.Left == null)
                        {
                            node.Left = newNode;
                            newNode.Parent = node;
                            break;
                        }
                        node = node.Left;
                    }
                    else
                    {
                        if (node.Right == null)
                        {
                            node.Right = newNode;
                            newNode.Parent = node;
                            break;
                        }
                        node = node.Right;
                    }
                }
                InsertFixup(newNode);
            }
        }
        private bool IsBalanceNotValid(Node node)
        {
            var balance = GetBalance(node);
            return (balance < -1 || balance > 1);
        }
        private void InsertFixup(Node child)
        {
            if (avlTree.Root == child) return;

            var parent = child.Parent;
            Node grandparent = null;
            if (parent != null)
                grandparent = parent.Parent;

            if (child == null || parent == null || grandparent == null)
                return;

            
            while (grandparent != null)
            {
                if (IsBalanceNotValid(grandparent))
                    break;

                child = parent;
                parent = grandparent;
                grandparent = grandparent.Parent;
            }

            if (grandparent == null)
                return;

            FixupByRotation(child, parent, grandparent);
        }
        private void FixupByRotation(Node child, Node parent, Node grandparent)
        {
            if (grandparent.Left == parent && parent.Left == child)
            {
                // left left
                RightRotate(grandparent);
            }
            else if (grandparent.Right == parent && parent.Right == child)
            {
                // right right
                LeftRotate(grandparent);

            }
            else if (grandparent.Left == parent && parent.Right == child)
            {
                // left right
                LeftRotate(parent);
                RightRotate(grandparent);
            }
            else if (grandparent.Right == parent && parent.Left == child)
            {
                // rigth left
                RightRotate(parent);
                LeftRotate(grandparent);
            }
        }
        private void LeftRotate(Node x)
        {
            var y = x.Right;
            x.Right = y.Left;
            if (y.Left != null)
                y.Left.Parent = x;

            y.Parent = x.Parent;
            if (x.Parent == null)
                avlTree.Root = y;
            else if (x == x.Parent.Left)
                x.Parent.Left = y;
            else if (x == x.Parent.Right)
                x.Parent.Right = y;

            y.Left = x;
            x.Parent = y;
        }
        private void RightRotate(Node x)
        {
            var y = x.Left;
            x.Left = y.Right;
            if (y.Right != null)
                y.Right.Parent = x;

            y.Parent = x.Parent;
            if (x.Parent == null)
                avlTree.Root = y;
            else if (x == x.Parent.Right)
                x.Parent.Right = y;
            else if (x == x.Parent.Left)
                x.Parent.Left = y;

            y.Right = x;
            x.Parent = y;
        }
        private int GetBalance(Node node)
        {
            if (node == null) return 0;
            var lHeight = GetHeight(node.Left);
            var rHeight = GetHeight(node.Right);
            return lHeight - rHeight;
        }
        public void Inorder()
        {
            Console.WriteLine("[START]");
            Inorder(avlTree.Root);
            Console.WriteLine("[END]");
        }
        private void Inorder(Node node)
        {
            if (node != null)
            {
                Inorder(node.Left);
                Console.Write(" [{0}] ", node.Data);
                Inorder(node.Right);
            }
        }
    }
}
