// https://leetcode.com/problems/sort-list/
// 148. Sort List
// 
/*
*
	QuickSort
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

void PrintList(struct ListNode* head, char* msg)
{
	if (head == NULL)
		return;

	if (msg)
		printf("%s\t ", msg);

	printf("%d\n", head->val);
	PrintList(head->next, msg);
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
	if (list == NULL) return 1;
	if (list->next == NULL) return 1;

	struct ListNode* slow = list;
	struct ListNode* fast = list;
	int len = 1;

	while (fast != NULL && fast->next != NULL)
	{
		len++;
		slow = slow->next;
		fast = fast->next->next;
	}

	if (fast == NULL) // even
		return (len - 1) * 2;
	return  ((len - 1) * 2) + 1;
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

int Partition(int arr[], int start, int end)
{
	int pivot = arr[end];
	int partitionIndex = start;

	for (int i = start; i < end; i++)
	{
		if (arr[i] <= pivot)
		{
			int temp = arr[i];
			arr[i] = arr[partitionIndex];
			arr[partitionIndex] = temp;
			partitionIndex++;
		}
	}

	int temp = arr[partitionIndex];
	arr[partitionIndex] = arr[end];
	arr[end] = temp;

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
	int* arr = (int*)malloc(sizeof(int) * len);

	ToArray(dummy, arr, &size);
	QuickSort(arr, 0, size - 1);
	head = ToList(arr, size);
	head = head->next;
	return head;
}

int main(int argc, char* argv[])
{
	int size = 7;
	int arr[] = { 1,2,3,4, 1,4,10 };
	struct ListNode* list = ToList(arr, size);
	PrintList(list->next, "Before");

	int len = GetLength(list->next);
	printf("len is %d\n", len);
	return 10;
	struct ListNode* result = sortList(list->next);

	PrintList(result, "After");

	return 0;
}

