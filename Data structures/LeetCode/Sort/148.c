// https://leetcode.com/problems/sort-list/
// 148. Sort List
// https://leetcode.com/problems/sort-list/discuss/2120991/C-Language-Merge-sort


/*
Runtime: 190 ms, faster than 8.64% of C online submissions for Sort List.
Memory Usage: 42.6 MB, less than 5.23% of C online submissions for Sort List.
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

/******NOT RUNNING QUICK SORT******/

struct ListNode* Partition(struct ListNode* head, struct ListNode* start, struct ListNode* end)
{
	struct ListNode* pivot = end;
	struct ListNode* partitionNode = head;
	struct ListNode* travel = start;

	printf("\ttravel val is [%d] \n ", travel->val);
	printf("\tpivot val is  [%d]\n ", pivot->val);
	printf("\tpartitionNode val is  [%d]\n ", partitionNode->val);

	while (travel != end)
	{

		if (travel->val <= pivot->val)
		{
			int t = travel->val;
			travel->val = partitionNode->val;
			partitionNode->val = t;
			partitionNode = partitionNode->next;
		}
		travel = travel->next;
	}

	if (partitionNode == NULL) printf("partitionNode is null");

	int t = partitionNode->val;
	partitionNode->val = pivot->val;
	pivot->val = t;
	return pivot;
}

struct ListNode* QuickProcedure(struct ListNode* head, struct ListNode* start, struct ListNode* end)
{
	if (head == start && head == end) return head;
	bool isValid = false;
	struct ListNode* travel = start;

	while (travel != NULL)
	{
		if (travel == end)
		{
			isValid = true;
			break;
		}
		travel = travel->next;
	}
	if (isValid)
	{
		struct ListNode* end = head;
		while (end->next != NULL)
			end = end->next;

		struct ListNode* travel = Partition(head, start, end);
		QuickProcedure(head, head, travel);
		QuickProcedure(head, travel->next, end);
	}
	printf("QP return \n ");
	return head;
}

struct ListNode* sortList1(struct ListNode* head) {

	if (head == NULL || head->next == NULL)
		return head;

	struct ListNode* end = head;

	while (end->next != NULL)
		end = end->next;

	QuickProcedure(head, head, end);
	return head;
}

/******NOT RUNNING QUICK SORT******/


/******RUNNING******/

struct ListNode* mergeTwoLists(struct ListNode* list1, struct ListNode* list2)
{
	if (list1 == NULL && list2 == NULL) return NULL;

	if (list1 == NULL) return list2;
	if (list2 == NULL) return list1;

	struct ListNode* main = (struct ListNode*)malloc(sizeof(struct ListNode));
	main->val = -1;
	main->next = NULL;
	struct ListNode* travelResult = main;
	struct ListNode* travel1 = list1;
	struct ListNode* travel2 = list2;

	while (true)
	{
		if (travel1->val <= travel2->val)
		{
			//InsertAtEnd(travelResult, travel1->val);
			travelResult->next = travel1;
			travelResult = travelResult->next;
			travel1 = travel1->next;

			if (travel1 == NULL)
			{
				while (travel2 != NULL)
				{
					//InsertAtEnd(travelResult, travel2->val);
					travelResult->next = travel2;
					travelResult = travelResult->next;
					travel2 = travel2->next;
				}
				break;
			}
		}
		else
		{
			//InsertAtEnd(travelResult, travel2->val);
			travelResult->next = travel2;
			travelResult = travelResult->next;
			travel2 = travel2->next;

			if (travel2 == NULL)
			{
				while (travel1 != NULL)
				{
					//InsertAtEnd(travelResult, travel1->val);
					travelResult->next = travel1;
					travelResult = travelResult->next;
					travel1 = travel1->next;
				}
				break;
			}
		}
	}

	return main->next;
}

struct ListNode* sortList(struct ListNode* head) {

	if (head == NULL || head->next == NULL)
		return head;

	struct ListNode* slow = head;
	struct ListNode* fast = head->next;

	while (fast != NULL && fast->next != NULL)
	{
		slow = slow->next;
		fast = fast->next->next;
	}

	// breaks the LL into 2 parts by removing link
	fast = slow->next;
	slow->next = NULL;

	struct ListNode* firstHalf = sortList(head);
	struct ListNode* secondHalf = sortList(fast);
	return mergeTwoLists(firstHalf, secondHalf);
}

/******RUNNING******/

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
	int arg1 = 5; // atoi(argv[1]);

	int arr[] = { 5,1,6,3,2 };
	struct ListNode* traverse = NULL;
	for (int i = 0; i < arg1; i++)
	{
		int t = 0;
		/*printf("Enter Number for %d : ", i);
		scanf("%d", &t);*/
		traverse = Add(traverse, arr[i]);
	}

	PrintList(traverse, "Before");

	struct ListNode* result = sortList(traverse);

	PrintList(result, "After");

	return 0;
}