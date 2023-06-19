namespace DoublyCircularLinkList
{
    public interface IDCLLService
    {
        void AddAfter(int data, int newData);
        void AddBefore(int data, int newData);
        void AddFirst(int data);
        void AddLast(int data);
        Node ConcatImmutable(Node list1, Node List2);
        void ConcatMmutable(Node list1, Node List2);
        void Delete(int data);
        void DeleteAllOccurance(int data);
        void DeleteFirstOccurance(int data);
        void DeleteLastOccurance(int data);
        int GetFirst();
        int GetLast();
        int GetLength();
        int GetLengthRecursive();
        Node GetNode(int data);
        bool IsEmpty();
        bool IsExist(int data);
        int PopFirst();
        int PopLast();
        void Print();
        Node ReverseListImmutable();
        void ReverseListMutable();
    }
}