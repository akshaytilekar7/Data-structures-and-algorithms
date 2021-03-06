// https://leetcode.com/problems/linked-list-cycle-ii/
// 142. Linked List Cycle II
// https://leetcode.com/problems/linked-list-cycle-ii/discuss/2077975/C-Language

/*
Runtime: 189 ms, faster than 5.24% of C online submissions for Linked List Cycle II.
Memory Usage: 7.5 MB, less than 6.02% of C online submissions for Linked List Cycle II.
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

void PrintList(struct ListNode* head, char* msg);
struct ListNode* Add(struct ListNode* head, int data);
struct ListNode* detectCycle(struct ListNode* head);

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

struct ListNode* detectCycle(struct ListNode* head) {

	if (head == NULL)
		return NULL;

	struct ListNode* traverse = head;

	struct ListNode** arr = (struct ListNode**)malloc(10000 * sizeof(struct ListNode*));

	int index = 0;

	while (traverse != NULL)
	{
		arr[index] = traverse;
		index++;

		int start = 0;
		// check if travel node point to any previous node by taversing array valid length which is index
		while (start < index)
		{
			if (arr[start] == traverse->next)
				return arr[start];

			start++;
		}

		traverse = traverse->next;
	}

	return NULL;
}

int main(int argc, char* argv[])
{
	int length = atoi(argv[1]);
	int cycleIndex = atoi(argv[2]);
	printf("cycleIndex %d\n", cycleIndex);

	struct ListNode* head = NULL;
	for (int i = 1; i <= length; i++)
		head = Add(head, i * 10);

	PrintList(head, "before");

	if (cycleIndex < length) // only valid cycle index
	{
		int start = 1;
		struct ListNode* cycle = head;
		while (start < cycleIndex)
		{
			cycle = cycle->next;
			start++;
		}
		printf("cycle index %d\n", cycle->val);

		struct ListNode* travel = head;
		while (travel->next != NULL)
			travel = travel->next;

		travel->next = cycle;
	}

	struct ListNode* result = detectCycle(head);

	printf("cycle node value is %d\n", result->val);

	return 0;
}