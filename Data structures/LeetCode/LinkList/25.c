// https://leetcode.com/problems/reverse-nodes-in-k-group/submissions/
// 25. Reverse Nodes in k-Group
// https://leetcode.com/problems/reverse-nodes-in-k-group/discuss/2122676/C-Language

/*
Runtime: 7 ms, faster than 78.05% of C online submissions for Reverse Nodes in k-Group.
Memory Usage: 7 MB, less than 49.59% of C online submissions for Reverse Nodes in k-Group.
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

static struct ListNode* GetNewNode(int data)
{
	struct ListNode* node = (struct ListNode*)calloc(1, sizeof(struct ListNode));
	node->val = data;
	node->next = NULL;
	return node;
}

struct ListNode* CreateList()
{
	return GetNewNode(-1);
}

static void GenericInsert(struct ListNode* prev, struct ListNode* midNode, struct ListNode* next)
{
	midNode->next = next;
	prev->next = midNode;
}

void InsertAtEnd(struct ListNode* list, int data)
{
	struct ListNode* start = list->next;
	struct ListNode* lastNode = list;
	while (start != NULL)
	{
		lastNode = lastNode->next;
		start = start->next;
	}
	GenericInsert(lastNode, GetNewNode(data), lastNode->next);
}

struct ListNode* ToList(int arr[], int size)
{
	struct ListNode* list = CreateList();
	if (size == 0) list;

	for (int i = 0; i < size; i++)
		InsertAtEnd(list, arr[i]);

	return list;
}

void ToArray(struct ListNode* list, int* arr, int* size)
{
	struct ListNode* start = list->next;
	*size = 0;
	while (start != NULL)
	{
		arr[(*size)] = start->val;
		start = start->next;
		(*size)++;
	}
}

int GetLength(struct ListNode* list)
{
	if (list->next == NULL) return 1;
	return 1 + GetLength(list->next);
}

struct ListNode* reverseKGroup(struct ListNode* head, int k) {

	if (k == 1) return head;

	struct ListNode* dummy = (struct ListNode*)malloc(sizeof(struct ListNode));
	dummy->val = -1;
	dummy->next = head;

	struct ListNode* returnHead = NULL;

	struct ListNode* start = dummy->next;
	struct ListNode* pp_prev = dummy;
	int firstTime = 1;
	while (start != NULL)
	{
		struct ListNode* end = start;

		int temp = 1;
		while (temp < k && end != NULL)
		{
			end = end->next;
			temp++;
			if (firstTime == 1)
				returnHead = end;

		}
		firstTime = 0;

		if (end == NULL) break;

		struct ListNode* aa_after = end->next;

		// REVERSE START

		pp_prev->next = NULL;
		end->next = NULL;
		struct ListNode* lastAfterReverse = start;
		struct ListNode* prev = NULL;
		struct ListNode* nnext = NULL;

		while (start != NULL)
		{
			nnext = start->next;

			start->next = prev;

			prev = start;
			start = nnext;
		}

		pp_prev->next = prev;
		lastAfterReverse->next = aa_after;

		// REVERSE END

		pp_prev = lastAfterReverse;
		start = pp_prev->next;

	}

	return returnHead;
}

int main(int argc, char* argv[])
{
	int size = 4;
	int arr[] = { 1,2,3,4 };
	int k = 3;
	struct ListNode* list = ToList(arr, size);
	list = list->next;
	PrintList(list, "Before");
	struct ListNode* result = reverseKGroup(list, k);
	PrintList(result, "After");

	return 0;
}

