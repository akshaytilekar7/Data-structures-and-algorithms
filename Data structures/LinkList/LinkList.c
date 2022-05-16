#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h>
#include <stdbool.h>

struct Node {
	int Data;
	struct Node* Next;
};

void PrintList(struct Node* head, char* msg)
{
	if (head == NULL)
		return;
	if (msg)
		printf("%s\t ", msg);

	printf("%d\n", head->Data);
	PrintList(head->Next, msg);
}

struct Node* Add(struct Node* head, int data)
{
	struct Node* temp = (struct Node*)malloc(sizeof(struct Node));
	temp->Data = data;
	temp->Next = NULL;

	if (head == NULL)
	{
		head = (struct Node*)malloc(sizeof(struct Node));
		head->Data = data;
		head->Next = NULL;
	}
	else
	{
		struct Node* traverse = head;
		while (traverse->Next != NULL)
		{
			traverse = traverse->Next;
		}
		traverse->Next = temp;
	}
	return head;
}

struct Node* AddFirst(struct Node* head, int data)
{
	struct Node* temp = (struct Node*)malloc(sizeof(struct Node));
	temp->Data = data;
	temp->Next = NULL;

	if (head == NULL)
	{
		head = temp;
	}
	else
	{
		temp->Next = head;
	}

	return temp;
}

int AddAfterIfExist(struct Node* head, int dataToAdd, int afterData)
{
	if (head == NULL)
		return -1;

	struct Node* traverse = head;
	while (traverse != NULL)
	{
		if (traverse->Data == afterData)
		{
			struct Node* temp = (struct Node*)malloc(sizeof(struct Node));
			temp->Data = dataToAdd;
			temp->Next = traverse->Next;
			traverse->Next = temp;
			return 1;
		}
		traverse = traverse->Next;
	}

	return -1;
}

struct Node* AddBeforeIfExist(struct Node* head, int dataToAdd, int afterData)
{
	if (head == NULL)
		return head;

	struct Node* traverse = head;
	if (traverse != NULL)
	{
		// 1st node
		if (traverse->Data == afterData)
		{
			struct Node* temp = (struct Node*)malloc(sizeof(struct Node));
			temp->Data = dataToAdd;
			temp->Next = traverse;
			head = temp;
			return head;
		}
	}
	while (traverse->Next != NULL)
	{
		if (traverse->Next->Data == afterData) // just before 1 place
		{
			struct Node* temp = (struct Node*)malloc(sizeof(struct Node));
			temp->Data = dataToAdd;
			temp->Next = traverse->Next;
			traverse->Next = temp;
			return head;
		}
		traverse = traverse->Next;
	}

	return head;
}

int GetFirst(struct Node* head)
{
	if (head == NULL)
		return -1;

	return head->Data;
}

int GetLast(struct Node* head)
{
	// Empty
	if (head == NULL)
		return -1;

	struct Node* traverse = head;

	// only 1 node
	if (traverse->Next == NULL)
		return traverse->Data;

	// more than 2 node
	while (traverse->Next != NULL)
		traverse = traverse->Next;

	return traverse->Data;
}

int PopFirst(struct Node** head)
{
	if ((*head) == NULL)
		return -1;

	int temp = (*head)->Data;
	(*head) = (*head)->Next;
	return temp;
}

int PopLast(struct Node** head)
{
	if ((*head) == NULL)
		return -1;

	struct Node* temp = (*head);
	int data = -1;

	// 1 node in list // HEAD CHANGE
	if (temp->Next == NULL)
	{
		(*head) = NULL;
		return temp->Data;;
	}

	// 2 node in list
	if (temp->Next->Next == NULL)
	{
		//puts("2 ele\n");
		data = temp->Next->Data;
		temp->Next = NULL;
		return data;
	}

	// more than 2 node (3,4,5...)
	struct Node* fast = (*head);
	while (fast->Next->Next != NULL)
		fast = fast->Next;

	data = fast->Next->Data;
	fast->Next = NULL;
	return data;
}

int RemoveFirstOccurence(struct Node** head, int data)
{
	// 1 ele
	if ((*head)->Data == data)
		return PopFirst(head);

	struct Node* traverse = (*head);

	while (traverse->Next != NULL) {
		if (traverse->Next->Data == data)
		{
			traverse->Next = traverse->Next->Next;
			return 1;
		}
		traverse = traverse->Next;
	}

	return -1;
}

bool IsEmpty(struct Node* head)
{
	return head == NULL;
}

int Length(struct Node* head)
{
	if (head == NULL)
		return 0;

	return 1 + Length(head->Next);
}

int main(int argc, char* argv[])
{
	int N = 0;

	if (argc != 2)
	{
		fprintf(stderr, "Usage Error: Correct Usage %s nr_elements", argv[0]);
		exit(EXIT_FAILURE);
	}

	N = atoi(argv[1]);

	assert(N > 0);
	struct Node* head = NULL;

	printf("Total Node : %d\n", N);

	//head = AddFirst(head, 564);

	for (int i = 1; i <= N; i++)
	{
		int data = i * 10;// rand();
		//printf("%d : %d\n", i, data);
		head = Add(head, data);
	}

	/*head = AddFirst(head, 514);
	int val1 = AddAfterIfExist(head, 5000, 50);
	head = AddBeforeIfExist(head, 8000, 5000);*/

	PrintList(head, NULL);

	/*int first = GetFirst(head);
	printf("Get First : %d\n", first);
	int last = GetLast(head);
	printf("Get last  : %d\n", last);

	PrintList(head, "at mid");

	first = PopFirst(&head);
	printf("Pop First : %d\n", first);
	int last = PopLast(&head);
	printf("Pop Last  : %d\n", last);*/


	/*int r = RemoveFirstOccurence(&head, 1000);
	PrintList(head, "at last after RemoveFirstOccurence");*/
	printf("is Empty : %s\n", IsEmpty(head) ? "true" : "false");
	printf("Length is : %d\n", Length(head));

	PrintList(head, "at last");

	return (EXIT_SUCCESS);
}
