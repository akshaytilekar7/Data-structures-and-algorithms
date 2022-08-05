// https://leetcode.com/problems/remove-duplicates-from-sorted-list/
// 83. Remove Duplicates from Sorted List
// https://leetcode.com/problems/remove-duplicates-from-sorted-list/discuss/2067167/C-Language

/*
	Runtime: 11 ms, faster than 24.00% of C online submissions for Remove Duplicates from Sorted List.
	Memory Usage: 6.5 MB, less than 59.37% of C online submissions for Remove Duplicates from Sorted List.
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

struct ListNode* deleteDuplicates(struct ListNode* head) {

	if (head == NULL)
		return head;

	struct ListNode* traverse = head;

	while (traverse != NULL)
	{
		if (traverse->next != NULL && traverse->val == traverse->next->val)
			traverse->next = traverse->next->next;
		else
			traverse = traverse->next;
	}

	return head;
}

int main(int argc, char* argv[])
{
	int cnt1 = atoi(argv[1]);

	struct ListNode* A1 = NULL;
	for (int i = 0; i < cnt1; i++)
	{
		int t = 0;
		printf("Enter Number for %d : ", i);
		scanf("%d", &t);
		A1 = Add(A1, t);
	}

	struct ListNode* temp = deleteDuplicates(A1);

	PrintList(temp, "result");

	return 0;
}