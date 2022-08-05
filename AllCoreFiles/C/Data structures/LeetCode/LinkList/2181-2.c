// 2181. Merge Nodes in Between Zeros
// https://leetcode.com/problems/merge-nodes-in-between-zeros/

/*
Runtime: 508 ms, faster than 59.92% of C online submissions for Merge Nodes in Between Zeros.
Memory Usage: 84 MB, less than 88.61% of C online submissions for Merge Nodes in Between Zeros
*/

#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h>
#include <string.h>

struct ListNode {
	int val;
	struct ListNode* next;
};

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

struct ListNode* mergeNodes(struct ListNode* head) {

	head = head->next;
	struct ListNode* traverse = head;

	while (traverse != NULL)
	{
		if (traverse->next != NULL && traverse->next->val != 0)
		{
			traverse->val = traverse->val + traverse->next->val;
			traverse->next = traverse->next->next;
		}
		else 
		{
			traverse->next = traverse->next->next;
			traverse = traverse->next;
		}
	}
	return head;
}

int main(int argc, char* argv[])
{
	int cnt1 = atoi(argv[1]);
	printf("count 1 is %d \n", cnt1);

	struct ListNode* head = NULL;
	for (int i = 0; i < cnt1; i++)
	{
		int t = 0;
		printf("Enter Number for %d : ", i);
		scanf("%d", &t);
		head = Add(head, t);
	}

	struct ListNode* res = mergeNodes(head);

	return 0;
}