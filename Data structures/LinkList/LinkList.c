#include <stdio.h> 
#include <stdlib.h> 
#include <assert.h>


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

	head = AddFirst(head, 564);

	for (int i = 1; i <= N; i++)
	{
		int data = i * 10;// rand();
		//printf("%d : %d\n", i, data);
		head = Add(head, data);
	}

	head = AddFirst(head, 514);
	int val1 = AddAfterIfExist(head, 5000, 50);
	head = AddBeforeIfExist(head, 8000, 5000);

	PrintList(head, NULL);
	return (EXIT_SUCCESS);
}
