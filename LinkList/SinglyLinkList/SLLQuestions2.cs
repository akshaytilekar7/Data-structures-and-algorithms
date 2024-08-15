using System.Reflection.PortableExecutable;

namespace SinglyLinkList
{
    // 5 quetsion
    public class SLLQuestions2
    {
        private readonly SLLService service;
        private readonly ListNode linklist;

        public SLLQuestions2(SLLService service)
        {
            this.service = service;
            linklist = this.service.linklist;
        }

        /// <summary>
        /// TC O(n) 
        /// SC O(1)
        /// NOT RECOMMANDED No node swap only values are swapping
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

        private void Swap(ListNode a, ListNode b)
        {
            var tmp = a.next;
            a.next = b.next;
            b.next = tmp;
        }


        public ListNode OddEvenList(ListNode head)
        {
            if (head == null) return head;

            var odd = head;
            var even = head.next;
            var evenhead = head.next;

            while (even != null)
            {
                odd.next = even.next;
                odd = odd.next;

                even.next = odd.next;
                even = even.next;
            }

            odd.next = evenhead;
            return head;
        }

        /// <summary>
        /// TC O(n) 
        /// SC O(1)
        /// odd indices follow by even indices, EASY 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode OddEvenLinkList(ListNode head)
        {
            if (head == null) return null;

            var odd = head;
            var even = head.next;
            var evenHead = head.next;

            while (even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }

            // we get 1 link list odd with -> 1 3 5 7  (A)
            // and other with even -> 2 3 6 8  (B)
            // so at last we need to attached B to end of A so will get fill list as answer
            odd.next = evenHead;

            return head;
        }

        public ListNode SwapNodesInPair(ListNode head)
        {
            if (head == null) return head;

            var dummy = new ListNode();
            dummy.next = head;

            ListNode prev = dummy;
            ListNode curr = head;
            ListNode next = null;

            while (curr != null && curr.next != null)
            {
                next = curr.next;
                var nn = next?.next;
                prev.next = next;
                next.next = curr;
                curr.next = nn;
                prev = curr;
                curr = nn;
            }
            return dummy.next;
        }

        /// <summary>
        /// TC O(n) 
        /// SC O(1)
        /// Swap nodes in pair
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public ListNode SwapValuesInPair(ListNode list)
        {
            if (list == null) return list;

            var head = list;
            var odd = list;
            var even = list.next;

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
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || k <= 0) return head;

            ListNode current = head;
            ListNode prev = null;
            int length = GetLength(head);
            int count = length / k;

            while (count > 0)
            {
                ListNode next = null;
                var beforeReverseStartNode = current;
                var beforeReversePrevNode = prev;

                int x = k;
                while (x > 0)
                {
                    next = current.next;
                    current.next = prev;
                    prev = current;
                    current = next;
                    x--;
                }

                // IMP 
                if (beforeReversePrevNode == null)
                    head = prev;
                else
                    beforeReversePrevNode.next = prev;

                // IMP 
                beforeReverseStartNode.next = current;
                prev = beforeReverseStartNode;

                count--;
            }

            return head;

        }

        public int GetLength(ListNode head)
        {
            ListNode node = head;
            int length = 0;
            while (node != null)
            {
                length++;
                node = node.next;
            }
            return length;
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

        public ListNode GetMiddle(ListNode linklist1)
        {
            ListNode slow = linklist1;
            ListNode fast = linklist1;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }

        public ListNode GetMiddleNext(ListNode linklist1)
        {
            ListNode slow = linklist1;
            ListNode fast = linklist1.next;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }

        /// <summary>
        /// Two-pointer technique may be slightly simpler and avoids the explicit length calculations
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNodeBest(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
                return null;

            ListNode ptrA = headA;
            ListNode ptrB = headB;

            while (ptrA != ptrB)
            {
                ptrA = ptrA is null ? headB : ptrA.next;
                ptrB = ptrB is null ? headA : ptrB.next;
            }

            return ptrA;
        }

        /// <summary>
        /// 1.Traverse both lists to find their ends and count their lengths.
        /// 2.If the last nodes of both lists are equal, reset the nodes to the beginning of their lists.
        /// 3.Determine which list is longer and calculate the difference in lengths.
        /// 4.Move the longer list forward by the difference in lengths.
        /// 5.Iterate through both lists simultaneously until finding the intersection node or reaching the end of both lists
        /// Time Complexity: O(N + M)
        /// Space Complexity: O(1)
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var lengthA = GetLength(headA);
            var lengthB = GetLength(headB);

            while (lengthA > lengthB)
            {
                headA = headA.next;
                lengthA--;
            }

            while (lengthB > lengthA)
            {
                headB = headB.next;
                lengthB--;
            }

            while (headA != headB)
            {
                if (headA == headB)
                    return headA;
                headA = headA.next;
                headB = headB.next;
            }
            return null;
        }

        /// <summary>
        /// Time Complexity: O(N + M)
        /// Space Complexity: O(N)
        /// </summary>
        /// <param name="head1"></param>
        /// <param name="head2"></param>
        /// <returns></returns>
        private bool Intersect(ListNode head1, ListNode head2)
        {
            HashSet<ListNode> nodes = new HashSet<ListNode>();
            var traverse = head1;
            while (traverse != null)
            {
                nodes.Add(traverse);
                traverse = traverse.next;
            }

            traverse = head2;
            while (traverse is not null)
            {
                if (nodes.Contains(traverse))
                    return true;
                traverse = traverse.next;
            }
            return false;
        }

        public class Node
        {
            public string Data { get; set; }
            public Node Next { get; set; }
        }

        public Node GetIntersectionNode(Node headA, Node headB)
        {
            if (headA == null || headB == null) return null;

            Node ptrA = headA;
            Node ptrB = headB;

            while (ptrA != ptrB)
            {
                ptrA = ptrA is null ? headB : ptrA.Next;
                ptrB = ptrB is null ? headA : ptrB.Next;
            }

            return ptrA; // ptrB as they both are intersected
        }


    }
}