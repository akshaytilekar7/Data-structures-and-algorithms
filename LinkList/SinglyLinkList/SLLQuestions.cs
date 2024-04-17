namespace SinglyLinkList
{
    public class SLLQuestions : ISLLQuestions
    {
        private readonly SLLService service;
        private readonly ListNode linklist;

        public SLLQuestions(SLLService service)
        {
            this.service = service;
            linklist = this.service.linklist;
        }

        /// <summary>
        /// for odd exact mid
        /// for even mid + 1
        /// check merge sort middle 
        /// TC O(n)
        /// SC O(1)
        /// </summary>
        /// <returns></returns>
        public int GetMiddle()
        {
            ListNode slow = linklist.next;
            ListNode fast = linklist.next;

            while (fast != null && fast.next != null) // fast.Next != null IMP
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow.val;
        }

        /// <summary>
        /// TC O(n)
        /// SC O(1)
        /// Can NOT Delete last node, Not Sure
        /// </summary>
        /// <param name="node"></param>
        public void DeleteNode1(ref ListNode node)
        {
            if (node == null)
                return;

            if (node.next == null)
                node = null;
            else
            {
                int nextVal = node.next.val;
                node.next = node.next.next;
                node.val = nextVal;
            }
        }
        public void DeleteNode(ref ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }

        /// <summary>
        /// TC O(linklist1 + linklist2)
        /// SC O(linklist1 + linklist2)
        /// Note - After assigning dont forget to update node to next 
        /// </summary>
        public ListNode MergeTwoSortedList(ListNode link1, ListNode link2)
        {
            if (link1 == null) return link2;
            if (link2 == null) return link1;

            var traverse = service.GetNewNode(-100);
            var head = traverse;

            while (link1 != null && link2 != null)
            {
                if (link1.val < link2.val)
                {
                    var newNode = service.GetNewNode(link1.val);
                    traverse.next = newNode;
                    traverse = traverse.next;
                    link1 = link1.next;
                    if (link1 == null)
                    {
                        while (link2 != null)
                        {
                            newNode = service.GetNewNode(link2.val);
                            traverse.next = newNode;
                            traverse = traverse.next;
                            link2 = link2.next;
                        }
                        break;
                    }
                }
                else
                {
                    var newNode = service.GetNewNode(link2.val);
                    traverse.next = newNode;
                    traverse = traverse.next;
                    link2 = link2.next;
                    if (link2 == null)
                    {
                        while (link1 != null)
                        {
                            newNode = service.GetNewNode(link1.val);
                            traverse.next = newNode;
                            traverse = traverse.next;
                            link1 = link1.next;
                        }
                        break;
                    }
                }
            }

            return head.next;

        }

        /// <summary>
        /// TC O(linklist1 + linklist2)
        /// SC O(linklist1 + linklist2)
        /// Note -  Note : call with next 
        /// </summary>
        /// <param name="nodeToDelete"></param>
        public ListNode MergeTwoSortedListRecursive(ListNode link1, ListNode link2)
        {
            if (link1 == null) return link2;
            if (link2 == null) return link1;
            var current = service.GetNewNode(-100);
            var head = current;
            var node = MergeTwoSortedListRecursiveHelper(head, current, link1, link2);
            return node;
        }
        private ListNode MergeTwoSortedListRecursiveHelper(ListNode head, ListNode current, ListNode link1, ListNode link2)
        {
            if (link1 == null || link2 == null) return head.next;

            if (link1.val < link2.val)
            {
                var newNode = service.GetNewNode(link1.val);
                current.next = newNode;
                MergeTwoSortedListRecursiveHelper(head, current.next, link1.next, link2);
                if (link1 == null)
                {
                    while (link2 != null)
                    {
                        newNode = service.GetNewNode(link2.val);
                        current.next = newNode;
                        // here we cant use recursive as it will br recursive call with one link null and which gives exception if(link1.Data < link2.Data) case
                        current = current.next;
                        link2 = link2.next;
                    }
                    return head.next;
                }
            }
            else
            {
                var newNode = service.GetNewNode(link2.val);
                current.next = newNode;
                MergeTwoSortedListRecursiveHelper(head, current.next, link1, link2.next);
                if (link2 == null)
                {
                    while (link1 != null)
                    {
                        newNode = service.GetNewNode(link1.val);
                        current.next = newNode;
                        // here we cant use recursive as it will br recursive call with one link null and which gives exception if(link1.Data < link2.Data) case
                        current = current.next;
                        link1 = link1.next;
                    }
                    return head.next;
                }
            }

            return head.next;

        }

        /// <summary>
        /// TC O (linklist1 + linklist2)
        /// SC O ( max(linklist1,linklist2) )
        /// Note -  last carry if condition and carry, sum logic
        /// </summary>
        /// <param name="nodeToDelete"></param>
        public ListNode AddTwoList(ListNode link1, ListNode link2)
        {
            if (link1 == null) return link2;
            if (link2 == null) return link1;
            var current = service.GetNewNode(-100);
            var head = current;
            var carry = 0;

            while (link1 != null || link2 != null)
            {
                var d1 = link1 == null ? 0 : link1.val;
                var d2 = link2 == null ? 0 : link2.val;
                var sum = d1 + d2 + carry;
                carry = sum / 10;
                var total = sum % 10;

                current.next = service.GetNewNode(total);
                current = current.next;
                link1 = link1?.next;
                link2 = link2?.next;
            }

            if (carry != 0)
            {
                int data = current.val;
                current.val = carry;
                current.next = service.GetNewNode(data);
            }
            return head.next;
        }

        /// <summary>
        /// TC O(n)
        /// SC O(1)
        /// Note : while (fast.Next != null && fast.Next.Next != null)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsCycleExist(ListNode head)
        {
            if (head == null)
                return false;

            var slow = head;
            var fast = head;

            while (fast.next != null && fast.next.next != null) // IMP
            {
                slow = slow.next;
                fast = fast.next.next;
                if (fast == slow) return true; // at last  // IMP
            }
            return false;
        }

        /// <summary>
        /// TC O(n) ie O(n) + O(n) => O(n)
        /// SC O(1)
        /// Note : while (fast.Next != null && fast.Next.Next != null)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode GetCycleNode(ListNode head)
        {
            if (head == null)
                return null;

            var slow = head;
            var fast = head;

            while (fast.next != null && fast.next.next != null) // IMP
            {
                slow = slow.next;
                fast = fast.next.next;
                if (fast == slow)
                {
                    slow = head;
                    while (slow != fast)
                    {
                        fast = fast.next;
                        slow = slow.next;
                    }
                    return slow;
                }
            }
            return null;
        }

        /// <summary>
        /// TC O(n) 
        /// SC O(1)
        /// Steps
        ///     1   Reverse  
        ///     2   Delete nth node (find nth Node and delete it) 
        ///     3   Reverse
        ///     OR  
        ///     1 Find length 
        ///     2 travel (l - n + 1) node 
        ///     3 delete it
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
      
        public ListNode RemoveNthNodeFromEndOfList(ListNode head, int k)
        {
            ListNode dummy = new ListNode();
            dummy.next = head;
            ListNode x = head;
            ListNode xp = dummy;
            ListNode y = head;
            ListNode yp = dummy;

            for (int i = 0; i < k - 1; i++)
            {
                xp = x;
                x = x.next;
            }

            ListNode traverse = x;

            while (traverse.next != null)
            {
                yp = y;
                y = y.next;
                traverse = traverse.next;
            }

            if (x == y)
                return head;

            xp.next = y;
            yp.next = x;

            Swap(x, y);

            return dummy.next;
        }
        private ListNode Delete(ListNode head, int data)
        {
            var dummyNode = service.GetNewNode(-100);
            dummyNode.next = head;
            var traverse = head;
            ListNode prev = dummyNode;
            ListNode beforeNode = null;
            while (traverse != null)
            {
                if (data == traverse.val)
                {
                    beforeNode = prev;
                    break;
                }
                prev = prev.next;
                traverse = traverse.next;
            }

            if (beforeNode != null)
                prev.next = prev.next.next;

            return dummyNode;  // NOTE not easy at it seems
        }

        /// <summary>
        /// TC O(n) 
        /// SC O(1)
        /// Approch 1 : create copy of list and compare if all equal T or F
        /// Approch 2 : rich middle node & return remaning as new list 2 reverse new list 
        ///             and then compare value by value
        /// </summary>
        /// <param name="head"></param>
        public bool IsPallindrome(ListNode linklist1)
        {
            if (linklist1 == null || linklist1.next == null) return true;

            ListNode Mid = GetMiddleNode(linklist1.next);
            ListNode newList = Mid.next;  // IMP
            Mid.next = null; ;  // IMP
            var linklist2 = service.ReverseListImmutable(newList);
            return Compare(linklist1, linklist2);
        }

        private bool Compare(ListNode linklist1, ListNode linklist2)
        {
            while (linklist1 != null && linklist2 != null)  // IMP &&
            {
                if (linklist1.val != linklist2.val) return false;
                linklist1 = linklist1.next;
                linklist2 = linklist2.next;
            }
            return true;
        }

        private ListNode GetMiddleNode(ListNode linklist1)
        {
            ListNode slow = linklist1, fast = linklist1;
            while (fast != null && fast.next != null) // fast.Next != null IMP
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }

        /// <summary>
        /// TC O(n) 
        /// SC O(1)
        /// </summary>
        /// <param name="linklist"></param>
        /// <returns></returns>
        public ListNode RemoveDuplicateFromSortedList(ListNode linklist)
        {
            if (linklist == null) return null;
            var head = linklist;
            var traverse = linklist;
            while (traverse != null && traverse.next != null)
            {
                if (traverse.val == traverse.next.val)
                    traverse.next = traverse.next.next;
                else traverse = traverse.next;
            }
            return head;
        }
        public ListNode RemoveDuplicateFromSortedListInternet(ListNode head)
        {
            var dummy = service.GetNewNode(-100);
            dummy.next = head;
            ListNode curr = head;
            ListNode prev = dummy;

            while (curr != null)
            {
                if (curr.val == prev.val)
                    prev.next = curr.next;
                else
                    prev = curr;
                curr = curr.next;
            }
            return dummy.next;
        }

        /// <summary>
        /// TC O(n) 
        /// SC O(1)
        /// </summary>
        /// <param name="linklist"></param>
        /// <returns></returns>
        public ListNode SwapKthNodeFromBothEnd(ListNode head, int k)
        {
            var headMain = head;
            var fast = head;
            var swap1 = head;
            var swap2 = head;

            for (int i = 0; i < k - 1; i++)
                fast = fast.next;

            swap1 = fast;

            while (fast.next != null)  // IMP fast.NEXT
            {
                fast = fast.next;
                swap2 = swap2.next;   // IMP 
            }

            int temp = swap1.val;
            swap1.val = swap2.val;
            swap2.val = temp;

            return headMain;
        }

        public ListNode RemoveNthNodeFromEndOfList_1(ListNode head, int n)
        {
            int count = 1;
            if (head == null)
                return null;

            var reverse = service.ReverseListImmutable(head);

            ListNode prev = null;
            var traverse = reverse;
            while (count < n)
            {
                count++;
                prev = traverse;
                traverse = traverse.next;
            }

            //prev.Next = traverse.Next;  // IMP FAIL where n = 1 ir last element
            reverse = Delete(reverse, traverse.val);

            reverse = service.ReverseListImmutable(reverse.next);

            return reverse;

        }

        private void Swap(ListNode a, ListNode b)
        {
            var tmp = a.next;
            a.next = b.next;
            b.next = tmp;
        }

        public ListNode SwapKthNodeFromBothEnd_1(ListNode head, int k)
        {
            ListNode dummy = new ListNode();
            ListNode preRight = dummy;
            ListNode preLeft = dummy;
            ListNode right = head;
            ListNode left = head;

            for (int i = 0; i < k - 1; i++)
            {
                preLeft = left;
                left = left.next;
            }

            ListNode temp = left;

            while (temp.next != null)
            {
                preRight = right;
                right = right.next;
                temp = temp.next;
            }

            if (left == right)
                return head;

            preLeft.next = right;
            preRight.next = left;

            temp = left.next;
            left.next = right.next;
            right.next = temp;

            return dummy.next;
        }

        public ListNode SwapKthNodeFromBothEnd_2(ListNode head, int k)
        {
            var headMain = head;
            var fast = head;

            ListNode aPrev = null;
            ListNode aCurr = null;
            ListNode aNext = null;

            ListNode bPrev = null;
            ListNode bCurr = head;
            ListNode bNext = null;

            for (int i = 0; i < k - 1; i++)
            {
                aPrev = fast;
                fast = fast.next;
            }

            aCurr = fast;
            aNext = aCurr.next;

            while (fast.next != null)
            {
                bPrev = bCurr;
                fast = fast.next;
                bCurr = bCurr.next;
            }

            bNext = bCurr.next;

            if (aCurr == bCurr) return headMain;

            //aCurr.next = null;
            //bPrev.next = null;

            if (aPrev != null)
                aPrev.next = bCurr;
            if (aCurr.next == bCurr)
                bCurr.next = aCurr;
            else
            {
                bCurr.next = aNext;
                if (bPrev != null)
                    bPrev.next = aCurr;
            }
            aCurr.next = bNext;

            return headMain;
        }

        /// <summary>
        /// TC O(m+n) 
        /// SC O(1)
        /// </summary>
        /// <param name="linklist"></param>
        /// <returns></returns>
        public ListNode SortLinkList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            var mid = GetMiddleNodeForMerge(head);
            var list2 = mid.next;  // IMP
            mid.next = null;  // IMP
            var list1 = head;

            list1 = SortLinkList(list1);
            list2 = SortLinkList(list2);
            return MergeTwoSortedList(list1, list2);

        }
        private ListNode GetMiddleNodeForMerge(ListNode linklist1)
        {
            ListNode slow = linklist1;
            ListNode fast = linklist1.next; // THIS IS MAJOR CHANGE FOR MERGE?? WHY????
            while (fast != null && fast.next != null) // fast.Next != null IMP
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }

        /// <summary>
        /// TC O(n) 
        /// SC O(1)
        /// odd indices follow by even indices, EASY 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public ListNode OddEvenLinkList(ListNode list)
        {
            if (list == null) return null;

            var oddHead = list;
            var odd = list;
            var even = list.next;
            var evenHead = list.next;

            while (even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }

            odd.next = evenHead;
            return oddHead;
        }

        /// <summary>
        /// TC O(n) 
        /// SC O(1)
        /// Swap nodes in pair
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public ListNode SwapNodesInPair(ListNode list)
        {
            if (list == null) return list;

            var head = list;
            var even = list.next;
            var odd = list;

            while (even != null && even.next != null)
            {
                int temp = even.val;
                even.val = odd.val;
                odd.val = temp;
                even = even.next.next;

                // never got error as even pointer is always ahead of odd
                // and we are checking even null and even next null in while
                odd = odd.next.next;
            }

            return head;
        }

        /// <summary>
        /// TC O(n) 
        /// SC O(1)
        /// Swap nodes in pair NOT WORKINF
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public ListNode SwapNodesInKPair(ListNode list, int k)
        {
            if (list == null) return list;

            var head = list;
            ListNode prev = null;
            ListNode traverseStart = list;
            var traverseLast = list;

            int count = 0;
            while (traverseLast != null)
            {
                count++;
                if (count == k)
                {
                    var next = traverseLast.next;

                    // reverse -> traverseStart to traverseLast
                    traverseLast.next = null;
                    var revNode = ReverseMine(traverseStart);

                    traverseStart = next;
                }
                else
                    prev = traverseLast;
                traverseLast = traverseLast.next;
            }

            return head;
        }

        /// <summary>
        /// TC O(n) 
        /// SC O(1)
        /// Swap nodes in pair Internet working
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public ListNode SwapNodesInKPairNew(ListNode head, int k)
        {
            if (head == null || k == 1) return head;

            ListNode dummy = new ListNode();
            dummy.next = head;
            ListNode cur = dummy;
            var next = dummy;
            var prev = dummy;
            int length = 0;

            while (cur.next != null)
            {
                cur = cur.next;
                length++;
            }

            // need to dry run this block
            while (length >= k)
            {
                cur = prev.next;
                next = cur.next;
                for (int i = 1; i < k; i++)
                {
                    cur.next = next.next;
                    next.next = prev.next;
                    prev.next = next;
                    next = cur.next;
                }
                prev = cur;
                length = length - k;
            }
            return dummy.next;
        }

        public ListNode SwapKNode(ListNode list, int k)
        {
            if (list == null || k == 1) return list;

            var head = service.GetNewNode(-100);
            head.next = list;

            var traverse = list;
            var beforeStart = list;
            ListNode start = list.next;
            ListNode end = null;
            ListNode afterEnd = null;

            int count = 0;
            while (traverse != null && count < k - 1)
            {
                count++;
                traverse = traverse.next;
                if (count == 1)
                {
                    beforeStart = traverse;
                    start = traverse.next;
                }
                if (count == k)
                {
                    end = traverse;
                    afterEnd = end.next;

                    // reverse logic start
                    ListNode curr = start;
                    ListNode prev = null;
                    ListNode next = null;
                    for (int i = 0; i < k; i++)
                    {
                        next = curr.next;
                        curr.next = prev;
                        prev = curr;
                        curr = next;
                    }
                    beforeStart.next = prev;
                    curr.next = afterEnd;
                    // reverse logic end
                    start = afterEnd;
                    end = null;
                    count = 0;
                }
            }
            return head;

        }

        private ListNode ReverseMine(ListNode node)
        {
            if (node == null) return null;

            var curr = node;
            ListNode prev = null;
            ListNode next = null;

            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            return prev;
        }

     
    }
}