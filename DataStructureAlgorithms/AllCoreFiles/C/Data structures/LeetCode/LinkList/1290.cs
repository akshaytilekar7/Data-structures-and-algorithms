// https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer/submissions/
// 1290. Convert Binary Number in a Linked List to Integer
// 

/*
Runtime: 98 ms, faster than 64.34% of C# online submissions for Convert Binary Number in a Linked List to Integer.
Memory Usage: 36.8 MB, less than 67.83% of C# online submissions for Convert Binary Number in a Linked List to Integer.
*/



public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int val = 0, ListNode next = null)
	{
		this.val = val;
		this.next = next;
	}
}

public class Solution
{
	public int GetDecimalValue(ListNode head)
	{

		ListNode travel = head;
		string str = null;

		while (travel != null)
		{
			str = str + (travel.val.ToString());
			travel = travel.next;
		}

		return Convert.ToInt32(str, 2);
	}
}

