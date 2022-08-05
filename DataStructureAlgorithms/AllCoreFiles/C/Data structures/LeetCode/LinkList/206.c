// https://leetcode.com/problems/reverse-linked-list/
// 206. Reverse Linked List
// 

/*
Runtime: 4 ms, faster than 61.28% of C online submissions for Reverse Linked List.
Memory Usage: 6.5 MB, less than 47.40% of C online submissions for Reverse Linked List.
*/

#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h>
#include <string.h>

struct ListNode {
	int val;
	struct ListNode* next;
};

void PrintList(struct ListNode* head, char* msg);
struct ListNode* Add(struct ListNode* head, int data);

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

struct ListNode* ReverseIterative(struct ListNode* head) {

	struct ListNode* prev = NULL;
	struct ListNode* curr = head;
	struct ListNode* next = NULL;

	while (curr != NULL)
	{
		next = curr->next;

		curr->next = prev;

		prev = curr;
		curr = next;
	}

	return prev;
}

struct ListNode* RecursiveReverse1(struct ListNode* first) {

	if (first == NULL)
		return NULL;
	if (first->next == NULL)
		return first;

	struct ListNode* rest = RecursiveReverse1(first->next);
	first->next->next = first;
	first->next = NULL;

	return rest;
}

struct ListNode* head;
void RecursiveReverse2(struct ListNode* prev, struct ListNode* cur)
{
	if (cur) {
		RecursiveReverse2(cur, cur->next);
		cur->next = prev;
	}
	else
		head = prev;
}
int main(int argc, char* argv[])
{
	int arg1 = atoi(argv[1]);
	int arg2 = atoi(argv[2]);
	printf("arg1 1 is %d \n", arg1);
	printf("arg2 2 is %d \n", arg2);

	struct ListNode* traverse = NULL;
	for (int i = 0; i < arg1; i++)
		traverse = Add(traverse, i * 10);

	PrintList(traverse, "before");

	struct ListNode* result = RecursiveReverse1(traverse);

	PrintList(result, "after");

	return 0;
}