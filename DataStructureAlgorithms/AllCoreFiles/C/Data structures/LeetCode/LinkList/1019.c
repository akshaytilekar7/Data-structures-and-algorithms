// https://leetcode.com/problems/next-greater-node-in-linked-list/
// 1019. Next Greater Node In Linked List
// https://leetcode.com/problems/next-greater-node-in-linked-list/discuss/2116582/C-Language

/*
Runtime: 1977 ms, faster than 5.88% of C online submissions for Next Greater Node In Linked List.
Memory Usage: 32.4 MB, less than 27.94% of C online submissions for Next Greater Node In Linked List.
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

int* nextLargerNodes(struct ListNode* head, int* returnSize) {

	struct ListNode* travel = head;
	int len = GetLength(travel);
	int index = 0;
	int* arr = (int*)malloc(sizeof(int) * len);
	while (travel != NULL)
	{
		struct ListNode* temp = travel->next;
		while (temp != NULL)
		{
			if (temp->val > travel->val)
			{
				arr[index++] = temp->val;
				break;
			}
			temp = temp->next;
		}
		if (temp == NULL)
			arr[index++] = 0;

		travel = travel->next;
	}
	*returnSize = index;
	return arr;

}

int main(int argc, char* argv[])
{
	int size = 5;
	int arr[] = { 2, 7, 4, 3, 5 };
	int len = 0;
	struct ListNode* list = ToList(arr, size);
	PrintList(list, "Before");
	int* p = nextLargerNodes(list->next, &len);
	printf("[\t");
	for (int i = 0; i < len; i++)
		printf("[%d]   ", p[i]);
	printf("\t]\n");

	return 0;
}

