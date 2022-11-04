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
            RbTree.Nil.Right = null;
            RbTree.Nil.Right = null;
            RbTree.Nil.Parent = null;
            RbTree.Root = RbTree.Nil;
        }
        public Node GetNode(int data, Node pNil)
        {
            Node newNode = new Node();
            newNode.Data = data;
            newNode.Color = Color.RED;
            newNode.Right = pNil;
            newNode.Right = pNil;
            newNode.Parent = pNil;
            return newNode;
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
        public void Insert(int data)
        {
            var newNode = InsertHelper(data);
            InsertFixup(newNode);
        }
        private Node InsertHelper(int data)
        {
            var z = GetNewNode(data);

            if (RbTree.Root == RbTree.Nil)
            {
                RbTree.Root = z;
                return z;
            }

            var node = RbTree.Root;
            while (true)
            {
                if (data <= node.Data)
                {
                    if (node.Left == RbTree.Nil)
                    {
                        node.Left = z;
                        z.Parent = node;
                        return z;
                    }
                    node = node.Left;
                }
                else
                {
                    if (node.Right == RbTree.Nil)
                    {
                        node.Right = z;
                        z.Parent = node;
                        return z;
                    }
                    node = node.Right;
                }
            }
        }
        private void InsertFixup(Node z)
        {
            while (z.Parent.Color == Color.RED)
            {
                if (z.Parent == z.Parent.Parent.Left)
                {
                    var uncle = z.Parent.Parent.Right;
                    if (uncle.Color == Color.RED)
                    {
                        z.Parent.Color = uncle.Color = Color.BLACK;
                        z.Parent.Parent.Color = Color.RED;
                        z = z.Parent.Parent;
                    }
                    else
                    {
                        if (z == z.Parent.Right)
                        {
                            z = z.Parent;
                            LeftRotate(z);
                        }
                        z.Parent.Color = Color.BLACK;
                        z.Parent.Parent.Color = Color.RED;
                        RightRotate(z.Parent.Parent);
                    }
                }
                else
                {
                    var uncle = z.Parent.Parent.Left;
                    if (uncle.Color == Color.RED)
                    {
                        z.Parent.Color = uncle.Color = Color.BLACK;
                        z.Parent.Parent.Color = Color.RED;
                        z = z.Parent.Parent;
                    }
                    else
                    {
                        if (z == z.Parent.Left)
                        {
                            z = z.Parent;
                            RightRotate(z);
                        }
                        z.Parent.Color = Color.BLACK;
                        z.Parent.Parent.Color = Color.RED;
                        LeftRotate(z.Parent.Parent);
                    }
                }
            }
            RbTree.Root.Color = Color.BLACK;
        }
        private void LeftRotate(Node x)
        {
            var y = x.Right;
            x.Right = y.Left;
            if (y.Left != RbTree.Nil)
                y.Left.Parent = x;

            y.Parent = x.Parent;
            if (x.Parent == RbTree.Nil)
                RbTree.Root = y;
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
            if (y.Right != RbTree.Nil)
                y.Right.Parent = x;

            y.Parent = x.Parent;
            if (x.Parent == RbTree.Nil)
                RbTree.Root = y;
            else if (x == x.Parent.Left)
                x.Parent.Left = y;
            else if (x == x.Parent.Right)
                x.Parent.Right = y;

            y.Right = x;
            x.Parent = y;
        }
        public void DeleteNotWorking(Node z)
        {
            var y = z;
            var yColor = y.Color;

            if (z.Left == RbTree.Nil)
            {
                y = z.Right;

                if (RbTree.Root == z)
                    RbTree.Root = z.Right;
                else if (z == z.Parent.Right)
                    z.Parent.Right = z.Right;
                else if (z == z.Parent.Left)
                    z.Parent.Left = z.Right;

                if (z.Right != RbTree.Nil)
                    z.Right.Parent = z.Parent;

            }
            else if (z.Right == RbTree.Nil)
            {
                y = z.Left;
                if (RbTree.Root == z)
                    RbTree.Root = z.Left;
                else if (z == z.Parent.Right)
                    z.Parent.Right = z.Left;
                else if (z == z.Parent.Left)
                    z.Parent.Left = z.Left;

                if (z.Left != RbTree.Nil)
                    z.Left.Parent = z.Parent;
            }
            else
            {
                var w = z.Right;
                while (w.Left != RbTree.Nil)
                    w = w.Left;

                y = w.Right; //////CHECK
                y = w;
                yColor = y.Color; // save IS color - bcz if it is black then problem

                if (w != z.Right)
                {
                    w.Parent.Left = w.Right;
                    if (w.Right != RbTree.Nil)
                        w.Right.Parent = w.Parent;

                    w.Right = z.Right;
                    w.Right.Parent = w;
                }

                if (RbTree.Root == z)
                    RbTree.Root = w;
                else if (z == z.Parent.Right)
                    z.Parent.Right = w;
                else if (z == z.Parent.Left)
                    z.Parent.Left = w;

                w.Left = z.Right;
                w.Left.Parent = z;
                w.Parent = z.Parent;
                w.Color = z.Color;
                // IS get deleted color, so trasnpose problem in RST instead of both tree
            }
            if (yColor == Color.BLACK && y != RbTree.Nil)
                DeleteFixup(z);
        }
        public void Delete(Node z)
        {
            Node x = null;
            Node y = null;
            Color y_original_color = Color.NILL;
            if (z == null)
                return;
            if (z.Left == RbTree.Nil)
            {
                x = z.Right;
                Transplant(z, z.Right);
            }
            else if (z.Right == RbTree.Nil)
            {
                x = z.Left;
                Transplant(z, z.Left);
            }
            else
            {
                var w = z.Right;
                while (w.Left != RbTree.Nil)
                    w = w.Left;

                y = w;
                y_original_color = y.Color;
                x = y.Right;

                if (z.Right != w)
                {
                    Transplant(w, w.Right);
                    w.Right = z.Right;
                    w.Right.Parent = w;
                }

                Transplant(z, w);
                w.Left = z.Left;
                w.Left.Parent = w;
                z = w;
            }

            if (y_original_color == Color.BLACK && x != RbTree.Nil)
                DeleteFixup(x);
        }
        private void Transplant(Node u, Node v)
        {
            if (u.Parent == RbTree.Nil)
                RbTree.Root = v;
            else if (u == u.Parent.Left)
                u.Parent.Left = v;
            else if (u == u.Parent.Right)
                u.Parent.Right = v;
            if (v != null)
                v.Parent = u.Parent;
        }
        public void DeleteFixup(Node x)
        {
            while (x != RbTree.Root && x.Color == Color.BLACK)
            {
                if (x == x.Parent.Right)
                {
                    var w = x.Parent.Right;

                    if (w.Color == Color.RED)
                    {
                        w.Color = Color.BLACK;                  /* case 1 */
                        x.Parent.Color = Color.RED;             /* case 1 */
                        LeftRotate(x.Parent);                   /* case 1 */
                        w = x.Parent.Right;                     /* case 1 */
                    }

                    if (w == RbTree.Nil)
                    {
                        x = x.Parent;
                        continue;
                    }
                    if (w.Right.Color == Color.BLACK && w.Right.Color == Color.BLACK)
                    {
                        w.Color = Color.RED;
                        x = x.Parent;
                    }
                    else
                    {
                        if (w.Right.Color == Color.BLACK)
                        {
                            w.Right.Color = Color.BLACK;        /* case 3 */
                            w.Color = Color.RED;                /* case 3 */
                            RightRotate(w);                     /* case 3 */
                            w = x.Parent.Right;                 /* case 3 */
                        }
                        w.Color = x.Parent.Color;               /* case 4 */
                        x.Parent.Color = Color.BLACK;           /* case 4 */
                        w.Right.Color = Color.BLACK;            /* case 4 */
                        LeftRotate(x.Parent);                   /* case 4 */
                        x = RbTree.Root;

                    }
                }
                else
                {
                    var w = x.Parent.Left;

                    if (w.Color == Color.RED)
                    {
                        w.Color = Color.BLACK;
                        x.Parent.Color = Color.RED;
                        RightRotate(x.Parent);
                        w = x.Parent.Left;
                    }

                    if (w == RbTree.Nil)
                    {
                        x = x.Parent;
                        continue;
                    }
                    if (w.Right.Color == Color.BLACK && w.Left.Color == Color.BLACK)
                    {
                        w.Color = Color.RED;
                        x = x.Parent;
                    }
                    else
                    {
                        if (w.Left.Color == Color.BLACK)
                        {
                            w.Right.Color = Color.BLACK;
                            w.Color = Color.RED;
                            LeftRotate(w);
                            w = x.Parent.Left;
                        }
                        w.Color = x.Parent.Color;
                        x.Parent.Color = Color.BLACK;
                        w.Left.Color = Color.BLACK;
                        RightRotate(x.Parent);
                        x = RbTree.Root;

                    }
                }
            }
            x.Color = Color.BLACK;
        }
        public Node GetNewNode(int data)
        {
            return new Node()
            {
                Data = data,
                Left = RbTree.Nil,
                Right = RbTree.Nil,
                Parent = RbTree.Nil,
            };
        }
        public Node GetNode(int data)
        {
            if (RbTree.Root == RbTree.Nil)
                return null;
            var node = RbTree.Root;
            while (true)
            {
                if (node == RbTree.Nil || node == null)
                    return null;

                if (node.Data == data)
                    return node;

                if (data < node.Data)
                    node = node.Left;
                else
                    node = node.Right;
            }
        }

    }
}
