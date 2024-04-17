namespace SinglyLinkList
{
    public interface ISLLQuestions
    {
        ListNode AddTwoList(ListNode link1, ListNode link2);
        void DeleteNode(ref ListNode nodeToDelete);
        ListNode GetCycleNode(ListNode head);
        int GetMiddle();
        bool IsCycleExist(ListNode head);
        bool IsPallindrome(ListNode linklist1);
        ListNode MergeTwoSortedList(ListNode link1, ListNode link2);
        ListNode MergeTwoSortedListRecursive(ListNode link1, ListNode link2);
        ListNode RemoveDuplicateFromSortedList(ListNode linklist);
        ListNode RemoveDuplicateFromSortedListInternet(ListNode head);
        ListNode RemoveNthNodeFromEndOfList(ListNode head, int n);
        ListNode SortLinkList(ListNode head);
        ListNode SwapKthNodeFromBothEnd_1(ListNode head, int k);
        ListNode SwapKthNodeFromBothEnd_2(ListNode head, int k);

    }
}