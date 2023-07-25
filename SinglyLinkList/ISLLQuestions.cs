namespace SinglyLinkList
{
    public interface ISLLQuestions
    {
        Node AddTwoList(Node link1, Node link2);
        void DeleteNode(ref Node? nodeToDelete);
        Node GetCycleNode(Node head);
        int GetMiddle();
        bool IsCycleExist(Node head);
        bool IsPallindrome(Node linklist1);
        Node MergeTwoSortedList(Node link1, Node link2);
        Node MergeTwoSortedListRecursive(Node link1, Node link2);
        Node RemoveDuplicateFromSortedList(Node linklist);
        Node RemoveDuplicateFromSortedListInternet(Node head);
        Node RemoveNthNodeFromEndOfList(Node head, int n);
        Node SortLinkList(Node head);
        Node SwapKthNodeFromBithEnd(Node head, int k);
    }
}