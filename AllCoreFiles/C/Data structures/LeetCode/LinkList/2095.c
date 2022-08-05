// https://leetcode.com/problems/delete-the-middle-node-of-a-linked-list/
// 2095. Delete the Middle Node of a Linked List
//
/*

Runtime: 723 ms, faster than 12.69% of C online submissions for Delete the Middle Node of a Linked List.
Memory Usage: 78 MB, less than 15.17% of C online submissions for Delete the Middle Node of a Linked List.

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

int GetLength(struct ListNode* head)
{
	struct ListNode* traverse = head;

	int Length = 0;
	while (traverse != NULL)
	{
		traverse = traverse->next;
		Length++;
	}

	return Length;
}

struct ListNode* deleteMiddle(struct ListNode* head) {

	int length = GetLength(head);

	if (length == 1)
	{
		head = NULL;
		return head;
	}

	int mid = (length / 2) - 1;

	struct ListNode* traverse = head;
	while (mid > 0)
	{
		traverse = traverse->next;
		mid--;
	}
	traverse->next = traverse->next->next;

	return head;
}

int main(int argc, char* argv[])
{
	int cnt1 = atoi(argv[1]);
	//printf("Length 1 is %d \n", cnt1);

	struct ListNode* A1 = NULL;
	for (int i = 1; i <= cnt1; i++)
	{
		int t = 0;
		printf("Enter Number for %d : ", i);
		scanf("%d", &t);
		A1 = Add(A1, t);
	}

	struct ListNode* temp = deleteMiddle(A1);

	PrintList(temp, ": ");
	return 0;
}