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

void MergeProcedure(int arr[], int start, int mid, int end)
{
	int i = 0;
	int j = 0;
	int k = 0;

	int size1 = mid - start + 1; // [start, mid] 
	int size2 = end - mid; // (mid, end] 

	int* arr1 = (int*)malloc(size1 * sizeof(int));
	int* arr2 = (int*)malloc(size2 * sizeof(int));

	for (int i = 0; i < size1; i++)
		arr1[i] = arr[start + i]; //**
	for (int i = 0; i < size2; i++)
		arr2[i] = arr[mid + 1 + i]; // **

	while (1)
	{
		if (arr1[i] <= arr2[j])
		{
			arr[start + k] = arr1[i];
			i++;
			k++;
			if (i == size1)
			{
				while (j < size2)
				{
					arr[start + k] = arr2[j];
					j++;
					k++;
				}
				break;
			}
		}
		else
		{
			arr[start + k] = arr2[j];
			k++;
			j++;
			if (j == size2)
			{
				while (i < size1)
				{
					arr[start + k] = arr1[i];
					i++;
					k++;
				}
				break;
			}
		}
	}
}

void Merge(int arr[], int start, int end)
{
	if (start < end)
	{
		int mid = (start + end) / 2;
		Merge(arr, start, mid);
		Merge(arr, mid + 1, end);
		MergeProcedure(arr, start, mid, end);
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
	Merge(arr, 0, size - 1);
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

