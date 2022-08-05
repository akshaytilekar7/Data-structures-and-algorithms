// https://leetcode.com/problems/palindrome-linked-list/
// 234. Palindrome Linked List
// https://leetcode.com/problems/palindrome-linked-list/discuss/2080230/C-Language

/*
Runtime: 142 ms, faster than 91.44% of C online submissions for Palindrome Linked List.
Memory Usage: 41.4 MB, less than 70.33% of C online submissions for Palindrome Linked List.
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

bool isPalindrome(struct ListNode* head) {

	if (head == NULL) return true;

	struct ListNode* slow = head;
	struct ListNode* fast = head;
	int size = 0;

	while (fast != NULL && fast->next != NULL)
	{
		slow = slow->next;
		fast = fast->next->next;
		size++;
	}

	struct ListNode* temp = slow;
	int arr[size + 1];
	int index = 0;
	while (temp != NULL)
	{
		arr[index] = temp->val;
		temp = temp->next;
		index++;
	}

	struct ListNode* start = head;
	while (start != slow && (index - 1) >= 0)
	{
		if (start->val != arr[index - 1])
			return false;
		index--;
		start = start->next;
	}

	return true;
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

	struct ListNode* traverse = NULL;
	for (int i = 0; i < arg1; i++)
	{
		int t = 0;
		printf("Enter Number for %d : ", i);
		scanf("%d", &t);
		traverse = Add(traverse, t);
	}

	PrintList(traverse, "After");

	bool result = isPalindrome(traverse);

	printf("Is Pallindrome %s", result ? "True" : "False");

	return 0;
}