// https://leetcode.com/problems/reverse-linked-list-ii/
// 92. Reverse Linked List II
// https://leetcode.com/problems/reverse-linked-list-ii/discuss/2077674/C-Language

/*
Runtime: 3 ms, faster than 42.66% of C online submissions for Reverse Linked List II.
Memory Usage: 5.8 MB, less than 53.15% of C online submissions for Reverse Linked List II.
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

struct ListNode* reverseBetween(struct ListNode* head, int left, int right) {

	if (head == NULL) return NULL;

	if (left == right) return head;

	struct ListNode* prev = NULL;
	struct ListNode* curr = head;

	int index = 1;
	while (index < left)
	{
		prev = curr;
		curr = curr->next;
		index++;
	}

	struct ListNode* leftMinusOneNode = prev;

	struct ListNode* leftNode = curr;
	struct ListNode* next = NULL;

	while (left <= right)
	{
		next = curr->next;

		curr->next = prev;

		prev = curr;
		curr = next;
		left++;
	}

	if (leftMinusOneNode == NULL) // means head changes
		head = prev;
	else
		leftMinusOneNode->next = prev;   // [	1	(2	<-	3	<-	4)	5	]  // when input -> 5 2 4
										 //	 1 is leftMinusOneNode and 4 is prev
										 //  so 1's next is 4	
	leftNode->next = curr;				 //  and 2 is leftNode, so makes 2's next is 5	

	return head;
}

int main(int argc, char* argv[])
{
	int arg1 = atoi(argv[1]);
	int arg2 = atoi(argv[2]);
	int arg3 = atoi(argv[3]);
	//printf("arg1 is %d \n", arg1);
	//printf("arg2 is %d \n", arg2);
	//printf("arg3 is %d \n", arg3);

	struct ListNode* traverse = NULL;
	for (int i = 1; i <= arg1; i++)
		traverse = Add(traverse, i);

	PrintList(traverse, "Before");

	struct ListNode* result = reverseBetween(traverse, arg2, arg3);

	PrintList(result, "After");
	return 0;
}