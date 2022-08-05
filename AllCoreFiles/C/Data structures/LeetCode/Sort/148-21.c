
// https://leetcode.com/problems/sort-list/
// 148. Sort List
// https://leetcode.com/problems/sort-list/discuss/2125261/C-Language-Quick-Sort-TLE


/*
TLE but works
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

void PrintList(struct ListNode* list, char* msg)
{
	if (msg)
		printf("%s", msg);

	struct ListNode* travel = list;
	printf("[START]->");
	while (travel != NULL)
	{
		printf("[%d]->", travel->val);
		travel = travel->next;
	}
	printf("[END]\n");
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

/******RUNNING BUT TLE QUICK SORT******/
// for partition - 2 pointer prev and next
 
// check end is always ahead of start
bool IsInValidRange(struct ListNode* head, struct ListNode* start, struct ListNode* end)
{
	struct ListNode* travel = head;
	bool startFound = 0;
	bool endFound = 0;

	while (travel != NULL)
	{
		if (travel == end && end == start)
			return false;

		if (travel == start)
		{
			startFound = 1;
			if (endFound == 0) return true;
		}

		if (travel == end)
		{
			endFound = 1;
			if (startFound == 0) return false;
		}

		travel = travel->next;
	}

	return true;
}

void Partition(struct ListNode* head, struct ListNode* end,
	struct ListNode** partitionPrevNode, struct ListNode** partitionNextNode)
{
	struct ListNode* dummy = (struct ListNode*)malloc(sizeof(struct ListNode));
	dummy->next = head;
	dummy->val = -100;

	int pivot = end->val;
	struct ListNode* prevPartitionNode = dummy;
	struct ListNode* partitionNode = head;
	struct ListNode* traverse = head;

	while (traverse != end)
	{
		if (traverse->val <= pivot)
		{
			// SWAP
			int temp = traverse->val;
			traverse->val = partitionNode->val;
			partitionNode->val = temp;

			prevPartitionNode = partitionNode;
			partitionNode = partitionNode->next;
		}
		traverse = traverse->next;
	}

	// SWAP
	int temp = partitionNode->val;
	partitionNode->val = end->val;
	end->val = temp;

	*partitionPrevNode = prevPartitionNode == dummy ? NULL : prevPartitionNode;
	*partitionNextNode = partitionNode->next;
}

void QuickSort(struct ListNode* head, struct ListNode* start, struct ListNode* end)
{
	if (IsInValidRange(head, start, end))
	{
		struct ListNode* partitionPrevNode = NULL;
		struct ListNode* partitionNextNode = NULL;

		Partition(start, end, &partitionPrevNode, &partitionNextNode);

		if (partitionPrevNode != NULL)
			QuickSort(head, start, partitionPrevNode);

		if (partitionNextNode != NULL)
			QuickSort(head, partitionNextNode, end);
	}
}

void Sort(struct ListNode* head)
{
	if (head == NULL)
		return;

	if (head->next == NULL)
		return;

	struct ListNode* end = head;
	while (end->next != NULL)
		end = end->next;

	QuickSort(head, head, end);
}

/******RUNNING BUT TLE QUICK SORT******/

int main(int argc, char* argv[])
{
	int arg1 = atoi(argv[1]);

	struct ListNode* traverse = NULL;
	for (int i = 0; i < arg1; i++)
		traverse = Add(traverse, rand());

	PrintList(traverse, "Before");
	Sort(traverse);
	PrintList(traverse, "After");

	return 0;
}