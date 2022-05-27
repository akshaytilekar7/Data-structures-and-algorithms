// https://leetcode.com/problems/partition-list/
// 86. Partition List
// https://leetcode.com/problems/partition-list/discuss/2068180/C-Language

/*
Runtime: 9 ms, faster than 6.92% of C online submissions for Partition List.
Memory Usage: 6.1 MB, less than 39.23% of C online submissions for Partition List.
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

struct ListNode* partition(struct ListNode* head, int x) {

	if (head == NULL)
		return head;

	int* arr = (int*)malloc(200 * sizeof(int));
	struct ListNode* traverse = head;
	int index = 0;
	int isHead = 0;

	if (traverse->val >= x)
	{
		arr[index++] = traverse->val;
		isHead = 1;
	}
	while (traverse != NULL && traverse->next != NULL)
	{
		if (traverse->next->val >= x)
		{
			arr[index++] = traverse->next->val;
			traverse->next = traverse->next->next;
		}
		else
			traverse = traverse->next;
	}

	struct ListNode* result = head;

	while (result != NULL && result->next != NULL)
		result = result->next;

	for (int i = 0; i < index; i++)
		result = Add(result, arr[i]);

	if (isHead == 1)
		head = head->next;

	return head;
}

int main(int argc, char* argv[])
{
	/*int cnt1 = atoi(argv[1]);
	int cnt2 = atoi(argv[2]);

	struct ListNode* A1 = NULL;
	for (int i = 0; i < cnt1; i++)
	{
		int t = 0;
		printf("Enter Number for %d : ", i);
		scanf("%d", &t);
		A1 = Add(A1, t);
	}*/


	struct ListNode* A1 = NULL;
	int size = 6;
	int arr[] = { 1,4,3,2,5, 2 };
	int ele = 3;


	for (int i = 0; i < size; i++)
		A1 = Add(A1, arr[i]);

	PrintList(A1, "before");
	struct ListNode* result = partition(A1, ele);
	PrintList(result, "after");
	return 0;
}