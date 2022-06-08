// https://leetcode.com/problems/partition-array-according-to-given-pivot/
// 2161. Partition Array According to Given Pivot

/*

*/

#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h>
#include <string.h>

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

int* GetIndexOfElements(int arr[], int size, int element, int* newSize)
{
	int* newArr = (int*)malloc(size * sizeof(int));
	*newSize = 0;
	int index = 0;
	for (int i = 0; i < size; i++)
	{
		if (arr[i] == element)
		{
			newArr[index++] = i;
		}
	}

	(*newSize) = index;
	return newArr;
}

void Swap(int** arr, int x, int y)
{
	int temp = (*arr)[x];
	(*arr)[x] = (*arr)[y];
	(*arr)[y] = temp;
}

int* Partition(int arr[], int size, int pivot)
{
	for (int i = 0; i < size; i++)
	{
		int partitionIndex = 0;
		if (arr[i] == pivot)
		{
			for (int j = 0; j < size; j++)
			{
				if (arr[j] <= pivot)
				{
					Swap(&arr, j, partitionIndex);
					partitionIndex++;
				}
			}
			Swap(&arr, partitionIndex, i);
		}
	}
	return arr;
}

int* pivotArray(int* nums, int numsSize, int pivot, int* returnSize) {

	*returnSize = numsSize;
	int* resultArray = Partition(nums, numsSize, pivot);
	for (int i = 0; i < numsSize; i++)
		printf("after %d \n", resultArray[i]);


	return nums;
}

int main(int argc, char* argv[])
{
	int size = 7;
	int arr[] = { 9,12,5,10,14,3,15 };
	int pivot = 10;
	int returnSize = 0;

	/*for (int i = 0; i < size; i++)
		printf("before %d \n", arr[i]);*/

	int* result = pivotArray(arr, size, pivot, &returnSize);

	/*for (int i = 0; i < returnSize; i++)
		printf("after %d \n", arr[i]);*/

	return 0;
}