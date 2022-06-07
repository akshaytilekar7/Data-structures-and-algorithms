// 24. Swap Nodes in Pairs
// https://leetcode.com/problems/swap-nodes-in-pairs/
// https://leetcode.com/problems/swap-nodes-in-pairs/discuss/2120171/C-Language

/*
Runtime: 0 ms, faster than 100.00% of C online submissions for Swap Nodes in Pairs.
Memory Usage: 5.8 MB, less than 58.32% of C online submissions for Swap Nodes in Pairs.
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
	struct ListNode* travel = list->next;
	struct ListNode* lastNode = list;
	while (travel != NULL)
	{
		lastNode = lastNode->next;
		travel = travel->next;
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
	struct ListNode* travel = list->next;
	*size = 0;
	while (travel != NULL)
	{
		arr[(*size)] = travel->val;
		travel = travel->next;
		(*size)++;
	}
}

int GetLength(struct ListNode* list)
{
	if (list->next == NULL) return 1;
	return 1 + GetLength(list->next);
}

struct ListNode* swapPairs(struct ListNode* head) {

	struct ListNode* first = head;
	struct ListNode* prev = NULL;

	int firstTime = 1;
	while (first != NULL)
	{
		struct ListNode* second = first->next;
		
		if (second == NULL) break;

		struct ListNode* third = second->next;
		
		if (prev != NULL) prev->next = second;
		
		second->next = first;
		first->next = third;
		if (firstTime == 1)
			head = second;
		firstTime = 0;
		prev = first;
		first = first->next;
	}

	return head;
}

int main(int argc, char* argv[])
{
	int size = 2;
	int arr[] = { 1 , 2 };
	int len = 0;
	struct ListNode* list = ToList(arr, size);
	list = list->next;
	PrintList(list, "Before");
	struct ListNode* result = swapPairs(list);
	PrintList(result, "After");

	return 0;
}

