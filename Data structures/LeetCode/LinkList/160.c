// https://leetcode.com/problems/intersection-of-two-linked-lists/
// 160. Intersection of Two Linked Lists
//

/*
https://leetcode.com/problems/intersection-of-two-linked-lists/discuss/49785/Java-solution-without-knowing-the-difference-in-len!

Runtime: 71 ms, faster than 28.13% of C online submissions for Intersection of Two Linked Lists.
Memory Usage: 13.9 MB, less than 74.70% of C online submissions for Intersection of Two Linked Lists.

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
	if (head == NULL)
		return 0;

	return 1 + GetLength(head->next);
}

struct ListNode* getIntersectionNode(struct ListNode* headA, struct ListNode* headB) {

	if (headA == NULL || headB == NULL)
		return NULL;

	struct ListNode* t1 = headA;
	struct ListNode* t2 = headB;

	while (t1 != t2)
	{

		if (t1 == NULL)
			t1 = headB;
		else
			t1 = t1->next;


		if (t2 == NULL)
			t2 = headA;
		else
			t2 = t2->next;
	}

	return t1;
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



	/*struct ListNode* temp = getIntersectionNode(A1);

	PrintList(temp, "result");*/

	return 0;
}