// https://leetcode.com/problems/merge-two-sorted-lists/
// 21. Merge Two Sorted Lists
// https://leetcode.com/problems/merge-two-sorted-lists/discuss/2106376/C-Language
/*
Runtime: 3 ms, faster than 84.19% of C online submissions for Merge Two Sorted Lists.
Memory Usage: 6.2 MB, less than 51.81% of C online submissions for Merge Two Sorted Lists.
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
	if (msg)
		printf("%s\t ", msg);

	if (head == NULL)
		return;

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

int main(int argc, char* argv[])
{
	int arg1 = atoi(argv[1]);
	int arg2 = atoi(argv[2]);

	struct ListNode* A1 = NULL;
	for (int i = 0; i < arg1; i++)
	{
		int t = 0;
		printf("Enter Number for %d : ", i);
		scanf("%d", &t);
		A1 = Add(A1, t);
	}

	struct ListNode* B1 = NULL;
	for (int i = 0; i < arg2; i++)
	{
		int t = 0;
		printf("Enter Number for %d : ", i);
		scanf("%d", &t);
		B1 = Add(B1, t);
	}
	PrintList(A1, "A1");
	PrintList(B1, "B1");

	struct ListNode* result = mergeTwoLists(A1, B1);
	PrintList(result, "After");

	printf("DONE");

	return 0;
}