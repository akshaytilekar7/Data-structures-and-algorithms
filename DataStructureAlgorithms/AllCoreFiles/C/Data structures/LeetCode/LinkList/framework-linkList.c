// 
// 
// 

/*

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

int main(int argc, char* argv[])
{
	int arg1 = atoi(argv[1]);
	int arg2 = atoi(argv[2]);
	printf("arg1 1 is %d \n", arg1);
	printf("arg2 2 is %d \n", arg2);

	struct ListNode* traverse = NULL;
	for (int i = 0; i < arg1; i++)
	{
		int t = 0;
		printf("Enter Number for %d : ", i);
		scanf("%d", &t);
		traverse = Add(traverse, t);
	}
	
	PrintList(traverse, "Before");

	struct ListNode* result = reverseBetween(traverse, arg2, arg3);

	PrintList(result, "After");

	return 0;
}