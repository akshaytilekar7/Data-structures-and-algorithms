#include <stdio.h> 
#include <stdlib.h> 
#include "List.h"

static void* xcalloc(size_t nr_elements, size_t size_per_element)
{
	void* p = NULL;

	p = calloc(nr_elements, size_per_element);
	if (p == NULL)
	{
		fprintf(stderr, "calloc:fatal:out of virtual memory\n");
		exit(EXIT_FAILURE);
	}
	return (p);
}

static NodeType* GetNewNode(dataType data)
{
	NodeType* node = (NodeType*)xcalloc(1, sizeof(NodeType));
	node->Data = data;
	node->Next = NULL;
	return node;
}

ListType* CreateList()
{
	return GetNewNode(-1);
}

bool IsEmpty(ListType* list)
{
	return list->Next == NULL ? TRUE : FALSE;
}

bool IsExist(ListType* list, dataType data) {
	NodeType* result = Search(list, data);
	return result == NULL ? FALSE : TRUE;
}

static NodeType* Search(ListType* list, dataType data) {
	ListType* traverse = list->Next;
	while (traverse != NULL)
	{
		if (traverse->Data == data) return traverse;
		traverse = traverse->Next;
	}
	return NULL;
}

dataType GetLength(ListType* list)
{
	ListType* traverse = list->Next;
	int cnt = 0;
	while (traverse != NULL)
	{
		cnt++;
		traverse = traverse->Next;
	}
	return cnt;
}

dataType RecusiveGetLength(ListType* list)
{
	if (list->Next == NULL) return 0; // as we are starting from -1 node so minus that node
	return 1 + GetLength(list->Next);
}

void PrintList(ListType* list, char* msg)
{
	if (msg)
		printf("%s\n", msg);

	ListType* traverse = list->Next;
	printf("[START]->");
	while (traverse != NULL)
	{
		printf("[%d]->", traverse->Data);
		traverse = traverse->Next;
	}
	printf("[END]\n");
}

statusType GetStart(ListType* list, dataType* pData)
{
	if (IsEmpty(list)) return ListIsEmpty;

	*pData = list->Next->Data;
	return SUCCESS;
}

statusType GetEnd(ListType* list, dataType* pData)
{
	if (IsEmpty(list)) return ListIsEmpty;

	ListType* travel = list->Next;
	while (travel != NULL)
	{
		*pData = travel->Data;
		travel = travel->Next;
	}
	return SUCCESS;
}

static void GenericInsert(NodeType* prev, NodeType* midNode, NodeType* next)
{
	midNode->Next = next;
	prev->Next = midNode;
}

static void GenericDelete(NodeType* previousNode)
{
	NodeType* deleteNode = previousNode->Next;
	previousNode->Next = previousNode->Next->Next;
	free(deleteNode);
	deleteNode = NULL;
}

statusType PopStart(ListType* list, dataType* pData)
{
	if (IsEmpty(list)) return ListIsEmpty;

	*pData = list->Next->Data;
	GenericDelete(list);
	return SUCCESS;
}

statusType PopEnd(ListType* list, dataType* pData)
{
	if (IsEmpty(list)) return ListIsEmpty;
	ListType* traverse = list->Next;
	ListType* prev = list;

	while (traverse->Next != NULL)
	{
		*pData = traverse->Data;
		prev = prev->Next;
		traverse = traverse->Next;
	}

	GenericDelete(prev);
	return SUCCESS;
}

statusType RemoveFirst(ListType* list)
{
	if (IsEmpty(list)) return DataNotFound;
	GenericDelete(list);
	return SUCCESS;
}

statusType RemoveEnd(ListType* list)
{
	if (IsEmpty(list)) return DataNotFound;
	NodeType* travel = list->Next;
	NodeType* deleteNode = list;
	while (travel->Next != NULL)
	{
		deleteNode = deleteNode->Next;
		travel = travel->Next;
	}

	GenericDelete(deleteNode);
	return SUCCESS;
}

statusType RemoveFirstOccurenceOfData(ListType* list, dataType data)
{
	ListType* travel = list->Next;
	ListType* prev = list;
	while (travel != NULL)
	{
		if (travel->Data == data)
		{
			GenericDelete(prev);
			return SUCCESS;
		}
		prev = prev->Next;
		travel = travel->Next;
	}
	return DataNotFound;
}

statusType RemoveLastOccurenceOfData(ListType* list, dataType data)
{
	ListType* travel = list->Next;
	ListType* prev = list;
	ListType* deleteNode = NULL;
	while (travel != NULL)
	{
		if (travel->Data == data)
		{
			deleteNode = prev;
		}
		prev = prev->Next;
		travel = travel->Next;
	}
	if (deleteNode == NULL)
		return DataNotFound;

	GenericDelete(deleteNode);
	return SUCCESS;
}

statusType RemoveAllOccurenceOfData(ListType* list, dataType data)
{
	ListType* travel = list->Next;
	ListType* prev = list;
	bool isDeleted = 0;
	while (travel != NULL)
	{
		if (travel->Data == data)
		{
			GenericDelete(prev);
			travel = prev->Next;
			isDeleted = 1;
		}
		prev = prev->Next;
		travel = travel->Next;
	}
	return isDeleted == 1 ? SUCCESS : DataNotFound;
}

statusType InsertAtStart(ListType* list, dataType data)
{
	GenericInsert(list, GetNewNode(data), list->Next);
}

statusType InsertAtEnd(ListType* list, dataType data)
{
	ListType* travel = list->Next;
	ListType* lastNode = list;
	while (travel != NULL)
	{
		lastNode = lastNode->Next;
		travel = travel->Next;
	}
	GenericInsert(lastNode, GetNewNode(data), lastNode->Next);
	return SUCCESS;
}

statusType InsertAfter(ListType* list, dataType data, dataType newData)
{
	ListType* travel = list->Next;
	while (travel != NULL)
	{
		if (travel->Data == data)
		{
			GenericInsert(travel, GetNewNode(newData), travel->Next);
			return SUCCESS;
		}
		travel = travel->Next;
	}
	return DataNotFound;
}

statusType InsertBefore(ListType* list, dataType data, dataType newData)
{
	ListType* travel = list->Next;
	ListType* prev = list;

	while (travel != NULL)
	{
		if (travel->Data == data)
		{
			GenericInsert(prev, GetNewNode(newData), prev->Next);
			return SUCCESS;
		}
		prev = prev->Next;
		travel = travel->Next;
	}
	return DataNotFound;
}

ListType* ConcatImmutable(ListType* list1, ListType* list2)
{
	ListType* result = CreateList();

	ListType* lastNode1 = list1->Next;
	while (lastNode1 != NULL && lastNode1->Next != NULL)
	{
		InsertAtEnd(result, lastNode1->Data);
		lastNode1 = lastNode1->Next;
	}

	ListType* lastNode2 = list2->Next;
	while (lastNode2 != NULL && lastNode2->Next != NULL)
	{
		InsertAtEnd(result, lastNode2->Data);
		lastNode2 = lastNode2->Next;
	}

	return result;
}

statusType ConcatMutable(ListType* list1, ListType* list2)
{
	if (IsEmpty(list2)) return SUCCESS;

	ListType* lastNode1 = list1->Next;
	while (lastNode1 != NULL && lastNode1->Next != NULL)
		lastNode1 = lastNode1->Next;

	lastNode1->Next = list2->Next;
	list2 = NULL;

	return SUCCESS;
}

ListType* GetReverseList(ListType* list) {}
static void GetReverseListRecursiveRetrunNew(ListType* list, ListType* end, ListType* result) {}
statusType ReverseListBySwap(ListType* list) {}
statusType ReverseListByNode(ListType* list) {}