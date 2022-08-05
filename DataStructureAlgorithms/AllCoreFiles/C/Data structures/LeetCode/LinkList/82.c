// https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/
// 82. Remove Duplicates from Sorted List II
// https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/discuss/2065500/C-Language

/*
Runtime: 16 ms, faster than 5.23% of C online submissions for Remove Duplicates from Sorted List II.
Memory Usage: 6.2 MB, less than 95.04% of C online submissions for Remove Duplicates from Sorted List II.
*/

#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h>
#include <string.h>
#include <stdbool.h>

struct ListNode {
	int val;
	struct ListNode* next;
};

void PrintList(struct ListNode* head, char* msg)
{
	if (head == NULL)
		return;

	if (msg)
		printf("%s\t ", msg);

	printf("%d\n", head->val);
	PrintList(head->next, msg);
}

struct ListNode* Add(struct ListNode* head, int data)
{
	struct ListNode* temp = (struct ListNode*)malloc(sizeof(struct ListNode));
	temp->val = data;
	temp->next = NULL;

	if (head == NULL)
	{
		head = (struct ListNode*)malloc(sizeof(struct ListNode));
		head->val = data;
		head->next = NULL;
	}
	else
	{
		struct ListNode* traverse = head;
		while (traverse->next != NULL)
		{
			traverse = traverse->next;
		}
		traverse->next = temp;
	}
	return head;
}

struct ListNode* deleteDuplicates(struct ListNode* head) {

	if (head == NULL)
		return head;

	struct ListNode* slow = head;
	struct ListNode* fast = head;

	bool isDuplicate = false;

	while (fast != NULL)
	{
		while (fast->next != NULL && fast->val == fast->next->val)
		{
			if (fast == head)
			{
				while (fast->next != NULL && fast->val == fast->next->val)
					fast->next = fast->next->next;
				head = head->next;
			}
			else 
			{
				while (slow != fast && slow->next != fast && slow->next->val != fast->val)
					slow = slow->next;

				fast->next = fast->next->next;
				slow->next = fast->next;
			}
		}

		fast = fast->next;
	}

	return head;
}

int main(int argc, char* argv[])
{
	int cnt1 = atoi(argv[1]);
	printf("count 1 is %d \n", cnt1);

	struct ListNode* A1 = NULL;
	for (int i = 0; i < cnt1; i++)
	{
		int t = 0;
		printf("Enter Number for %d : ", i);
		scanf("%d", &t);
		A1 = Add(A1, t);
	}

	struct ListNode* temp = deleteDuplicates(A1);

	PrintList(temp, "result");

	return 0;
}