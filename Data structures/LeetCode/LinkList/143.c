// https://leetcode.com/problems/reorder-list/
// 143. Reorder List
/*
Runtime: 40 ms, faster than 15.00% of C online submissions for Reorder List.
Memory Usage: 10.3 MB, less than 6.54% of C online submissions for Reorder List.
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

void PrintList(struct ListNode* head, char* msg)
{
	if (head == NULL)
		return;

	if (msg)
		printf("%s\t ", msg);

	printf("%d\n", head->val);
	PrintList(head->next, msg);
}

void reorderList(struct ListNode* head) {

	struct ListNode** arr = (struct ListNode**)malloc(50000 * sizeof(struct ListNode*));

	struct ListNode* traverse = head;
	int size = 0;
	while (traverse != NULL)
	{
		arr[size] = (traverse);
		size++;
		traverse = traverse->next;
	}

	int last = size - 1;
	int start = 0;
	for (int i = 0; i < (size/2) ; i = i +1 )
	{
		arr[i]->next = arr[last];
		arr[last]->next = arr[start + 1];
		if (arr[last]->next != NULL)
			arr[last]->next->next = NULL;
		last--;
		start++;
	}

	PrintList(head, NULL);
}

int main(int argc, char* argv[])
{
	int cnt1 = atoi(argv[1]);
	printf("count 1 is %d \n", cnt1);

	struct ListNode* A1 = NULL;
	for (int i = 1; i <= cnt1; i++)
	{
		/*int t = 0;
		printf("Enter Number for %d : ", i);
		scanf("%d", &t);*/
		A1 = Add(A1, i);
	}

	reorderList(A1);

	return 0;
}