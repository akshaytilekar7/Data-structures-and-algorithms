namespace CSharp.AvlTree
{
    public class AvlManagement
    {
        public readonly AvlTree _avlTree;
        public AvlManagement()
        {
            this._avlTree = new AvlTree();
            this._avlTree.Root = null;
        }
        public Node GetNewNode(int data)
        {
            return new Node() { Data = data, Left = null, Right = null, Parent = null };
        }
        public void Insert(int data)
        {
            var z = GetNewNode(data);
            var node = _avlTree.Root;
            if (node == null)
            {
                _avlTree.Root = z;
                return;
            }

            while (true)
            {
                if (data <= node.Data)
                {
                    if (node.Left == null)
                    {
                        node.Left = z;
                        z.Parent = node;
                        break;
                    }
                    else
                    {
                        node = node.Left;
                        continue;
                    }
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = z;
                        z.Parent = node;
                        break;
                    }
                    else
                    {
                        node = node.Right;
                        continue;
                    }
                }
            }

            Node child = z;
            Node parent = child.Parent;
            Node grandParent = null;
            if (parent != null)
                grandParent = parent.Parent;

            while (grandParent != null)
            {
                int imbalanceCount = GetBalanceOfNode(grandParent);
                if (imbalanceCount < -1 || imbalanceCount > 1)
                    break;

                grandParent = grandParent.Parent;
                parent = parent.Parent;
                child = child.Parent;
            }

            if (grandParent == null)
                return;

            if (parent == grandParent.Left && child == parent.Left)
            {
                RightRotate(grandParent);
            }
            else if (parent == grandParent.Left && child == parent.Right)
            {
                LeftRotate(parent);
                RightRotate(grandParent);
            }
            else if (parent == grandParent.Right && child == parent.Left)
            {
                RightRotate(parent);
                LeftRotate(grandParent);
            }
            else if (parent == grandParent.Right && child == parent.Right)
            {
                LeftRotate(grandParent);
            }
        }
        public void Inorder()
        {
            Console.WriteLine("[START]");
            Inorder(_avlTree.Root);
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
        public Node GetMax()
        {
            var node = _avlTree.Root;
            while (node.Right != null)
                node = node.Right;
            return node;
        }
        public Node GetMin()
        {
            var node = _avlTree.Root;
            while (node.Left != null)
                node = node.Left;
            return node;
        }
        public Node GetNode(int data)
        {
            if (_avlTree.Root == null)
                return null;
            var node = _avlTree.Root;
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
        void LeftRotate(Node x)
        {
            /* Part 1 */
            var y = x.Right;
            x.Right = y.Left;
            if (y.Left != null)
                y.Left.Parent = x;

            /* Part 2 */
            y.Parent = x.Parent;
            if (x.Parent == null)
                _avlTree.Root = y;
            else if (x == x.Parent.Left)
                x.Parent.Left = y;
            else if (x == x.Parent.Right)
                x.Parent.Right = y;

            /* Part 3 */
            y.Left = x;
            x.Parent = y;
        }
        void RightRotate(Node x)
        {
            /* Part 1 */
            var y = x.Left;
            x.Left = y.Right;
            if (y.Right != null)
                y.Right.Parent = x;

            /* Part 2 */
            y.Parent = x.Parent;
            if (x.Parent == null)
                _avlTree.Root = y;
            else if (x == x.Parent.Left)
                x.Parent.Left = y;
            else if (x == x.Parent.Right)
                x.Parent.Right = y;

            /* Part 3 */
            y.Right = x;
            x.Parent = y;
        }
        public int GetHeight(Node node)
        {
            if (node == null)
                return 0;
            return Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
        }
        public int GetBalanceOfNode(Node node)
        {
            if (node == null) return 0;
            int leftHeight = GetHeight(node.Left);
            int rightHeight = GetHeight(node.Right);
            return leftHeight - rightHeight;
        }
        public Node FindImbalanceFromNodeToRoot(Node node)
        {
            if (node == null)
                return (null);

            var travel = node;
            while (travel != null)
            {
                int imbalanceCount = GetBalanceOfNode(travel);
                if (imbalanceCount < -1 || imbalanceCount > 1)
                    return travel;
                travel = travel.Parent;
            }
            return null;
        }
        public void DeleteMineAlsoWorking(Node z)
        {
            if (z == null)
                return;
            if (z.Left == null)
            {
                if (z.Parent == null)
                    _avlTree.Root = z.Right;
                else if (z == z.Parent.Left)
                    z.Parent.Left = z.Right;
                else if (z == z.Parent.Right)
                    z.Parent.Right = z.Right;
                if (z.Right != null)
                    z.Right.Parent = z.Parent;
                z = z.Right;
            }
            else if (z.Right == null)
            {
                if (z.Parent == null)
                    _avlTree.Root = z.Left;
                else if (z == z.Parent.Left)
                    z.Parent.Left = z.Left;
                else if (z == z.Parent.Right)
                    z.Parent.Right = z.Left;
                if (z.Left != null)
                    z.Left.Parent = z.Parent;
                z = z.Left;
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
                if (z.Parent == null)
                    _avlTree.Root = w;
                else if (z == z.Parent.Left)
                    z.Parent.Left = w;
                else if (z == z.Parent.Right)
                    z.Parent.Right = w;

                w.Parent = z.Parent;
                w.Left = z.Left;
                w.Left.Parent = w;
                z = w;
            }
            Node grandparent = z;
            Node child = null;
            Node parent = null;

            while ((grandparent = FindImbalanceFromNodeToRoot(grandparent)) != null)
            {
                var heightLeftsubTree = GetHeight(grandparent.Left);
                var heightRightsubTree = GetHeight(grandparent.Right);
                if (heightLeftsubTree > heightRightsubTree)
                    parent = grandparent.Left;
                else parent = grandparent.Right;

                if (parent != null)
                {
                    heightLeftsubTree = GetHeight(parent.Left);
                    heightRightsubTree = GetHeight(parent.Right);
                    if (heightLeftsubTree > heightRightsubTree)
                        child = parent.Left;
                    else child = parent.Right;
                }

                if (!(child != null && parent != null && grandparent != null))
                    break;

                if (child == parent.Left && parent == grandparent.Left)
                {
                    RightRotate(grandparent);
                }
                else if (child == parent.Right && parent == grandparent.Left)
                {
                    LeftRotate(parent);
                    RightRotate(grandparent);
                }
                else if (child == parent.Left && parent == grandparent.Right)
                {
                    RightRotate(parent);
                    LeftRotate(grandparent);
                }
                else if (child == parent.Right && parent == grandparent.Right)
                {
                    LeftRotate(grandparent);
                }
            }
        }
        public void DeleteWorking(Node z)
        {
            if (z == null)
                return;
            if (z.Left == null)
            {
                Transplant(z, z.Right);
                z = z.Right;
            }
            else if (z.Right == null)
            {
                Transplant(z, z.Left);
                z = z.Left;
            }
            else
            {
                var w = z.Right;
                while (w.Left != null)
                    w = w.Left;

                if (z.Right != w)
                {
                    Transplant(w, w.Right);
                    w.Right = z.Right;
                    w.Right.Parent = w;
                }

                Transplant(z, w);
                // w.Parent = z.Parent;
                w.Left = z.Left;
                w.Left.Parent = w;
                z = w;
            }
            Node grandparent = z;
            Node child = null;
            Node parent = null;

            while ((grandparent = FindImbalanceFromNodeToRoot(grandparent)) != null)
            {
                var heightLeftsubTree = GetHeight(grandparent.Left);
                var heightRightsubTree = GetHeight(grandparent.Right);
                if (heightLeftsubTree > heightRightsubTree)
                    parent = grandparent.Left;
                else parent = grandparent.Right;

                if (parent != null)
                {
                    heightLeftsubTree = GetHeight(parent.Left);
                    heightRightsubTree = GetHeight(parent.Right);
                    if (heightLeftsubTree > heightRightsubTree)
                        child = parent.Left;
                    else child = parent.Right;
                }

                if (!(child != null && parent != null && grandparent != null))
                    break;

                if (child == parent.Left && parent == grandparent.Left)
                {
                    RightRotate(grandparent);
                }
                else if (child == parent.Right && parent == grandparent.Left)
                {
                    LeftRotate(parent);
                    RightRotate(grandparent);
                }
                else if (child == parent.Left && parent == grandparent.Right)
                {
                    RightRotate(parent);
                    LeftRotate(grandparent);
                }
                else if (child == parent.Right && parent == grandparent.Right)
                {
                    LeftRotate(grandparent);
                }
            }
        }
        public void DeleteWorkinExpanded(Node z)
        {
            if (z == null)
                return;
            if (z.Left == null)
            {
                if (z.Parent == null)
                    _avlTree.Root = z.Right;
                else if (z == z.Parent.Left)
                    z.Parent.Left = z.Right;
                else if (z == z.Parent.Right)
                    z.Parent.Right = z.Right;
                if (z.Right != null)
                    z.Right.Parent = z.Parent;
                z = z.Right;
            }
            else if (z.Right == null)
            {
                if (z.Parent == null)
                    _avlTree.Root = z.Left;
                else if (z == z.Parent.Left)
                    z.Parent.Left = z.Left;
                else if (z == z.Parent.Right)
                    z.Parent.Right = z.Left;
                if (z.Left != null)
                    z.Left.Parent = z.Parent;

                z = z.Left;
            }
            else
            {
                var w = z.Right;
                while (w.Left != null)
                    w = w.Left;

                if (z.Right != w)
                {
                    if (w.Parent == null)
                        _avlTree.Root = w.Right;
                    else if (w == w.Parent.Left)
                        w.Parent.Left = w.Right;
                    else if (w == w.Parent.Right)
                        w.Parent.Right = w.Right;
                    if (w.Right != null)
                        w.Right.Parent = w.Parent;


                    w.Right = z.Right;
                    w.Right.Parent = w;
                }

                if (z.Parent == null)
                    _avlTree.Root = w;
                else if (z == z.Parent.Left)
                    z.Parent.Left = w;
                else if (z == z.Parent.Right)
                    z.Parent.Right = w;
                if (w != null)
                    w.Parent = z.Parent;

                // w.Parent = z.Parent;
                w.Left = z.Left;
                w.Left.Parent = w;
                z = w;
            }
            Node grandparent = z;
            Node child = null;
            Node parent = null;

            while ((grandparent = FindImbalanceFromNodeToRoot(grandparent)) != null)
            {
                var heightLeftsubTree = GetHeight(grandparent.Left);
                var heightRightsubTree = GetHeight(grandparent.Right);
                if (heightLeftsubTree > heightRightsubTree)
                    parent = grandparent.Left;
                else parent = grandparent.Right;

                if (parent != null)
                {
                    heightLeftsubTree = GetHeight(parent.Left);
                    heightRightsubTree = GetHeight(parent.Right);
                    if (heightLeftsubTree > heightRightsubTree)
                        child = parent.Left;
                    else child = parent.Right;
                }

                if (!(child != null && parent != null && grandparent != null))
                    break;

                if (child == parent.Left && parent == grandparent.Left)
                {
                    RightRotate(grandparent);
                }
                else if (child == parent.Right && parent == grandparent.Left)
                {
                    LeftRotate(parent);
                    RightRotate(grandparent);
                }
                else if (child == parent.Left && parent == grandparent.Right)
                {
                    RightRotate(parent);
                    LeftRotate(grandparent);
                }
                else if (child == parent.Right && parent == grandparent.Right)
                {
                    LeftRotate(grandparent);
                }
            }
        }
        public void DeleteGithubChangesWorking(Node z)
        {
            if (z.Left == null)
            {
                var y = z.Right;
                if (z.Right != null)
                    z.Right.Parent = z.Parent;
                if (z.Parent == null)
                    _avlTree.Root = y;
                else if (z == z.Parent.Left)
                    z.Parent.Left = y;
                else if (z == z.Parent.Right)
                    z.Parent.Right = y;
                z = z.Right;
            }
            else if (z.Right == null)
            {
                var y = z.Left;
                if (z.Left != null)
                    z.Left.Parent = z.Parent;

                if (z.Parent == null)
                    _avlTree.Root = y;
                else if (z == z.Parent.Left)
                    z.Parent.Left = y;
                else if (z == z.Parent.Right)
                    z.Parent.Right = y;
                z = z.Left;
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
                if (z.Parent == null)
                    _avlTree.Root = w;
                else if (z == z.Parent.Left)
                    z.Parent.Left = w;
                else if (z == z.Parent.Right)
                    z.Parent.Right = w;

                w.Left = z.Left;
                w.Left.Parent = w;
                w.Parent = z.Parent;
                z = w;
            }

            Node grandparent = z;
            Node child = null;
            Node parent = null;

            while ((grandparent = FindImbalanceFromNodeToRoot(grandparent)) != null)
            {
                var heightLeftsubTree = GetHeight(grandparent.Left);
                var heightRightsubTree = GetHeight(grandparent.Right);
                if (heightLeftsubTree > heightRightsubTree)
                    parent = grandparent.Left;
                else parent = grandparent.Right;

                if (parent != null)
                {
                    heightLeftsubTree = GetHeight(parent.Left);
                    heightRightsubTree = GetHeight(parent.Right);
                    if (heightLeftsubTree > heightRightsubTree)
                        child = parent.Left;
                    else child = parent.Right;
                }

                if (!(child != null && parent != null && grandparent != null))
                    break;

                if (child == parent.Left && parent == grandparent.Left)
                {
                    RightRotate(grandparent);
                }
                else if (child == parent.Right && parent == grandparent.Left)
                {
                    LeftRotate(parent);
                    RightRotate(grandparent);
                }
                else if (child == parent.Left && parent == grandparent.Right)
                {
                    RightRotate(parent);
                    LeftRotate(grandparent);
                }
                else if (child == parent.Right && parent == grandparent.Right)
                {
                    LeftRotate(grandparent);
                }
            }

        }
        public void DeleteGithubChangesWorking2(Node z)
        {
            var temp = z;
            if (z.Left == null)
            {
                var y = z.Right;
                if (z.Right != null)
                    z.Right.Parent = z.Parent;
                if (z.Parent == null)
                    _avlTree.Root = y;
                else if (z == z.Parent.Left)
                    z.Parent.Left = y;
                else if (z == z.Parent.Right)
                    z.Parent.Right = y;
                z = z.Right;
            }
            else if (z.Right == null)
            {
                var y = z.Left;
                if (z.Left != null)
                    z.Left.Parent = z.Parent;

                if (z.Parent == null)
                    _avlTree.Root = y;
                else if (z == z.Parent.Left)
                    z.Parent.Left = y;
                else if (z == z.Parent.Right)
                    z.Parent.Right = y;
                z = z.Left;
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
                if (z.Parent == null)
                    _avlTree.Root = w;
                else if (z == z.Parent.Left)
                    z.Parent.Left = w;
                else if (z == z.Parent.Right)
                    z.Parent.Right = w;

                w.Left = z.Left;
                w.Left.Parent = w;
                w.Parent = z.Parent;
                z = w;
            }
            Node grandparent = z;
            Node child = null;
            Node parent = null;

            temp = null;

            while ((grandparent = FindImbalanceFromNodeToRoot(grandparent)) != null)
            {
                var heightLeftsubTree = GetHeight(grandparent.Left);
                var heightRightsubTree = GetHeight(grandparent.Right);
                if (heightLeftsubTree > heightRightsubTree)
                    parent = grandparent.Left;
                else parent = grandparent.Right;

                if (parent != null)
                {
                    heightLeftsubTree = GetHeight(parent.Left);
                    heightRightsubTree = GetHeight(parent.Right);
                    if (heightLeftsubTree > heightRightsubTree)
                        child = parent.Left;
                    else child = parent.Right;
                }

                if (child != null && parent != null && grandparent != null)
                    break;

                if (child == parent.Left && parent == grandparent.Left)
                {
                    RightRotate(grandparent);
                }
                else if (child == parent.Right && parent == grandparent.Right)
                {
                    LeftRotate(grandparent);
                }
                else if (child == parent.Left && parent == grandparent.Right)
                {
                    RightRotate(parent);
                    LeftRotate(grandparent);
                }
                else if (child == parent.Right && parent == grandparent.Left)
                {
                    LeftRotate(parent);
                    RightRotate(grandparent);
                }
            }
        }

        // DeleteWithErrorFixesCommentWhereErrorWasS
        public void Delete(Node z)
        {
            var temp = z;
            if (z.Left == null)
            {
                var y = z.Right;
                if (z.Right != null)
                    z.Right.Parent = z.Parent;
                if (z.Parent == null)
                    _avlTree.Root = y;
                else if (z == z.Parent.Left)
                    z.Parent.Left = y;
                else if (z == z.Parent.Right)
                    z.Parent.Right = y;
                z = z.Right;
            }
            else if (z.Right == null)
            {
                var y = z.Left;
                if (z.Left != null)
                    z.Left.Parent = z.Parent;

                if (z.Parent == null)
                    _avlTree.Root = y;
                else if (z == z.Parent.Left)
                    z.Parent.Left = y;
                else if (z == z.Parent.Right)
                    z.Parent.Right = y;
                z = z.Left;
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
                if (z.Parent == null)
                    _avlTree.Root = w;
                else if (z == z.Parent.Left)
                    z.Parent.Left = w;
                else if (z == z.Parent.Right)
                    z.Parent.Right = w; ////////////// shoubd be z prev was w

                w.Left = z.Left;
                w.Left.Parent = w;
                w.Parent = z.Parent;
                z = w;
            }
            Node grandparent = z;
            Node child = null;
            Node parent = null;

            temp = null;

            while ((grandparent = FindImbalanceFromNodeToRoot(grandparent)) != null)
            {
                var heightLeftsubTree = GetHeight(grandparent.Left);
                var heightRightsubTree = GetHeight(grandparent.Right);
                if (heightLeftsubTree > heightRightsubTree)
                    parent = grandparent.Left;
                else parent = grandparent.Right;

                if (parent != null)
                {
                    heightLeftsubTree = GetHeight(parent.Left);
                    heightRightsubTree = GetHeight(parent.Right);
                    if (heightLeftsubTree > heightRightsubTree)
                        child = parent.Left;  ////////// should be parent - grandparent
                    else child = parent.Right;  ////////// should be parent instead grandparent
                }

                if (child != null && parent != null && grandparent != null)
                    break;

                if (child == parent.Left && parent == grandparent.Left)
                {
                    RightRotate(grandparent);
                }
                else if (child == parent.Right && parent == grandparent.Right)
                {
                    LeftRotate(grandparent);
                }
                else if (child == parent.Left && parent == grandparent.Right)
                {
                    RightRotate(parent);
                    LeftRotate(grandparent);
                }
                else if (child == parent.Right && parent == grandparent.Left)
                {
                    LeftRotate(parent);
                    RightRotate(grandparent);
                }
            }
        }

        private void Transplant(Node u, Node v)
        {
            if (u.Parent == null)
                _avlTree.Root = v;
            else if (u == u.Parent.Left)
                u.Parent.Left = v;
            else if (u == u.Parent.Right)
                u.Parent.Right = v;
            if (v != null)
                v.Parent = u.Parent;
        }
    }
}
