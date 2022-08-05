// https://leetcode.com/problems/linked-list-cycle/
// 141. Linked List Cycle

/*
Runtime: 15 ms, faster than 45.26% of C online submissions for Linked List Cycle.
Memory Usage: 7.8 MB, less than 90.51% of C online submissions for Linked List Cycle.
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

bool hasCycle(struct ListNode* head) {

	if (head == NULL)
		return false;

	struct ListNode* slow = head;
	struct ListNode* fast = head;

	while (fast != NULL && fast->next != NULL)
	{
		slow = slow->next;
		fast = fast->next->next;

		if (fast == slow)
			return true;
	}

	return false;
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
		printf("cycle point %d\n", cycle->val);

		struct ListNode* travel = head;
		while (travel->next != NULL)
			travel = travel->next;

		travel->next = cycle;
	}
	//PrintList(head, "After");

	bool result = hasCycle(head);

	printf("Is Cycle %s", result ? "True" : "False");

	return 0;
}