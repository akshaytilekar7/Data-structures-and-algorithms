// 61. Rotate List
// https://leetcode.com/problems/rotate-list/

/*
Runtime: 0 ms, faster than 100.00% of C online submissions for Rotate List.
Memory Usage: 6 MB, less than 79.95% of C online submissions for Rotate List.
*/

#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h>
#include <string.h>

struct ListNode {
	int val;
	struct ListNode* next;
};

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

void PrintArray(struct ListNode* head, char* msg)
{
	if (head == NULL)
		return;
	printf("%d ", head->val);
	PrintArray(head->next, msg);
}

void PrintList(struct ListNode* head, char* msg)
{
	if (msg)
		printf("%s\n", msg);

	printf("[");
	PrintArray(head, msg);
	printf("]\n");

}

int GetLength(struct ListNode* head)
{
	if (head == NULL)
		return 0;

	return 1 + GetLength(head->next);
}

struct ListNode* rotateRight(struct ListNode* head, int k) {

	if (head == NULL || k == 0)
		return head;

	int length = GetLength(head);

	if (length == 1)
		return head;

	if (k > length)
	{
		int t = k / length;
		k = k - (t * length);
	}

	while (k > 0)
	{
		int tempLength = length;
		struct ListNode* secondLastNode = head;
		while (tempLength - 2 > 0)
		{
			secondLastNode = secondLastNode->next;
			tempLength--;
		}
		secondLastNode->next->next = head;
		head = secondLastNode->next;
		secondLastNode->next = NULL;
		k--;
	}
	return head;
}

int main(int argc, char* argv[])
{
	int cnt1 = atoi(argv[1]);
	int cnt2 = atoi(argv[2]);

	struct ListNode* head = NULL;
	for (int i = 1; i <= cnt1; i++)
	{
		/*int t = 0;
		printf("Enter Number for %d : ", i);
		scanf("%d", &t);*/
		head = Add(head, i);
	}

	struct ListNode* res = rotateRight(head, cnt2);

	PrintList(res, "result");

	return 0;
}