#include <stdio.h> 
#include <stdlib.h> 
#include "Stack.h"

static NodeType* GetNewNode(dataType data)
{
	NodeType* node = (NodeType*)malloc(sizeof(NodeType));
	node->Data = data;
	node->Next = node;
	node->Prev = node;
	return node;
}

ListType* CreateList()
{
	ListType* list = (ListType*)malloc(sizeof(ListType));
	list = GetNewNode(-1);
	return list;
}

static void GenericInsert(NodeType* prev, NodeType* mid, NodeType* next)
{
	mid->Next = next;
	mid->Prev = prev;
	prev->Next = mid;
	next->Prev = mid;
}

static void GenericDelete(NodeType* prev)
{
	NodeType* deleteNode = prev->Next;
	prev->Next = prev->Next->Next;
	free(deleteNode);
	deleteNode = NULL;
}

statusType InsertAtEnd(ListType* list, dataType data)
{
	GenericInsert(list->Prev, GetNewNode(data), list);
	return SUCCESS;
}

statusType Peek(ListType* list, dataType* pData)
{
	if (IsEmpty(list)) return StackIsEmpty;
	*pData = list->Next->Data;
	return SUCCESS;
}

statusType Pop(ListType* list, dataType* pData)
{
	if (IsEmpty(list)) return StackIsEmpty;
	*pData = list->Next->Data;
	GenericDelete(list);
	return SUCCESS;
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
		printf("<-[%d]->", travel->Data);
		travel = travel->Next;
	}
	printf("[END]\n");
}