namespace AvlTree
{
    public class AvlTreeService
    {
        AvlTree tree;
        public AvlTreeService()
        {
            tree = new AvlTree();
        }
        public Node GetNewNode(int data)
        {
            var node = new Node();
            node.Data = data;
            return node;
        }
        public int GetHeight()
        {
            return GetHeight(tree.Root);
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
            var node = tree.Root;
            if (node == null)
            {
                tree.Root = newNode;
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
            if (tree.Root == child) return;

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
                tree.Root = y;
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
                tree.Root = y;
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
        public void Inorder(string msg = "")
        {
            Console.WriteLine(msg);
            Console.WriteLine("[START]");
            Inorder(tree.Root);
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
        public Node GetNode(int data)
        {
            var node = tree.Root;
            while (true)
            {
                if (node == null)
                    return null;

                if (node.Data == data)
                    return node;

                if (data < node.Data)
                    node = node.Left;
                else
                    node = node.Right;
            }
        }
        public void Delete(int data)
        {
            var z = GetNode(data);
            if (z == null) return;
            var grandparent = Delete(z);
            DeleteFixup(grandparent);
        }
        public Node Delete(Node z)
        {
            Node grandparent;
            if (z.Left == null)
            {
                if (z == tree.Root)
                    tree.Root = z.Right;
                else if (z == z.Parent.Left)
                    z.Parent.Left = z.Right;
                else if (z == z.Parent.Right)
                    z.Parent.Right = z.Right;

                if (z.Right != null)
                    z.Right.Parent = z.Parent;
                grandparent = z.Right;
            }
            else if (z.Right == null)
            {
                if (z == tree.Root)
                    tree.Root = z.Left;
                else if (z == z.Parent.Left)
                    z.Parent.Left = z.Left;
                else if (z == z.Parent.Right)
                    z.Parent.Right = z.Left;

                if (z.Left != null)
                    z.Left.Parent = z.Parent;
                grandparent = z.Left;
            }
            else
            {
                var w = z.Right;
                while (w.Left != null)
                    w = w.Left;

                if (w != z.Right)
                {
                    w.Parent.Left = w.Right;
                    if (w.Right != null)
                        w.Right.Parent = w.Parent;
                    w.Right = z.Right;
                    w.Right.Parent = w;
                }

                w.Left = z.Left;
                w.Left.Parent = w;

                if (z == tree.Root)
                    tree.Root = w;
                else if (z == z.Parent.Left)
                    z.Parent.Left = w;
                else if (z == z.Parent.Right)
                    z.Parent.Right = w;
                w.Parent = z.Parent;
                grandparent = w;
            }
            return grandparent;
        }
        private void DeleteFixup(Node grandparent)
        {
            Node parent;
            Node child = null;
            while ((grandparent = GetImbalanceNodeTillRoot(grandparent)) != null)
            {
                var leftHeight = GetHeight(grandparent.Left);
                var rightHeight = GetHeight(grandparent.Right);
                if (leftHeight > rightHeight)
                    parent = grandparent.Left;
                else
                    parent = grandparent.Right;

                if (parent != null) // no need. defensive coding
                {
                    leftHeight = GetHeight(parent.Left);
                    rightHeight = GetHeight(parent.Right);
                    if (leftHeight > rightHeight)
                        child = parent.Left;
                    else
                        child = parent.Right;
                }

                // no need. defensive coding
                if (child == null || parent == null || grandparent == null)
                    break;

                FixupByRotation(child, parent, grandparent);
            }
        }
        private Node GetImbalanceNodeTillRoot(Node node)
        {
            if (node == null) return null;

            var traverse = node;
            while (traverse != null)
            {
                if (IsBalanceNotValid(traverse))
                    return traverse;
                traverse = traverse.Parent;
            }
            return null;
        }

        public bool IsEmpty()
        {
            return tree.Root == null;
        }
        public List<int> GetInorderList()
        {
            List<int> list = new List<int>();
            InorderForTestHelper(tree.Root, list);
            return list;
        }
        public void InorderForTestHelper(Node node, List<int> list)
        {
            if (node != null)
            {
                InorderForTestHelper(node.Left, list);
                list.Add(node.Data);
                InorderForTestHelper(node.Right, list);
            }
        }
        public bool IsExist(int data)
        {
            return GetNode(data) != null;
        }
    }
}
