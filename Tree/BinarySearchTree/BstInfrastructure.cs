namespace BinarySearchTree
{
    public class BstInfrastructure : IBstInfrastructure
    {
        public BinarySearchTree tree;
        public BstInfrastructure()
        {
            tree = new BinarySearchTree();
        }
        private Node GetNewNode(int data)
        {
            var node = new Node();
            node.Data = data;
            return node;
        }
        public void Insert(int data)
        {
            var newNode = GetNewNode(data);
            if (tree.Root == null)
            {
                tree.Root = newNode;
                return;
            }

            var node = tree.Root;
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
        }
        public bool IsExist(int data)
        {
            return GetNode(data) != null;
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

            if (z.Left == null)
            {
                if (z == tree.Root)
                    tree.Root = z.Right;
                else if (z.Parent.Left == z)
                    z.Parent.Left = z.Right;
                else if (z.Parent.Right == z)
                    z.Parent.Right = z.Right;

                if (z.Right != null)
                    z.Right.Parent = z.Parent;
            }
            else if (z.Right == null)
            {
                if (z == tree.Root)
                    tree.Root = z.Left;
                else if (z.Parent.Left == z)
                    z.Parent.Left = z.Left;
                else if (z.Parent.Right == z)
                    z.Parent.Right = z.Left;

                if (z.Left != null)
                    z.Left.Parent = z.Parent;
            }
            else
            {
                var w = z.Right;
                while (w.Left != null)
                    w = w.Left;

                if (z.Right != w)
                {
                    w.Parent.Left = w.Right;
                    if (w.Right != null)
                        w.Right.Parent = w.Parent;

                    w.Right = z.Right;
                    w.Right.Parent = w;
                }

                w.Left = z.Left;
                w.Left.Parent = w;

                if (tree.Root == z)
                    tree.Root = w;
                else if (z == z.Parent.Left)
                    z.Parent.Left = w;
                else if (z == z.Parent.Right)
                    z.Parent.Right = w;

                w.Parent = z.Parent;
            }
        }
        public void Inorder(string msg = "")
        {
            Console.WriteLine(msg);
            Console.Write("Inorder Start\t");
            Inorder(tree.Root);
            Console.Write("\tInorder End\n");
        }
        private void Inorder(Node node)
        {
            if (node != null)
            {
                Inorder(node.Left);
                Console.Write("[{0}] ", node.Data);
                Inorder(node.Right);
            }
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

    }
}
