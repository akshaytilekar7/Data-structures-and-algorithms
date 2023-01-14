namespace BinarySearchTree
{
    public class BstService : BstInfrastructure
    {
        public int GetHeight()
        {
            return GetHeight(tree.Root);
        }
        private int GetHeight(Node node)
        {
            if (node == null)
                return 0;

            return 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
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
        public void SpiralPrint()
        {
            Console.WriteLine("\n SpiralPrint Start\n");

            var node = tree.Root;
            if (node == null)
                return;
            Stack<Node> stack1 = new Stack<Node>(); // rigth to left
            Stack<Node> stack2 = new Stack<Node>(); // left to right

            stack1.Push(node);

            while (stack1.Count > 0 || stack2.Count > 0)
            {
                if (stack1.Count == 0)
                {
                    while (stack2.Count != 0)
                    {
                        var pop = stack2.Pop();
                        Console.Write(" [{0}] ", pop.Data);
                        if (pop.Right != null)
                            stack1.Push(pop.Right);
                        if (pop.Left != null)
                            stack1.Push(pop.Left);
                    }
                    Console.WriteLine();
                }
                if (stack2.Count == 0)
                {
                    while (stack1.Count != 0)
                    {
                        var pop = stack1.Pop();
                        Console.Write(" [{0}] ", pop.Data);
                        if (pop.Left != null)
                            stack2.Push(pop.Left);
                        if (pop.Right != null)
                            stack2.Push(pop.Right);
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine(" SpiralPrint End ");
        }
        public int GetDiameter()
        {
            return Diameter(tree.Root);
        }
        public int Diameter(Node root)
        {
            // Diameter Number of nodes on the longest path between two end nodes.
            // Diameter at each node is defined by 1 + leftHeight + rightHeight.
            // Just calculate that at each node to get the maximum diameter.
            // Hence use the height method and just add the
            // Add a line to calculate the diameter which gives the O(N) solution.
            int diameter = 0;
            GetHeight(root);
            return diameter;

            int GetHeight(Node root)
            {
                if (root == null)
                    return 0;

                int lHeight = GetHeight(root.Left);
                int rHeight = GetHeight(root.Right);

                diameter = Math.Max(diameter, 1 + lHeight + rHeight);

                return 1 + Math.Max(lHeight, rHeight);
            }
        }
        public int GetWidth()
        {
            return GetWidth(tree.Root);
        }
        private int GetWidth(Node node)
        {
            // https://www.youtube.com/watch?v=poOw9DDMZKw
            // number nodes between left and rigth MOST nodes in each leval
            // dont include null nodes which exist at boundries
            if (node == null) return 0;
            List<Node> lst = new List<Node>();
            lst.Add(node);
            int max = 0;
            while (lst.Any())
            {
                while (lst.Any() && lst.LastOrDefault() == null) lst.RemoveAt(lst.Count() - 1);
                while (lst.Any() && lst.FirstOrDefault() == null) lst.RemoveAt(0);
                max = Math.Max(lst.Count(), max);
                int size = lst.Count();
                for (int i = 0; i < size; i++)
                {
                    var item = lst.First();
                    lst.Remove(lst.First());
                    if (item == null)
                    {
                        lst.Add(null);
                        lst.Add(null);
                    }
                    else
                    {
                        lst.Add(item.Left);
                        lst.Add(item.Right);
                    }
                }
            }

            return max;
        }
    }
}
