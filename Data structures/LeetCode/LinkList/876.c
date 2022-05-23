// https://leetcode.com/problems/middle-of-the-linked-list/
// 876. Middle of the Linked List
// https://leetcode.com/problems/middle-of-the-linked-list/discuss/2065543/C-Language

/*
Runtime: 2 ms, faster than 45.65% of C online submissions for Middle of the Linked List.
Memory Usage: 6 MB, less than 7.74% of C online submissions for Middle of the Linked List.
*/

#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h>
#include <string.h>

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


struct ListNode* middleNode(struct ListNode* head) {

	struct ListNode* slow = head;
	struct ListNode* fast = head;

	while (fast != NULL)
	{
		if (fast->next != NULL)
		{
			fast = fast->next->next;
			slow = slow->next;
		}
		else fast = fast->next;
	}

	return slow;
}

int main(int argc, char* argv[])
{
	int cnt1 = atoi(argv[1]);
	int cnt2 = atoi(argv[2]);
	printf("count 1 is %d \n", cnt1);

	struct ListNode* A1 = NULL;
	for (int i = 1; i <= cnt1; i++)
	{
		int t = 0;
		printf("Enter Number for %d : ", i);
		scanf("%d", &t);
		A1 = Add(A1, t);
	}

	PrintList(A1, "before");

	struct ListNode* temp = middleNode(A1);

	PrintList(temp, "result");

	return 0;
}