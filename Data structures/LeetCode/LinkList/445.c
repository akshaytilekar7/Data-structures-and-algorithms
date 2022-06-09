// https://leetcode.com/problems/add-two-numbers-ii/
// 445. Add Two Numbers II
// 

/*
 TLE
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

int GetLength(struct ListNode* list)
{
	if (list->next == NULL) return 1;
	return 1 + GetLength(list->next);
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

int* ToArray(struct ListNode* list, int* size)
{
	int len = GetLength(list);
	int* arr = (int*)malloc(sizeof(int) * len);
	struct ListNode* travel = list;
	*size = 0;
	while (travel != NULL)
	{
		arr[(*size)] = travel->val;
		travel = travel->next;
		(*size)++;
	}
	return arr;
}

void Swap(int** arr, int x, int y)
{
	int tmp = (*arr)[x];
	(*arr)[x] = (*arr)[y];
	(*arr)[y] = tmp;
}

int QuickProc(int arr[], int start, int end)
{
	int pivot = arr[end];
	int partitioIndex = start;

	for (int i = start; i < end; i++)
	{
		if (arr[i] < pivot)
		{
			Swap(&arr, i, partitioIndex);
			partitioIndex++;
		}
	}
	Swap(&arr, partitioIndex, end);
	return partitioIndex;
}

void Partition(int arr[], int start, int end)
{
	if (start < end)
	{
		int partitionIndex = QuickProc(arr, start, end);
		Partition(arr, start, partitionIndex - 1);
		Partition(arr, partitionIndex + 1, end);
	}
}

struct ListNode* sortList(struct ListNode* head) {

	if (head == NULL) return NULL;
	if (head->next == NULL) return head;

	int size = 0;
	int* arr = ToArray(head, &size);
	Partition(arr, 0, size - 1);
	struct ListNode* list = ToList(arr, size);
	return list->next;
}

int main(int argc, char* argv[])
{
	int size1 = 5;
	int arr1[] = { -10, 5, 3,4,0 };
	struct ListNode* list1 = ToList(arr1, size1);

	PrintList(list1->next, "Before");
	struct ListNode* result = sortList(list1->next);
	PrintList(result->next, "After");

	return 0;
}

