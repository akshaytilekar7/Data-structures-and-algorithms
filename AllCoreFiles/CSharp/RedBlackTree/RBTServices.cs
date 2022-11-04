namespace AllCoreFiles.CSharp.RedBlackTree1
{
    public class RBTServices
    {
        public readonly RbTree RbTree;
        public RBTServices()
        {
            RbTree = new RbTree();
            RbTree.Nil = new Node();
            RbTree.Nil.Color = Color.BLACK;
            RbTree.Nil.Data = -1;
            RbTree.Nil.Left = RbTree.Nil;
            RbTree.Nil.Right = RbTree.Nil;
            RbTree.Nil.Parent = RbTree.Nil;
            RbTree.Root = RbTree.Nil;
        }
        public Node GetNode(int data, Node pNil)
        {
            Node newNode = new Node();
            newNode.Data = data;
            newNode.Color = Color.RED;
            newNode.Left = pNil;
            newNode.Right = pNil;
            newNode.Parent = pNil;
            return newNode;
        }
        public void Insert(int data)
        {
            if (RbTree.Root == RbTree.Nil)
            {
                RbTree.Root = GetNode(data, RbTree.Nil);
                RbTree.Count++;
                return;
            }

            InsertHelper(RbTree.Root, data);
            RbTree.Count++;
            return;
        }
        public Node GetMaxNode(Node node)
        {
            Node travel = node;
            while (travel.Right != RbTree.Nil)
                travel = travel.Right;
            return travel;
        }
        public Node GetMinNode(Node node)
        {
            Node travel = node;
            while (travel.Left != RbTree.Nil)
                travel = travel.Left;
            return travel;
        }
        public int GetHeight(Node node)
        {
            if (node == RbTree.Nil)
                return 0;
            return 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        }
        public int InsertItrative(int new_data)
        {
            var z = GetNode(new_data, RbTree.Nil);

            if (RbTree.Root == RbTree.Nil)
            {
                RbTree.Root = z;
                RbTree.Count += 1;
                InsertFixup(z);
                return (1);
            }

            var p_run = RbTree.Root;
            while (true)
            {
                if (new_data <= p_run.Data)
                {
                    if (p_run.Left == RbTree.Nil)
                    {
                        p_run.Left = z;
                        z.Parent = p_run;
                        break;
                    }
                    else
                        p_run = p_run.Left;
                }
                else
                {
                    if (p_run.Right == RbTree.Nil)
                    {
                        p_run.Right = z;
                        z.Parent = p_run;
                        break;
                    }
                    else
                        p_run = p_run.Right;
                }
            }

            RbTree.Count += 1;
            InsertFixup(z);
            return (1);
        }

        #region traversal
        public void InorderHelper(Node root)
        {
            if (root != RbTree.Nil)
            {
                InorderHelper(root.Left);
                Console.Write(" " + root.Data);
                InorderHelper(root.Right);
            }
        }
        public void Inorder()
        {
            Console.Write("[IN]");
            InorderHelper(RbTree.Root);
            Console.Write(" [END]\n");
        }

        #endregion #region
        private void InsertFixup(Node newNode)
        {
            while (newNode.Parent.Color == Color.RED)
            {
                if (newNode.Parent == newNode.Parent.Parent.Left)
                {
                    var uncle = newNode.Parent.Parent.Right;
                    if (uncle.Color == Color.RED)
                    {
                        newNode.Parent.Color = uncle.Color = Color.BLACK;
                        newNode.Parent.Parent.Color = Color.RED;
                        newNode = newNode.Parent.Parent;
                    }
                    else
                    {
                        if (newNode == newNode.Parent.Right)
                        {
                            newNode = newNode.Parent;
                            LeftRotate(newNode);
                        }
                        newNode.Parent.Color = Color.BLACK;
                        newNode.Parent.Parent.Color = Color.RED;
                        RightRotate(newNode.Parent.Parent);
                    }
                }
                else
                {
                    var uncle = newNode.Parent.Parent.Left;
                    if (uncle.Color == Color.RED)
                    {
                        newNode.Parent.Color = uncle.Color = Color.BLACK;
                        newNode.Parent.Parent.Color = Color.RED;
                        newNode = newNode.Parent.Parent;
                    }
                    else
                    {
                        if (newNode == newNode.Parent.Left)
                        {
                            newNode = newNode.Parent;
                            RightRotate(newNode);
                        }
                        newNode.Parent.Color = Color.BLACK;
                        newNode.Parent.Parent.Color = Color.RED;
                        LeftRotate(newNode.Parent.Parent);
                    }
                }
            }
            RbTree.Root.Color = Color.BLACK;
        }
        private Node InsertHelper(Node currnetNode, int newData)
        {
            if (currnetNode == RbTree.Nil)
            {
                currnetNode = GetNode(newData, RbTree.Nil);
                return currnetNode;
            }
            else
            {
                if (currnetNode.Data < newData)
                {
                    currnetNode.Right = InsertHelper(currnetNode.Right, newData);
                    currnetNode.Right.Parent = currnetNode;
                }
                else
                {
                    currnetNode.Left = InsertHelper(currnetNode.Left, newData);
                    currnetNode.Left.Parent = currnetNode;
                }
            }
            InsertFixup(currnetNode);
            return currnetNode;
        }
        private void LeftRotate(Node x)
        {
            Node y = x.Right;
            x.Right = y.Left;
            if (y.Left != RbTree.Nil)
                y.Left.Parent = x;

            y.Parent = x.Parent;
            if (x.Parent == RbTree.Nil)
                RbTree.Root = y;
            else if (x.Parent.Left == x)
                x.Parent.Left = y;
            else if (x.Parent.Right == x)
                x.Parent.Right = y;

            y.Left = x;
            x.Parent = y;
        }
        private void RightRotate(Node x)
        {
            Node y = x.Left;
            x.Left = y.Right;
            if (y.Right != RbTree.Nil)
                y.Right.Parent = x;

            y.Parent = x.Parent;
            if (x.Parent == RbTree.Nil)
                RbTree.Root = y;
            else if (x.Parent.Right == x)
                x.Parent.Right = y;
            else if (x.Parent.Left == x)
                x.Parent.Left = y;

            y.Right = x;
            x.Parent = y;
        }
        public void Delete(Node z)
        {
            Node problematicSubtreeNode = RbTree.Nil;
            var y = z;
            var yColor = y.Color;

            if (z.Left == RbTree.Nil)
            {
                problematicSubtreeNode = z.Right;

                if (RbTree.Root == z)
                    RbTree.Root = z.Right;
                else if (z == z.Parent.Left)
                    z.Parent.Left = z.Right;
                else if (z == z.Parent.Right)
                    z.Parent.Right = z.Right;

                if (z.Right != RbTree.Nil)
                    z.Right.Parent = z.Parent;

            }
            else if (z.Right == RbTree.Nil)
            {
                problematicSubtreeNode = z.Left;
                if (RbTree.Root == z)
                    RbTree.Root = z.Left;
                else if (z == z.Parent.Left)
                    z.Parent.Left = z.Left;
                else if (z == z.Parent.Right)
                    z.Parent.Right = z.Left;

                if (z.Left != RbTree.Nil)
                    z.Left.Parent = z.Parent;
            }
            else
            {
                var w = z.Right;
                while (w.Left != RbTree.Nil)
                    w = w.Left;

                y = w;
                yColor = y.Color; // save IS color - bcz if it is black then problem
                problematicSubtreeNode = w.Right;

                if (w != z.Right)
                {
                    w.Parent.Left = w.Right;
                    if (w.Right != RbTree.Nil)
                        w.Right.Parent = w.Parent;

                    w.Right = z.Left;
                    w.Right.Parent = w;
                }

                if (RbTree.Root == z)
                    RbTree.Root = w;
                else if (z == z.Parent.Left)
                    z.Parent.Left = w;
                else if (z == z.Parent.Right)
                    z.Parent.Right = w;

                w.Left = z.Left;
                w.Left.Parent = z;
                w.Parent = z.Parent;
                w.Color = z.Color;
                // IS get deleted color, so trasnpose problem in RST instead of both tree
            }
            if (yColor == Color.BLACK && problematicSubtreeNode != RbTree.Nil)
                DeleteFixup(z);
        }
        public void DeleteFixup(Node x)
        {
            while (x != RbTree.Root && x.Color == Color.BLACK)
            {
                if (x == x.Parent.Left)
                {
                    var brother = x.Parent.Right;

                    if (brother.Color == Color.RED)
                    {

                    }
                    else if (brother.Left.Color == Color.BLACK && brother.Right.Color == Color.BLACK)
                    {

                    }
                    else 
                    {
                        if (brother.Right.Color == Color.RED)
                        {
                            
                        }
                    }
                }
                else
                {

                }
            }
        }
    }
}
