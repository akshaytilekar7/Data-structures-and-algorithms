// https://leetcode.com/problems/swapping-nodes-in-a-linked-list/
// 1721. Swapping Nodes in a Linked List

/*
Runtime: 386 ms, faster than 30.09% of C online submissions for Swapping Nodes in a Linked List.
Memory Usage: 48.1 MB, less than 97.06% of C online submissions for Swapping Nodes in a Linked List.
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

struct ListNode* swapNodes(struct ListNode* head, int k) {

	struct ListNode* traverse = head;

	int Length = 0;
	while (traverse != NULL)
	{
		traverse = traverse->next;
		Length++;
	}

	int start = k - 1;
	int end = Length - start - 1;

	struct ListNode* startHead = head;
	struct ListNode* endHead = head;

	while (start > 0)
	{
		startHead = startHead->next;
		start--;
	}

	while (end > 0)
	{
		endHead = endHead->next;
		end--;
	}

	int temp = startHead->val;
	startHead->val = endHead->val;
	endHead->val = temp;
	
	return head;
}

int main(int argc, char* argv[])
{
	int cnt1 = atoi(argv[1]);
	//printf("Length 1 is %d \n", cnt1);

	struct ListNode* A1 = NULL;
	for (int i = 1; i <= cnt1; i++)
	{
		//int t = 0;
		//printf("Enter Number for %d : ", i);
		//scanf("%d", &t);
		A1 = Add(A1, i);
	}

	
	struct ListNode* temp = swapNodes(A1, 2);

	PrintList(temp , ": ");
	return 0;
}