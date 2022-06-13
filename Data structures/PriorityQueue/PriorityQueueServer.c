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
	employee->Attendance = -1;
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
	printf("[START]\n");
	while (travel != list)
	{
		printf("<-[RollNumber %d] [Attendance %d] [FirstName %s] [LastName %s]->\n",
			travel->Employee->RollNumber,
			travel->Employee->Attendance,
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

	printf("\t[%d] [%d] [%s] [%s]\n", data->RollNumber, data->Attendance, data->FirstName, data->LastName);

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
	NodeType** deleteNode = (NodeType**)malloc(sizeof(NodeType*));
	dataType status = SearchCrieria(list, deleteNode);

	if (status == SUCCESS)
	{
		employee->Attendance = (*deleteNode)->Employee->Attendance;
		employee->RollNumber = (*deleteNode)->Employee->RollNumber;
		employee->FirstName = (*deleteNode)->Employee->FirstName;
		employee->LastName = (*deleteNode)->Employee->LastName;
	}
	else
	{
		printf("something went wrong...\n");
		return FALSE;

	}
	return SUCCESS;
}

statusType Dequeue(ListType* list, EmployeeType* employee)
{
	// last
	if (IsEmpty(list)) return StackIsEmpty;
	NodeType** deleteNode = (NodeType**)malloc(sizeof(NodeType*));
	dataType status = SearchCrieria(list, deleteNode);

	if (status == SUCCESS)
	{
		employee->Attendance = (*deleteNode)->Employee->Attendance;
		employee->RollNumber = (*deleteNode)->Employee->RollNumber;
		employee->FirstName = (*deleteNode)->Employee->FirstName;
		employee->LastName = (*deleteNode)->Employee->LastName;

		GenericDelete(*deleteNode);
	}
	else
	{
		printf("something went wrong...\n");
		return FALSE;
	}
	return SUCCESS;
}

statusType SearchCrieria(ListType* list, ListType** maxNode)
{
	if (IsEmpty(list)) return StackIsEmpty;

	dataType max = list->Next->Employee->Attendance;

	ListType* traverse = list->Next;

	while (traverse != list)
	{
		dataType val = traverse->Employee->Attendance;
		if (max <= val)  // for max use <= and for min use >=
		{
			max = val;
			*maxNode = traverse;
		}
		traverse = traverse->Next;
	}
	return SUCCESS;
}