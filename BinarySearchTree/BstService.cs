namespace BinarySearchTree
{
    public class BstService
    {
        BinarySearchTree binarySearchTree;
        public BstService()
        {
            binarySearchTree = new BinarySearchTree();
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
            if (binarySearchTree.Root == null)
            {
                binarySearchTree.Root = newNode;
                return;
            }

            var node = binarySearchTree.Root;
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
            var node = binarySearchTree.Root;
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


        }
        public void Inorder()
        {
            Console.Write("Inorder Start\t");
            Inorder(binarySearchTree.Root);
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

    }
}
