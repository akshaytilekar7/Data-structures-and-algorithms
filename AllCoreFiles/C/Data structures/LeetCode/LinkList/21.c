// https://leetcode.com/problems/merge-two-sorted-lists/
// 21. Merge Two Sorted Lists
// https://leetcode.com/problems/merge-two-sorted-lists/discuss/2080061/C-Language
/*
Runtime: 9 ms, faster than 17.96% of C online submissions for Merge Two Sorted Lists.
Memory Usage: 6 MB, less than 69.74% of C online submissions for Merge Two Sorted Lists.
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

struct ListNode* mergeTwoLists(struct ListNode* list1, struct ListNode* list2) {

	struct ListNode* t1 = NULL;
	struct ListNode* t2 = NULL;
	struct ListNode* result = NULL;

	if (list1 == NULL)
		return list2;

	if (list2 == NULL)
		return list1;

	if (list1->val < list2->val)
	{
		result = t1 = list1;
		t2 = list2;
	}
	else
	{
		result = t1 = list2;
		t2 = list1;
	}
	while (t1 != NULL)
	{
		if ((t1 != NULL && t2 != NULL && t1->val <= t2->val && t1->next != NULL && t1->next->val >= t2->val))
		{
			struct ListNode* newNode = (struct ListNode*)malloc(sizeof(struct ListNode));
			newNode->val = t2->val;
			newNode->next = t1->next;
			t1->next = newNode;
			t1 = t1->next;
			t2 = t2->next;
		}
		else if (t1->next == NULL)
		{
			t1->next = t2;
			break;
		}
		else
			t1 = t1->next;
	}

	return result;
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