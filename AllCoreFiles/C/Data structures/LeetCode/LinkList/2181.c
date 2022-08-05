// 2181. Merge Nodes in Between Zeros
// https://leetcode.com/problems/merge-nodes-in-between-zeros/

/*
Time Limit Exceeded
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

struct ListNode* AdditionUntilZero(struct ListNode* head, int* sum)
{
	if (head == NULL)
		return NULL;

	if (head->val == 0)
		return head;
	else
	{
		*sum = *sum + (head->val);
		return AdditionUntilZero(head->next, sum);
	}
}

struct ListNode* mergeNodes(struct ListNode* head) {

	struct ListNode* traverse = head;

	struct ListNode* result = NULL;

	while (traverse != NULL)
	{
		int sum = 0;
		traverse = AdditionUntilZero(traverse, &sum);
		traverse = traverse->next;
		if (sum != 0)
			result = Add(result, sum);
	}

	return result;
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