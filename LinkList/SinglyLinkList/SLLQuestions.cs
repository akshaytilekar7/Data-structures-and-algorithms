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
        public ListNode AddTwoList1(ListNode link1, ListNode link2)
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
                carry = sum / 10;    // actual maths divide
                var lastNumber = sum % 10; // give last number

                current.next = service.GetNewNode(lastNumber);
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

        // REMOVE LAST NUMBER
        //Console.WriteLine(456/10); // 45
        //Console.WriteLine(1/10); // 0
        //Console.WriteLine(22/10); // 2
        //Console.WriteLine(1/10); // 0

        // Console.WriteLine(""); 

        // // GIVE LAST NUMBRE
        //Console.WriteLine(456%10); // 6
        //Console.WriteLine(1%10); // 1
        //Console.WriteLine(22%10); // 2
        //Console.WriteLine(1%10); // 1
        public ListNode AddTwoList(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            var dummy = new ListNode();
            var head = dummy;
            var carry = 0;
            var sum = 0;
            while (l1 != null || l2 != null)
            {
                var d1 = l1 == null ? 0 : l1.val;
                var d2 = l2 == null ? 0 : l2.val;
                sum = d1 + d2 + carry;
                carry = sum / 10; //remove last number as we carry right side
                var lastDigit = sum % 10; // give last number
                dummy.next = new ListNode() { val = lastDigit };
                dummy = dummy.next;
                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }

            if (carry != 0)
                dummy.next = service.GetNewNode(carry); // new node for last carry digit if any

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
        /// in short both working
        /// while (fast != null && fast.next != null)
        /// while (fast.next != null && fast.NEXT.NEXT != null) // IMP
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast) return true;
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
        ///             
        /// LOGIC
        /// 1    2    2    1 {EVEN}
        /// 1st part	1    2    2    1
        /// 2nd part	2    1
        /// ______________________
        /// 1    2    3    2    1 {ODD}
        /// 1st part	1    2    3    2    1
        /// 2nd part	2    1
        /// ______________________
        /// 1    2    3    3    2    1 {EVEN}
        /// 1st part	1    2    3    3    2    1
        /// 2nd part	3    2    1
        /// ______________________
        /// 1    2    3    5    3    2    1 {ODD}
        /// 1st part	1    2    3    5    3    2    1
        /// 2nd part	3    2    1
        /// 
        /// in short
        /// 1st part is always all link list
        /// 2nd part : 
        ///     For Even - exact half part we get
        ///     For Odd  - exact half - 1 part we get, we miss 1 starting element from 2nd hafl
        /// </summary>
        /// <param name="head"></param>
        public bool IsPallindrome(ListNode linklist1)
        {
            if (linklist1 == null || linklist1.next == null) return true;
            ListNode Mid = GetMiddleNode(linklist1.next);
            var linklist2 = service.ReverseListImmutable(Mid);
            return Compare(linklist1, linklist2);
        }

        private ListNode reverse(ListNode head)
        {
            if (head == null || head.next == null) { return head; }
            ListNode prev = null;
            while (head != null)
            {
                ListNode realNext = head.next;
                head.next = prev;
                prev = head;
                head = realNext;
            }
            return prev;
        }

        public bool IsPallindrome_2(ListNode head)
        {
            if (head == null || head.next == null)
                return true;

            ListNode fast = head.next;
            ListNode slow = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            slow = reverse(slow);
            while (head != null && slow != null)
            {
                if (head.val != slow.val)
                {
                    return false;
                }
                head = head.next;
                slow = slow.next;
            }
            return true;
        }

        public bool IsPalindrome1(ListNode head)
        {
            if (head == null || head.next == null)
                return true;

            var slow = head;
            var fast = head;
            List<int> list = new List<int>();
            while (fast != null && fast.next != null)
            {
                list.Add(slow.val);
                fast = fast.next.next;
                slow = slow.next;
            }

            if (fast != null)
                slow = slow.next;
            int cnt = list.Count - 1;
            while (slow != null)
            {
                if (slow.val != list[cnt--]) return false;
                slow = slow.next;
            }
            return true;
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

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null) return head;

            var dummy = new ListNode();
            dummy.next = head;
            var prev = dummy;

            var traverse = head;
            for (int i = 0; i < n - 1; i++)
                traverse = traverse.next;

            while (traverse != null && traverse.next != null)
            {
                prev = prev.next;
                traverse = traverse.next;
            }

            prev.next = prev.next.next;
            return dummy.next;
        }

        public ListNode RemoveNthFromEnd1(ListNode head, int n)
        {
            ListNode dummy = new ListNode();
            dummy.next = head;

            ListNode fast = dummy;
            ListNode slow = dummy;

            for (int i = 0; i <= n; i++)
                fast = fast.next;

            while (fast != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            slow.next = slow.next.next;

            return dummy.next;
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
        public ListNode SwapNthNodeList(ListNode head, int k)
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
        public ListNode GetMiddleNodeForMerge(ListNode linklist1)
        {
            ListNode slow = linklist1;
            ListNode fast = linklist1.next; // THIS IS MAJOR CHANGE FOR MERGE?? WHY????
            // bec if we not use next
            // the for 2 element A and B MID will always B
            // so in short lenght of 2 linklist can never be divided and will get error stak over flow
            // SO used .next as it will return A 
            while (fast != null && fast.next != null) // fast.Next != null IMP
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
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


    }
}