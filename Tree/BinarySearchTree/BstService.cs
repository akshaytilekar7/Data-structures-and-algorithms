namespace BinarySearchTree
{
    public class BstService : BstInfrastructure, IBstService
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
        public void LevelOrderTraverser1()
        {
            Console.WriteLine("\nLevelOrderTraverser Start 1\n");

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
                        if (pop.Left != null) queue1.Enqueue(pop.Left);
                        if (pop.Right != null) queue1.Enqueue(pop.Right);
                    }
                    Console.WriteLine();
                }
                if (queue2.Count == 0)
                {
                    while (queue1.Count != 0)
                    {
                        var pop = queue1.Dequeue();
                        Console.Write(" [{0}] ", pop.Data);
                        if (pop.Left != null) queue2.Enqueue(pop.Left);
                        if (pop.Right != null) queue2.Enqueue(pop.Right);
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine(" LevelOrderTraverser End 1");
        }
        public void PrintLevelOrderTraverser2()
        {
            var result = LevelOrderTraverser2();

            foreach (var list in result)
            {
                foreach (var item in list)
                    Console.Write(item + "\t");
                Console.Write("\n");
            }
        }
        private List<List<int>> LevelOrderTraverser2()
        {
            var root = tree.Root;
            List<List<int>> result = new();
            if (root == null)
                return result;

            Queue<Node> queue = new();
            queue.Enqueue(root);

            while (queue.Count() > 0)
            {
                List<int> currentLevel = new();
                var x = queue.Count();  // VV IMP id u used directly used queue.Count() for loop interation will change
                for (int i = 0; i < x; i++)
                {
                    Node currentNode = queue.Dequeue();
                    currentLevel.Add(currentNode.Data); // same as print
                    if (currentNode.Left != null) queue.Enqueue(currentNode.Left);
                    if (currentNode.Right != null) queue.Enqueue(currentNode.Right);
                }
                result.Add(currentLevel);
            }
            return result;
        }
        public void PrintAverageOfLevels()
        {
            var result = AverageOfLevels();

            foreach (var item in result)
                Console.WriteLine(item);
        }
        public List<double> AverageOfLevels()
        {
            List<double> result = new();

            var root = tree.Root;
            if (root == null)
                return result;

            Queue<Node> queue = new();
            queue.Enqueue(root);

            while (queue.Count() > 0)
            {
                int levelSize = queue.Count();
                double sum = 0;
                for (int i = 0; i < levelSize; i++)
                {
                    var node = queue.Dequeue();
                    sum += node.Data;
                    if (node.Left != null) queue.Enqueue(node.Left);
                    if (node.Right != null) queue.Enqueue(node.Right);
                }
                sum = sum / levelSize;
                result.Add(sum);
            }
            return result;
        }
        public Node findSuccessor(Node root, int key)
        {
            if (root == null)
                return null;

            Queue<Node> queue = new();
            queue.Enqueue(root);

            while (queue.Count() > 0)
            {
                var currentNode = queue.Dequeue();
                if (currentNode.Left != null)
                    queue.Enqueue(currentNode.Left);
                if (currentNode.Right != null)
                    queue.Enqueue(currentNode.Right);
                if (currentNode.Data == key)
                    break;
            }
            return queue.Dequeue();
        }
        public void SpiralPrint1()
        {
            Console.WriteLine("\n SpiralPrint Start\n");

            var node = tree.Root;
            if (node == null)
                return;
            Stack<Node> stack1 = new Stack<Node>(); // rigth to Left
            Stack<Node> stack2 = new Stack<Node>(); // Left to right

            stack1.Push(node);

            while (stack1.Count > 0 || stack2.Count > 0)
            {
                if (stack1.Count == 0)
                {
                    while (stack2.Count != 0)
                    {
                        var pop = stack2.Pop();
                        Console.Write(" [{0}] ", pop.Data);
                        if (pop.Right != null) stack1.Push(pop.Right);
                        if (pop.Left != null) stack1.Push(pop.Left);
                    }
                    Console.WriteLine();
                }
                if (stack2.Count == 0)
                {
                    while (stack1.Count != 0)
                    {
                        var pop = stack1.Pop();
                        Console.Write(" [{0}] ", pop.Data);
                        if (pop.Left != null) stack2.Push(pop.Left);
                        if (pop.Right != null) stack2.Push(pop.Right);
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine(" SpiralPrint End ");
        }
        public void SpiralPrint2()
        {
            Console.WriteLine("\n SpiralPrint2 Start\n");
            var result = Spiral2();

            foreach (var list in result)
            {
                foreach (var item in list)
                    Console.Write(item + "\t");
                Console.Write("\n");
            }
            Console.WriteLine("\n SpiralPrint2 Start\n");
        }
        public List<List<int>> Spiral2()
        {
            var root = tree.Root;
            List<List<int>> result = new();
            if (root == null)
                return result;

            List<Node> list = new();
            list.Add(root);

            var reverse = false;

            while (list.Count() > 0)
            {
                int levelSize = list.Count();
                List<int> currentLevel = new();
                for (int i = 0; i < levelSize; i++)
                {
                    if (!reverse)
                    {
                        var currentNode = list.First();
                        list.RemoveAt(0);
                        currentLevel.Add(currentNode.Data);
                        if (currentNode.Left != null) list.Add(currentNode.Left);
                        if (currentNode.Right != null) list.Add(currentNode.Right);
                    }
                    else
                    {
                        var currentNode = list.Last();
                        list.RemoveAt(list.Count() - 1);
                        currentLevel.Add(currentNode.Data);
                        if (currentNode.Right != null) list.Add(currentNode.Right);
                        if (currentNode.Left != null) list.Add(currentNode.Left);
                    }
                }
                reverse = !reverse;
                result.Add(currentLevel);
            }
            return result;
        }
        public int GetDiameter()
        {
            return Diameter(tree.Root);
        }
        private int Diameter(Node root)
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
            // number of nodes between Left and rigth MOST nodes in each leval
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
