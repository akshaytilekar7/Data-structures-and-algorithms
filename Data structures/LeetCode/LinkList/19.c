// https://leetcode.com/problems/remove-nth-node-from-end-of-list/
// 19. Remove Nth Node From End of List
// https://leetcode.com/problems/remove-nth-node-from-end-of-list/discuss/2048620/C-Language

/*
Runtime: 0 ms, faster than 100.00% of C online submissions for Remove Nth Node From End of List.
Memory Usage: 6 MB, less than 32.99% of C online submissions for Remove Nth Node From End of List.
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

int GetLength(struct ListNode* head)
{
	struct ListNode* traverse = head;

	int Length = 0;
	while (traverse != NULL)
	{
		traverse = traverse->next;
		Length++;
	}

	return Length;
}
struct ListNode* removeNthFromEnd(struct ListNode* head, int n) {

	int length = GetLength(head);

	// length is 1 and toBe delted is 1
	if (length == 1 && n == 1) 
		return NULL;

	// 1st node deletion - simply returns head -> next
	if (length == n)
		return head -> next;

	int deleteIndex = length - n - 1;


	struct ListNode* traverse = head;
	while (deleteIndex > 0)
	{
		traverse = traverse->next;
		deleteIndex--;
	}
	traverse->next = traverse->next->next;
	return head;
}


int main(int argc, char* argv[])
{
	int cnt1 = atoi(argv[1]);
	//printf("Length 1 is %d \n", cnt1);

	struct ListNode* A1 = NULL;
	for (int i = 1; i <= cnt1; i++)
	{
		//int t = 0;
		//printf("Enter Number for %d : ", i);
		//scanf("%d", &t);
		A1 = Add(A1, i);
	}

	struct ListNode* temp = removeNthFromEnd(A1, 2);

	PrintList(temp, ": ");
	return 0;
}