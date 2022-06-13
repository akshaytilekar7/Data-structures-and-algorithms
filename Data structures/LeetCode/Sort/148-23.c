// https://leetcode.com/problems/sort-list/
// 148. Sort List
// 
/*
    list to array 
    merge sort
	array to list
	
	TLE error	
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

int GetLength(struct ListNode* list)
{
	if (list->next == NULL) return 1;
	return 1 + GetLength(list->next);
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

void Swap(int** arr, int x, int y)
{
	int tmp = (*arr)[x];
	(*arr)[x] = (*arr)[y];
	(*arr)[y] = tmp;
}

int Partition(int arr[], int start, int end)
{
	int pivot = arr[end];
	int partitionIndex = start;

	for (int i = start; i < end; i++)
	{
		if (arr[i] <= pivot)
		{
			Swap(&arr, i, partitionIndex);
			partitionIndex++;
		}
	}

	Swap(&arr, partitionIndex, end);
	return partitionIndex;
}

void QuickSort(int arr[], int start, int end)
{
	if (start < end) // main
	{
		int partitionIndex = Partition(arr, start, end);
		QuickSort(arr, start, partitionIndex - 1);
		QuickSort(arr, partitionIndex + 1, end);
	}
}

struct ListNode* sortList(struct ListNode* head) {
	if (head == NULL)
		return NULL;

	if (head->next == NULL)
		return head;

	struct ListNode* dummy = (struct ListNode*)malloc(sizeof(struct ListNode));
	dummy->next = head;
	dummy->val = -1;

	int size;
	int len = GetLength(head);
	int *arr = (int*)malloc(sizeof(int) * len);

	ToArray(dummy, arr, &size);
	QuickSort(arr, 0, size - 1);
	head = ToList(arr, size);
	head = head->next;
	return head;
}

int main(int argc, char* argv[])
{
	int size = 5;
	int arr[] = { 2, 7, 4, 3, 5 };
	int len = 0;
	struct ListNode* list = ToList(arr, size);
	PrintList(list->next, "Before");

	struct ListNode* result = sortList(list->next);

	PrintList(result, "After");

	return 0;
}

