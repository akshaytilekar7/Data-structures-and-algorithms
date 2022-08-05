// https://leetcode.com/problems/merge-in-between-linked-lists/
// 1669. Merge In Between Linked Lists
// https://leetcode.com/problems/merge-in-between-linked-lists/discuss/2080322/C-Language

/*
Runtime: 193 ms, faster than 30.43% of C online submissions for Merge In Between Linked Lists.
Memory Usage: 33.1 MB, less than 50.72% of C online submissions for Merge In Between Linked Lists.
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

struct ListNode* mergeInBetween(struct ListNode* list1, int a, int b, struct ListNode* list2) {

	if (list1 == NULL)
		return list2;

	if (list2 == NULL)
		return list1;


	struct ListNode* start = list1;
	struct ListNode* end = list1;

	int index = 0;
	while (index < a - 1)
	{
		start = start->next;
		index++;
	}

	index = 0;
	while (index < b + 1)
	{
		end = end->next;
		index++;
	}

	start->next = list2;

	struct ListNode* travel = list2;

	while (travel->next != NULL)
		travel = travel->next;

	travel->next = end;

	printf("start %d\n", start->val);
	printf("end %d\n", end->val);

	return list1;
}

int main(int argc, char* argv[])
{
	int arg1 = atoi(argv[1]);
	int arg2 = atoi(argv[2]);
	int arg3 = atoi(argv[3]);
	int arg4 = atoi(argv[4]);

	printf("arg1 1 is %d \n", arg1);
	printf("arg2 2 is %d \n", arg2);

	struct ListNode* traverse1 = NULL;
	for (int i = 0; i < arg1; i++)
	{
		int t = 0;
		printf("Enter Number for %d : ", i);
		scanf("%d", &t);
		traverse1 = Add(traverse1, t);
	}

	struct ListNode* traverse2 = NULL;
	for (int i = 0; i < arg2; i++)
	{
		int t = 0;
		printf("Enter Number for %d : ", i);
		scanf("%d", &t);
		traverse2 = Add(traverse2, t);
	}

	PrintList(traverse1, "traverse1 Before");
	PrintList(traverse2, "traverse2 Before");

	struct ListNode* result = mergeInBetween(traverse1, arg3, arg4, traverse2);

	PrintList(result, "After");

	return 0;
}