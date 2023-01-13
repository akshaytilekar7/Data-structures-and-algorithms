namespace BinarySearchTree
{
    public class BstService
    {
        BinarySearchTree tree;
        public BstService()
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
        public void BFS()
        {
            Console.Write("BFS Start ");
            var node = tree.Root;
            if (node == null)
                return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var pop = queue.Dequeue();
                Console.Write("[{0}] ", pop.Data);
                if (pop.Left != null)
                    queue.Enqueue(pop.Left);
                if (pop.Right != null)
                    queue.Enqueue(pop.Right);
            }
            Console.WriteLine(" BFS End ");
        }
        public void LevelOrderTraverser()
        {
            Console.WriteLine("\nLevelOrderTraverser Start\n");

            var node = tree.Root;
            if (node == null)
                return;
            Queue<Node> queue1 = new Queue<Node>();
            Queue<Node> queue2 = new Queue<Node>();

            queue1.Enqueue(node);

            while (queue1.Count > 0 || queue2.Count > 0)
            {
                if (queue1.Count == 0)
                {
                    while (queue2.Count != 0)
                    {
                        var pop = queue2.Dequeue();
                        Console.Write(" [{0}] ", pop.Data);
                        if (pop.Left != null)
                            queue1.Enqueue(pop.Left);
                        if (pop.Right != null)
                            queue1.Enqueue(pop.Right);
                    }
                    Console.WriteLine();
                }
                if (queue2.Count == 0)
                {
                    while (queue1.Count != 0)
                    {
                        var pop = queue1.Dequeue();
                        Console.Write(" [{0}] ", pop.Data);
                        if (pop.Left != null)
                            queue2.Enqueue(pop.Left);
                        if (pop.Right != null)
                            queue2.Enqueue(pop.Right);
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine(" LevelOrderTraverser End ");

        }
    }
}
