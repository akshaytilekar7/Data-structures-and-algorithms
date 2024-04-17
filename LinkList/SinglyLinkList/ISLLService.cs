namespace SinglyLinkList
{
    public interface ISLLService
    {
        void AddAfter(int data, int newData);
        void AddBefore(int data, int newData);
        void AddFirst(int data);
        void AddLast(int data);
        ListNode ConcatImmutable(ListNode list1, ListNode List2);
        void ConcatMmutable(ListNode list1, ListNode List2);
        void Delete(int data);
        void DeleteAllOccurance(int data);
        void DeleteFirstOccurance(int data);
        void DeleteLastOccurance(int data);
        int GetFirst();
        int GetLast();
        int GetLength();
        int GetLengthRecursive();
        ListNode GetNode(int data);
        bool IsEmpty();
        bool IsExist(int data);
        int PopFirst();
        int PopLast();
        void Print(string message = "");
        ListNode ReverseListImmutable();
        void ReverseListMutable();
    }
}