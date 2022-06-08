// https://leetcode.com/problems/reverse-nodes-in-even-length-groups/
// 2074. Reverse Nodes in Even Length Groups
// 

/*

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

int GetFactorial(int number)
{
	if (number <= 0)
		return 1;

	return number * GetFactorial(number - 1);
}

bool IsEven(int num)
{
	return num % 2 == 0;
}

bool IsEvenGroup(int num)
{
	int arr[num];

	for (int i = 0; i < num; i++)
		arr[i] = i + 1;

	int value = 0;
	int grp[num + 1];
	for (int i = 1; i <= num; i++)
	{
		if (i == 1)
		{
			grp[0] = 0;
			grp[1] = 1;
		}
		else
			grp[i] = i + grp[i - 1];

	}

	for (int i = 1; i <= num; i++)
	{
		if (grp[i] >= num)
			return IsEven(i);;
	}
}

struct ListNode* reverseEvenLengthGroups(struct ListNode* head)
{
	if (head == NULL)
		return NULL;


	struct ListNode* dummy = (struct ListNode*)malloc(sizeof(struct ListNode));
	dummy->val = -1;
	dummy->next = head;

	int index = 1;
	struct ListNode* pp_prev = dummy;

	struct ListNode* start = dummy->next;

	while (start != NULL)
	{
		if (IsEvenGroup(index)) // TODO
		{
			struct ListNode* end = start;
			int temp = 0;
			while (temp < index - 1 && end != NULL)
			{
				end = end->next;
				temp++;

			}
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
			//printf("temp %d and index %d\n", temp, index);
			index = index + temp;
			//printf("index %d\n", index);

		}
		else
		{
			//printf("HH odd index %d\n", index);

			pp_prev = start;
			start = start->next;
			index++;
		}
	}
	return head;
}

int main(int argc, char* argv[])
{
	int size = 10;
	int arr[] = { 5,2,6,3,9,1,7,3,8,4 }; //{ 5,2,6,3,9,1,7,3,8,4 };
	int len = 0;

	struct ListNode* list = ToList(arr, size);
	list = list->next;
	PrintList(list, "Before");

	struct ListNode* result = reverseEvenLengthGroups(list);

	PrintList(result, "After");

	return 0;
}

