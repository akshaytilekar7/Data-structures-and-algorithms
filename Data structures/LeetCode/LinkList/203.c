// https://leetcode.com/problems/remove-linked-list-elements/
// 203. Remove Linked List Elements

/*
Runtime: 15 ms, faster than 59.41% of C online submissions for Remove Linked List Elements.
Memory Usage: 7.8 MB, less than 88.60% of C online submissions for Remove Linked List Elements.
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
	{
		printf("List is empty\n");
		return;
	}

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

struct ListNode* removeElements(struct ListNode* head, int val) {

	if (head == NULL)
		return head;

	while (head != NULL && head->val == val)
		head = head->next;

	struct ListNode* traverse = head;

	while (traverse != NULL)
	{
		bool isSame = traverse->next != NULL && traverse->next->val == val;

		if (isSame == true)
			traverse->next = traverse->next->next;
		else
			traverse = traverse->next;
	}

	return head;
}

int main(int argc, char* argv[])
{
	int cnt1 = atoi(argv[1]);
	printf("count 1 is %d \n", cnt1);
	struct ListNode* A1 = NULL;
	int tarr[] = { 1,2,6,3,4,5,6 };
	for (int i = 0; i < cnt1; i++)
	{
		/*int t = 0;
		printf("Enter Number for %d : ", i);
		scanf("%d", &t);*/
		A1 = Add(A1, tarr[i]);
	}

	PrintList(A1, "before");
	struct ListNode* temp = removeElements(A1, 6);
	PrintList(temp, "after");
	return 0;
}