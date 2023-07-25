namespace SinglyLinkList
{
    public class SLLQuestions : ISLLQuestions
    {
        private readonly SLLService service;
        private readonly Node linklist;

        public SLLQuestions(SLLService service)
        {
            this.service = service;
            linklist = this.service.linklist;
        }

        /// <summary>
        /// for even mid + 1
        /// for odd exact mid
        /// check merge sort middle 
        /// TC O(n)
        /// SC O(1)
        /// </summary>
        /// <returns></returns>
        public int GetMiddle()
        {
            Node slow = linklist.Next, fast = linklist.Next;

            while (fast != null && fast.Next != null) // fast.Next != null IMP
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }
            return slow.Data;
        }

        /// <summary>
        /// TC O(n)
        /// SC O(1)
        /// Can NOT Delete last node
        /// </summary>
        /// <param name="nodeToDelete"></param>
        public void DeleteNode(ref Node? nodeToDelete)
        {
            if (nodeToDelete == null)
                return;

            if (nodeToDelete.Next == null)
                nodeToDelete = null;
            else
            {
                int val = nodeToDelete.Next.Data;
                nodeToDelete.Next = nodeToDelete.Next.Next;
                nodeToDelete.Data = val;
            }
        }

        /// <summary>
        /// TC O(linklist1 + linklist2)
        /// SC O(linklist1 + linklist2)
        /// Note - after assigning dont forget to update node to next 
        /// </summary>
        /// <param name="nodeToDelete"></param>
        public Node MergeTwoSortedList(Node link1, Node link2)
        {
            if (link1 == null) return link2;
            if (link2 == null) return link1;
            var dummy = service.GetNewNode(-100);
            var head = dummy;

            while (link1 != null && link2 != null)
            {
                if (link1.Data < link2.Data)
                {
                    var newNode = service.GetNewNode(link1.Data);
                    dummy.Next = newNode;
                    dummy = dummy.Next;
                    link1 = link1.Next;
                    if (link1 == null)
                    {
                        while (link2 != null)
                        {
                            newNode = service.GetNewNode(link2.Data);
                            dummy.Next = newNode;
                            dummy = dummy.Next;
                            link2 = link2.Next;
                        }
                        break;
                    }
                }
                else
                {
                    var newNode = service.GetNewNode(link2.Data);
                    dummy.Next = newNode;
                    dummy = dummy.Next;
                    link2 = link2.Next;
                    if (link2 == null)
                    {
                        while (link1 != null)
                        {
                            newNode = service.GetNewNode(link1.Data);
                            dummy.Next = newNode;
                            dummy = dummy.Next;
                            link1 = link1.Next;
                        }
                        break;
                    }
                }
            }

            return head.Next;

        }

        /// <summary>
        /// TC O(linklist1 + linklist2)
        /// SC O(linklist1 + linklist2)
        /// Note -  Note : call with next 
        /// </summary>
        /// <param name="nodeToDelete"></param>
        public Node MergeTwoSortedListRecursive(Node link1, Node link2)
        {
            if (link1 == null) return link2;
            if (link2 == null) return link1;
            var current = service.GetNewNode(-100);
            var head = current;
            var node = MergeTwoSortedListRecursiveHelper(head, current, link1, link2);
            return node;
        }
        private Node MergeTwoSortedListRecursiveHelper(Node head, Node current, Node link1, Node link2)
        {
            if (link1 == null || link2 == null) return head.Next;

            if (link1.Data < link2.Data)
            {
                var newNode = service.GetNewNode(link1.Data);
                current.Next = newNode;
                MergeTwoSortedListRecursiveHelper(head, current.Next, link1.Next, link2);
                if (link1 == null)
                {
                    while (link2 != null)
                    {
                        newNode = service.GetNewNode(link2.Data);
                        current.Next = newNode;
                        // here we cant use recursive as it will br recursive call with one link null and which gives exception if(link1.Data < link2.Data) case
                        current = current.Next;
                        link2 = link2.Next;
                    }
                    return head.Next;
                }
            }
            else
            {
                var newNode = service.GetNewNode(link2.Data);
                current.Next = newNode;
                MergeTwoSortedListRecursiveHelper(head, current.Next, link1, link2.Next);
                if (link2 == null)
                {
                    while (link1 != null)
                    {
                        newNode = service.GetNewNode(link1.Data);
                        current.Next = newNode;
                        // here we cant use recursive as it will br recursive call with one link null and which gives exception if(link1.Data < link2.Data) case
                        current = current.Next;
                        link1 = link1.Next;
                    }
                    return head.Next;
                }
            }

            return head.Next;

        }

        /// <summary>
        /// TC O (linklist1 + linklist2)
        /// SC O ( max(linklist1,linklist2) )
        /// Note -  last carry if condition and carry, sum logic
        /// </summary>
        /// <param name="nodeToDelete"></param>
        public Node AddTwoList(Node link1, Node link2)
        {
            if (link1 == null) return link2;
            if (link2 == null) return link1;
            var current = service.GetNewNode(-100);
            var head = current;
            var carry = 0;

            while (link1 != null || link2 != null)
            {
                var d1 = link1 == null ? 0 : link1.Data;
                var d2 = link2 == null ? 0 : link2.Data;
                var sum = d1 + d2 + carry;
                carry = sum / 10;
                var total = sum % 10;

                current.Next = service.GetNewNode(total);
                current = current.Next;
                link1 = link1?.Next;
                link2 = link2?.Next;
            }

            if (carry != 0)
            {
                int data = current.Data;
                current.Data = carry;
                current.Next = service.GetNewNode(data);

            }
            return head.Next;
        }

        /// <summary>
        /// TC O(n)
        /// SC O(1)
        /// Note : while (fast.Next != null && fast.Next.Next != null)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsCycleExist(Node head)
        {
            if (head == null)
                return false;

            var slow = head;
            var fast = head;

            while (fast.Next != null && fast.Next.Next != null) // IMP
            {
                slow = slow.Next;
                fast = fast.Next.Next;
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
        public Node GetCycleNode(Node head)
        {
            if (head == null)
                return null;

            var slow = head;
            var fast = head;

            while (fast.Next != null && fast.Next.Next != null) // IMP
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if (fast == slow)
                {
                    slow = head;
                    while (slow != fast)
                    {
                        fast = fast.Next;
                        slow = slow.Next;
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
        ///     1   Reverse  2   Delete nth node (find nth Node and delete it) 3   Reverse
        ///     OR  1 Find length 2 travel l - n + 1 node 3 delete it
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node RemoveNthNodeFromEndOfList(Node head, int n)
        {
            int count = 1;
            if (head == null)
                return null;

            var reverse = service.ReverseListImmutable(head);

            Node prev = null;
            var traverse = reverse;
            while (count < n)
            {
                count++;
                prev = traverse;
                traverse = traverse.Next;
            }

            //prev.Next = traverse.Next;  // IMP FAIL where n = 1 ir last element
            reverse = Delete(reverse, traverse.Data);

            reverse = service.ReverseListImmutable(reverse.Next);

            return reverse;

        }

        private Node Delete(Node head, int data)
        {
            var dummyNode = service.GetNewNode(-100);
            dummyNode.Next = head;
            var traverse = head;
            Node prev = dummyNode;
            Node beforeNode = null;
            while (traverse != null)
            {
                if (data == traverse.Data)
                {
                    beforeNode = prev;
                    break;
                }
                prev = prev.Next;
                traverse = traverse.Next;
            }

            if (beforeNode != null)
                prev.Next = prev.Next.Next;

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
        public bool IsPallindrome(Node linklist1)
        {
            if (linklist1 == null || linklist1.Next == null) return true;

            Node Mid = GetMiddleNode(linklist1.Next);
            Node newList = Mid.Next;  // IMP
            Mid.Next = null; ;  // IMP
            var linklist2 = service.ReverseListImmutable(newList);
            return Compare(linklist1, linklist2);
        }

        private bool Compare(Node linklist1, Node linklist2)
        {
            while (linklist1 != null && linklist2 != null)  // IMP &&
            {
                if (linklist1.Data != linklist2.Data) return false;
                linklist1 = linklist1.Next;
                linklist2 = linklist2.Next;
            }
            return true;
        }

        private Node GetMiddleNode(Node linklist1)
        {
            Node slow = linklist1, fast = linklist1;
            while (fast != null && fast.Next != null) // fast.Next != null IMP
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }
            return slow;
        }

        /// <summary>
        /// TC O(n) 
        /// SC O(1)
        /// </summary>
        /// <param name="linklist"></param>
        /// <returns></returns>
        public Node RemoveDuplicateFromSortedList(Node linklist)
        {
            if (linklist == null) return null;
            var head = linklist;
            var traverse = linklist;
            while (traverse != null && traverse.Next != null)
            {
                if (traverse.Data == traverse.Next.Data)
                    traverse.Next = traverse.Next.Next;
                else traverse = traverse.Next;
            }
            return head;
        }
        public Node RemoveDuplicateFromSortedListInternet(Node head)
        {
            var dummy = service.GetNewNode(-100);
            dummy.Next = head;
            Node curr = head;
            Node prev = dummy;

            while (curr != null)
            {
                if (curr.Data == prev.Data)
                    prev.Next = curr.Next;
                else
                    prev = curr;
                curr = curr.Next;
            }
            return dummy.Next;
        }

        /// <summary>
        /// TC O(n) 
        /// SC O(1)
        /// </summary>
        /// <param name="linklist"></param>
        /// <returns></returns>
        public Node SwapKthNodeFromBithEnd(Node head, int k)
        {
            var headMian = head;
            var fast = head;
            var swap1 = head;
            var swap2 = head;

            for (int i = 0; i < k - 1; i++)
                fast = fast.Next;
            swap1 = fast;

            while (fast.Next != null)  // IMP fast.NEXT
            {
                fast = fast.Next;
                swap2 = swap2.Next;   // IMP 
            }

            int temp = swap1.Data;
            swap1.Data = swap2.Data;
            swap2.Data = temp;

            return headMian;
        }

        /// <summary>
        /// TC O(m+n) 
        /// SC O(1)
        /// </summary>
        /// <param name="linklist"></param>
        /// <returns></returns>
        public Node SortLinkList(Node head)
        {
            if (head == null || head.Next == null) return head;

            var mid = GetMiddleNodeForMerge(head);
            var list2 = mid.Next;  // IMP
            mid.Next = null;  // IMP
            var list1 = head;

            list1 = SortLinkList(list1);
            list2 = SortLinkList(list2);
            return MergeTwoSortedList(list1, list2);

        }
        private Node GetMiddleNodeForMerge(Node linklist1)
        {
            Node slow = linklist1;
            Node fast = linklist1.Next; // THIS IS MAJOR CHANGE FOR MERGE?? WHY????
            while (fast != null && fast.Next != null) // fast.Next != null IMP
            {
                fast = fast.Next.Next;
                slow = slow.Next;
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
        public Node OddEvenLinkList(Node list)
        {
            if (list == null) return null;

            var oddHead = list;
            var odd = list;
            var even = list.Next;
            var evenHead = list.Next;

            while (even != null && even.Next != null)
            {
                odd.Next = even.Next;
                odd = odd.Next;
                even.Next = odd.Next;
                even = even.Next;
            }

            odd.Next = evenHead;
            return oddHead;
        }

        /// <summary>
        /// TC O(n) 
        /// SC O(1)
        /// Swap nodes in pair
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public Node SwapNodesInPair(Node list)
        {
            if (list == null) return list;

            var head = list;
            var even = list.Next;
            var odd = list;

            while (even != null && even.Next != null)
            {
                int temp = even.Data;
                even.Data = odd.Data;
                odd.Data = temp;
                even = even.Next.Next;

                // never got error as even pointer is always ahead of odd
                // and we are checking even null and even next null in while
                odd = odd.Next.Next;
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
        public Node SwapNodesInKPair(Node list, int k)
        {
            if (list == null) return list;

            var head = list;
            Node prev = null;
            Node traverseStart = list;
            var traverseLast = list;

            int count = 0;
            while (traverseLast != null)
            {
                count++;
                if (count == k)
                {
                    var next = traverseLast.Next;

                    // reverse -> traverseStart to traverseLast
                    traverseLast.Next = null;
                    var revNode = ReverseMine(traverseStart);

                    traverseStart = next;
                }
                else
                    prev = traverseLast;
                traverseLast = traverseLast.Next;
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
        public Node SwapNodesInKPairNew(Node head, int k)
        {
            if (head == null || k == 1) return head;

            Node dummy = new Node();
            dummy.Next = head;
            Node cur = dummy;
            var next = dummy;
            var prev = dummy;
            int length = 0;

            while (cur.Next != null)
            {
                cur = cur.Next;
                length++;
            }

            // need to dry run this block
            while (length >= k)
            {
                cur = prev.Next;
                next = cur.Next;
                for (int i = 1; i < k; i++)
                {
                    cur.Next = next.Next;
                    next.Next = prev.Next;
                    prev.Next = next;
                    next = cur.Next;
                }
                prev = cur;
                length = length - k;
            }
            return dummy.Next;
        }

        public Node SwapKNode(Node list, int k)
        {
            if (list == null || k == 1) return list;

            var head = service.GetNewNode(-100);
            head.Next = list;

            var traverse = list;
            var beforeStart = list;
            Node start = list.Next;
            Node end = null;
            Node afterEnd = null;

            int count = 0;
            while (traverse != null && count < k - 1)
            {
                count++;
                traverse = traverse.Next;
                if (count == 1)
                {
                    beforeStart = traverse;
                    start = traverse.Next;
                }
                if (count == k)
                {
                    end = traverse;
                    afterEnd = end.Next;

                    // reverse logic start
                    Node curr = start;
                    Node prev = null;
                    Node next = null;
                    for (int i = 0; i < k; i++)
                    {
                        next = curr.Next;
                        curr.Next = prev;
                        prev = curr;
                        curr = next;
                    }
                    beforeStart.Next = prev;
                    curr.Next = afterEnd;
                    // reverse logic end
                    start = afterEnd;
                    end = null;
                    count = 0;
                }
            }
            return head;

        }

        private Node ReverseMine(Node node)
        {
            if (node == null) return null;

            var curr = node;
            Node prev = null;
            Node next = null;

            while (curr != null)
            {
                next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
            }

            return prev;
        }

    }
}
