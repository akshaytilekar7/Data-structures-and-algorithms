#include <stdio.h> 
#include <stdlib.h> 
#include "PriorityQueue.h"

// higher priority elements are served first.
// same priority occur, they are served according to their order in the queue.
// normal queue		-   first-in-first-out rule
// priority queue	-	on the basis of priority
//					-	implement by  array / linked list / heap (faster)

static NodeType* GetNewNode(EmployeeType* employee)
{
	NodeType* node = (NodeType*)malloc(sizeof(NodeType));
	node->Employee = employee;
	node->Next = node;
	node->Prev = node;
	return node;
}

ListType* CreateList()
{
	ListType* list = (ListType*)malloc(sizeof(ListType));
	EmployeeType* employee = (EmployeeType*)malloc(sizeof(EmployeeType));
	employee->FirstName = "dummy first name";
	employee->LastName = "dummy first name";
	employee->RollNumber = -1;
	list = GetNewNode(employee);
	return list;
}

static void GenericInsert(NodeType* prev, NodeType* mid, NodeType* next)
{
	mid->Next = next;
	mid->Prev = prev;
	prev->Next = mid;
	next->Prev = mid;
}

static void GenericDelete(NodeType* deleteNode)
{
	deleteNode->Prev->Next = deleteNode->Next;
	deleteNode->Next->Prev = deleteNode->Prev;
	free(deleteNode);
	deleteNode = NULL;
}

statusType IsEmpty(ListType* list)
{
	if (list == NULL) return StackIsEmpty;
	return (list->Prev == list && list->Next == list);
}

dataType GetLength(ListType* list)
{
	ListType* travel = list->Next;
	int count = 0;
	while (travel != list)
	{
		count++;
		travel = travel->Next;
	}
	return count;
}

void PrintList(ListType* list, char* msg)
{
	if (msg)
		printf("%s\n", msg);

	ListType* travel = list->Next;
	printf("[START]");
	while (travel != list)
	{
		printf("<-[%d_%s_%s]->",
			travel->Employee->RollNumber,
			travel->Employee->FirstName,
			travel->Employee->LastName);

		travel = travel->Next;
	}
	printf("[END]\n");
}

void PrintEmployee(char* msg, EmployeeType* data)
{
	if (msg)
		printf("%s\n", msg);

	if (data == NULL)
		printf("data is empty\n");

	printf("\t[%d] [%s] [%s]\n", data->RollNumber, data->FirstName, data->LastName);

}

statusType Enqueue(ListType* list, EmployeeType* employee)
{
	// start
	GenericInsert(list, GetNewNode(employee), list->Next);
	return SUCCESS;
}

statusType Peek(ListType* list, EmployeeType* employee)
{
	// last
	if (IsEmpty(list)) return StackIsEmpty;
	employee->LastName = list->Prev->Employee->LastName;
	employee->FirstName = list->Prev->Employee->FirstName;
	employee->RollNumber = list->Prev->Employee->RollNumber;
	return SUCCESS;
}

statusType Dequeue(ListType* list, EmployeeType* employee)
{
	// last
	if (IsEmpty(list)) return StackIsEmpty;
	employee->LastName = list->Prev->Employee->LastName;
	employee->FirstName = list->Prev->Employee->FirstName;
	employee->RollNumber = list->Prev->Employee->RollNumber;
	GenericDelete(list->Prev);
	return SUCCESS;
}