namespace BinarySearchTree
{
    public interface IBstInfrastructure
    {
        void Delete(int data);
        Node GetNode(int data);
        void Inorder(string msg = "");
        void Insert(int data);
        bool IsExist(int data);
    }
}