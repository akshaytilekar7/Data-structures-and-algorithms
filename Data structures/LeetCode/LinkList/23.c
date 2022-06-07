// https://leetcode.com/problems/merge-k-sorted-lists/
// 23. Merge k Sorted Lists
// 
/*
TLE :-(  :-(  :-(  :-( 
https://leetcode.com/problems/merge-k-sorted-lists/discuss/267843/C-20ms-Solution
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

void PrintListHelper(struct ListNode* head)
{
	if (head == NULL)
		return;

	printf("%d->", head->val);
	PrintListHelper(head->next);
}

void PrintList(struct ListNode* head, char* msg)
{
	if (msg)
		printf("%s\t ", msg);

	if (head == NULL)
		return;

	printf("[START]->");
	PrintListHelper(head);
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

struct ListNode* CreateNode()
{
	struct ListNode* node = (struct ListNode*)malloc(1 * sizeof(struct ListNode));
	node->next = NULL;
	node->val = -1;
	return node;
}

struct ListNode* GetNewNode(int data)
{
	struct ListNode* node = CreateNode();
	node->val = data;
	return node;
}

void  InsertAtEnd(struct ListNode* list, int data)
{
	struct ListNode* travel = list;
	while (travel->next != NULL)
	{
		travel = travel->next;
	}
	struct ListNode* nodeToAdd = GetNewNode(data);
	nodeToAdd->next = travel->next;
	travel->next = nodeToAdd;
}

struct ListNode* mergeTwoLists(struct ListNode* list1, struct ListNode* list2)
{
	if (list1 == NULL && list2 == NULL) return NULL;

	if (list1 == NULL) return list2;
	if (list2 == NULL) return list1;

	struct ListNode* result = CreateNode();

	struct ListNode* travelResult = result;
	struct ListNode* travel1 = list1;
	struct ListNode* travel2 = list2;

	while (true)
	{
		if (travel1->val <= travel2->val)
		{
			InsertAtEnd(travelResult, travel1->val);
			travelResult = travelResult->next;
			travel1 = travel1->next;

			if (travel1 == NULL)
			{
				while (travel2 != NULL)
				{
					InsertAtEnd(travelResult, travel2->val);
					travelResult = travelResult->next;
					travel2 = travel2->next;
				}
				break;
			}
		}
		else
		{
			InsertAtEnd(travelResult, travel2->val);
			travelResult = travelResult->next;
			travel2 = travel2->next;

			if (travel2 == NULL)
			{
				while (travel1 != NULL)
				{
					InsertAtEnd(travelResult, travel1->val);
					travelResult = travelResult->next;
					travel1 = travel1->next;
				}
				break;
			}
		}
	}

	return result->next;
}

struct ListNode* mergeKLists(struct ListNode** lists, int listsSize)
{
	if (listsSize == 0) return NULL;
	if (listsSize == 1) return lists[0];

	struct ListNode* result = mergeTwoLists(lists[0], lists[1]);
	for (int i = 2; i < listsSize; i++)
		result = mergeTwoLists(result, lists[i]);

	return result;
}

int main(int argc, char* argv[])
{
	int arg1 = atoi(argv[1]);

	struct ListNode** arr = (struct ListNode**)malloc(arg1 * sizeof(struct ListNode*));
	for (int i = 0; i < arg1; i++)
	{
		arr[i] = NULL;
		int t = 0;
		printf("Enter node count for list %d : ", i);
		scanf("%d", &t);
		for (int j = 0; j < t; j++)
		{
			int r = 0;
			printf("list [%d] : Enter data [%d] : ", i, j);
			scanf("%d", &r);
			arr[i] = Add(arr[i], r);
		}
	}

	for (int i = 0; i < arg1; i++)
	{
		printf("list %d :\n", i);
		PrintList(arr[i], NULL);
	}

	struct ListNode* result = mergeKLists(arr, arg1);

	PrintList(result, "After");

	printf("DONE");

	return 0;
}