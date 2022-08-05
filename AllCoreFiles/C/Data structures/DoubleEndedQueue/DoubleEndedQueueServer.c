#include <stdio.h> 
#include <stdlib.h> 
#include "DoubleEndedQueue.h"
#define DummyValue -100
// not sure about working

/*
Deque or Double Ended Queue
	-	type of queue, no FIFO rule
	-	insertion and removal of elements can either be performed from the front or the rear
	-	insert/remove [node 1] <-> [node 2] <-> [node 3] <-> [node 4] insert/remove
	-	DLL not DCLL
*/

static NodeType* GetNewNode(dataType data)
{
	NodeType* node = (NodeType*)malloc(sizeof(NodeType));
	node->Data = data;
	node->Next = NULL;
	node->Prev = NULL;
	return node;
}

ListType* CreateList()
{
	ListType* list = (ListType*)malloc(sizeof(ListType));
	list = GetNewNode(-1);
	GenericInsert(list, GetNewNode(DummyValue), list->Next); // -1 -100 NULL => -1 -100 
	return list;
}

static void GenericInsert(NodeType* prev, NodeType* mid, NodeType* next)
{
	mid->Next = next;
	mid->Prev = prev;
	if (prev != NULL)
		prev->Next = mid;
	if (next != NULL)
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
	if (
		(list != NULL && list->Next != NULL && list->Next->Data == DummyValue)
		&&
		(list->Next->Data == DummyValue && list->Next->Next == NULL)
		)
		return TRUE;
	return FALSE;
}

//dataType GetLength(ListType* list)
//{
//	ListType* travel = list->Next;
//	int count = 0;
//	while (travel != list)
//	{
//		count++;
//		travel = travel->Next;
//	}
//	return count;
//}

void PrintList(ListType* list, char* msg)
{
	if (msg)
		printf("%s\n", msg);

	ListType* travel = list->Next;
	printf("[START]");
	while (travel != NULL)
	{
		printf("<-[%d]->", travel->Data);
		travel = travel->Next;
	}
	printf("[END]\n");
}

// START OF DLL
statusType PushFront(ListType* list, dataType newData)
{
	printf("PushFront 1\n");

	if (IsEmpty(list))
	{
		GenericInsert(list, GetNewNode(newData), list->Next);
	}
	else
	{
		// Insert at end
		NodeType** lastNode = NULL;
		GetLastForFront(list, lastNode);
		GenericInsert((*lastNode), GetNewNode(newData), (*lastNode)->Next);
	}return SUCCESS;
}

// START OF DLL
statusType PopFront(ListType* list, dataType newData)
{
	if (IsEmpty(list)) return StackIsEmpty;

	NodeType** lastNode = NULL;
	GetLastForFront(list, lastNode);

	// Remove last => before -100 node
	GenericDelete((*lastNode));
	return SUCCESS;
}

// END OF DLL
statusType PushRear(ListType* list, dataType newData)
{
	NodeType** lastNode = NULL;
	GetLastForRear(list, lastNode);

	// Insert after -100
	GenericInsert((*lastNode), GetNewNode(newData), (*lastNode)->Next);
	return SUCCESS;
}

// END OF DLL
statusType PopRear(ListType* list, dataType newData)
{
	if (IsEmpty(list)) return StackIsEmpty;

	NodeType** lastNode = NULL;
	GetLastForRear(list, lastNode);

	// Insert at end
	GenericDelete((*lastNode)->Next);
	return SUCCESS;
}

static void GetLastForFront(ListType* list, NodeType** last)
{
	printf("GetLastForFront 1\n");

	ListType* travel = list->Next;
	printf("GetLastForFront 2 %d\n", travel->Data);
	// IN progress - last is not valid
	while (travel->Next != NULL && travel->Next->Data != DummyValue)
	{
		printf("GetLastForFront 3\n");
		travel = travel->Next;
	}
	*last = travel;
	puts("asas");
	printf("-- %d\n", (*last)->Data);


}

static void GetLastForRear(ListType* list, NodeType** last)
{
	if (IsEmpty(list)) return;

	ListType* travel = list->Next;

	while (travel->Next != NULL) // return -100 node
		travel = travel->Next;

	*last = travel;
}
