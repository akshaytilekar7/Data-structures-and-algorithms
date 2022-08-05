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

struct ListNode* addTwoNumbers(struct ListNode* l1, struct ListNode* l2)
{
	struct ListNode* t1 = l1;
	struct ListNode* t2 = l2;
	int* arr1 = (int*)calloc(100, sizeof(int));
	int* arr2 = (int*)calloc(100, sizeof(int));
	int* arr3 = (int*)calloc(100, sizeof(int));
	int cnt1 = 0;
	int cnt2 = 0;
	int sumPerNode = 0;
	int reminderPerNode = 0;
	int size = 0;
	while (t1 != NULL && t2 != NULL)
	{
		arr1[cnt1] = t1->val;
		arr2[cnt2] = t2->val;
		t1 = t1->next;
		t2 = t2->next;
		sumPerNode = reminderPerNode + arr1[cnt1] + arr2[cnt2];
		reminderPerNode = 0;
		if (sumPerNode >= 10)
		{
			reminderPerNode = (sumPerNode / 10);
			sumPerNode = sumPerNode % 10;
			arr3[size++] = sumPerNode;
		}
		else {
			arr3[size++] = sumPerNode;
		}
		cnt1++;
		cnt2++;
	}
	while (t1 != NULL)
	{
		arr1[cnt1] = t1->val;
		t1 = t1->next;
		sumPerNode = reminderPerNode + arr1[cnt1];
		reminderPerNode = 0;
		if (sumPerNode >= 10)
		{
			reminderPerNode = (sumPerNode / 10);
			sumPerNode = sumPerNode % 10;
			arr3[size++] = sumPerNode;
		}
		else {
			arr3[size++] = sumPerNode;
		}
		cnt1++;
	}
	while (t2 != NULL)
	{
		arr2[cnt2] = t2->val;
		t2 = t2->next;
		sumPerNode = reminderPerNode + arr2[cnt2];
		reminderPerNode = 0;
		if (sumPerNode >= 10)
		{
			reminderPerNode = (sumPerNode / 10);
			sumPerNode = sumPerNode % 10;
			arr3[size++] = sumPerNode;
		}
		else {
			arr3[size++] = sumPerNode;
		}
		cnt2++;
	}
	if (reminderPerNode != 0)
		arr3[size++] = reminderPerNode;
	struct ListNode* finalLL = NULL;
	for (int i = 0; i < size; i++)
		finalLL = Add(finalLL, arr3[i]);
	return finalLL;
}

int main(int argc, char* argv[])
{
	/*struct ListNode* A1 = (struct ListNode*)malloc(sizeof(struct ListNode));
	struct ListNode* A11 = (struct ListNode*)malloc(sizeof(struct ListNode));
	struct ListNode* A12 = (struct ListNode*)malloc(sizeof(struct ListNode));
	struct ListNode* A13 = (struct ListNode*)malloc(sizeof(struct ListNode));*/

	/*struct ListNode* B1 = (struct ListNode*)malloc(sizeof(struct ListNode));
	struct ListNode* B11 = (struct ListNode*)malloc(sizeof(struct ListNode));
	struct ListNode* B12 = (struct ListNode*)malloc(sizeof(struct ListNode));
	struct ListNode* B13 = (struct ListNode*)malloc(sizeof(struct ListNode));*/

	int cnt1 = atoi(argv[1]);
	int cnt2 = atoi(argv[2]);
	printf("count 1 is %d \n", cnt1);
	printf("count 2 is %d \n", cnt2);

	struct ListNode* A1 = NULL;
	for (int i = 0; i < cnt1; i++)
	{
		int t = 0;
		printf("Enter Number for %d : ", i);
		scanf("%d", &t);
		A1 = Add(A1, t);
	}

	struct ListNode* B1 = NULL;// (struct ListNode*)malloc(sizeof(struct ListNode));
	for (int i = 0; i < cnt2; i++)
	{
		int t = 0;
		printf("Enter Number for %d : ", i);
		scanf("%d", &t);
		B1 = Add(B1, t);
	}


	// 7 //4

	/*A1 = A11;
	A11->val = 2;
	A11->next = A12;
	A12->val = 4;
	A12->next = A13;
	A13->val = 3;
	A13->next = NULL;

	B1 = B11;
	B11->val = 5;
	B11->next = B12;
	B12->val = 6;
	B12->next = B13;
	B13->val = 4;
	B13->next = NULL;*/

	/*PrintList(A1, "A1");
	PrintList(B1, "B1");*/

	struct ListNode* temp = addTwoNumbers(A1, B1);

	//PrintList(temp, "temp");

	return 0;
}