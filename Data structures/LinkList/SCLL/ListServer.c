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
	NodeType* node = GetNewNode(-1);
	node->Next = node;
	return node;
}

bool IsEmpty(ListType* list)
{
	return list->Next == list;
}

bool IsExist(ListType* list, dataType data)
{
	return (Search(list, data) == NULL) ? DataNotFound : SUCCESS;
}

static NodeType* Search(ListType* list, dataType data)
{
	ListType* travel = list->Next;

	while (list != travel)
	{
		if (travel->Data == data)
			return travel;
		travel = travel->Next;
	}
	return NULL;
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

dataType RecusiveGetLength(ListType* list)
{
	return RecusiveGetLengthHelper(list->Next, list);
}

static dataType RecusiveGetLengthHelper(ListType* list, ListType* end)
{
	if (list == end) return 0;

	return 1 + RecusiveGetLengthHelper(list->Next, end);
}

void PrintList(ListType* list, char* msg)
{
	if (msg)
		printf("%s", msg);

	ListType* travel = list->Next;
	printf("[START]->");
	while (travel != list)
	{
		printf("[%d]->", travel->Data);
		travel = travel->Next;
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
	while (travel != list)
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
	GenericDelete(list); // previous node
	return SUCCESS;
}

statusType PopEnd(ListType* list, dataType* pData)
{
	if (IsEmpty(list)) return ListIsEmpty;

	ListType* travel = list->Next;
	while (travel != list && travel->Next->Next != list)
		travel = travel->Next;
	// travel is pointing to one place prev to end 
	*pData = travel->Next->Data;
	GenericDelete(travel);
	return SUCCESS;
}

statusType RemoveFirst(ListType* list)
{
	if (IsEmpty(list)) return ListIsEmpty;
	GenericDelete(list);
	return SUCCESS;
}

statusType RemoveEnd(ListType* list)
{
	if (IsEmpty(list)) return ListIsEmpty;
	ListType* travel = list->Next;
	while (travel != list && travel->Next->Next != list)
		travel = travel->Next;
	// travel is pointing to one place prev to end 
	GenericDelete(travel);
	return SUCCESS;
}

statusType RemoveFirstOccurenceOfData(ListType* list, dataType data)
{
	if (IsEmpty(list)) return ListIsEmpty;

	ListType* prev = list;
	ListType* travel = list->Next;

	while (travel != list)
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
	if (IsEmpty(list)) return ListIsEmpty;

	ListType* prev = list;
	ListType* travel = list->Next;
	ListType* dataNode = NULL;

	while (travel != list)
	{
		if (travel->Data == data)
			dataNode = prev;

		prev = prev->Next;
		travel = travel->Next;
	}
	if (dataNode == NULL)
		return DataNotFound;
	GenericDelete(dataNode);
	return SUCCESS;
}

statusType RemoveAllOccurenceOfData(ListType* list, dataType data)
{
	if (IsEmpty(list)) return ListIsEmpty;

	ListType* prev = list;
	ListType* travel = list->Next;
	bool isFound = 0;
	while (travel != list)
	{
		if (travel->Data == data)
		{
			GenericDelete(prev);
			travel = prev->Next;
			isFound = 1;
		}
		prev = prev->Next;
		travel = travel->Next;
	}
	return isFound == 1 ? SUCCESS : DataNotFound;
}

statusType InsertAtStart(ListType* list, dataType data)
{
	GenericInsert(list, GetNewNode(data), list->Next);
	return SUCCESS;
}

statusType InsertAtEnd(ListType* list, dataType data)
{
	ListType* lastNode = list->Next;
	while (lastNode->Next != list)
		lastNode = lastNode->Next;
	GenericInsert(lastNode, GetNewNode(data), list);
	return SUCCESS;
}

statusType InsertAfter(ListType* list, dataType data, dataType newData)
{
	NodeType* node = Search(list, data);
	if (node == NULL) return DataNotFound;
	GenericInsert(node, GetNewNode(newData), node->Next);
	return SUCCESS;
}

statusType InsertBefore(ListType* list, dataType data, dataType newData)
{
	ListType* travel = list->Next;
	while (travel != list)
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

ListType* ConcatImmutable(ListType* list1, ListType* list2)
{
	ListType* result = CreateList();

	ListType* travel1 = list1->Next;
	while (travel1->Next != list1)
	{
		InsertAtEnd(result, travel1->Data);
		travel1 = travel1->Next;
	}

	ListType* travel2 = list2->Next;
	while (travel2->Next != list2)
	{
		InsertAtEnd(result, travel2->Data);
		travel2 = travel2->Next;
	}

	return result;
}

statusType ConcatMutable(ListType* list1, ListType* list2)
{
	if (IsEmpty(list2)) return SUCCESS;

	ListType* travel1 = list1->Next;
	while (travel1->Next != list1)
		travel1 = travel1->Next;

	travel1->Next = list2->Next;

	ListType* travel2 = list2->Next;
	while (travel2->Next != list2)
		travel2 = travel2->Next;

	travel2->Next = list1;
	list2 = NULL;
	return SUCCESS;
}

ListType* ReverseListImmutable(ListType* list)
{
	ListType* result = CreateList();
	GetReverseListHelper(list->Next, list, result);
	return result;
}

static void GetReverseListHelper(ListType* list, ListType* end, ListType* result)
{
	if (list == end)
		return;
	GetReverseListHelper(list->Next, end, result);
	InsertAtEnd(result, list->Data);
}

statusType ReverseListMutableIterative(ListType* list)
{
	ListType* prev = NULL;
	ListType* curr = list->Next;
	ListType* next = NULL;
	ListType* lastNodeAfterReverse = list->Next;

	while (curr != list)
	{
		next = curr->Next;

		curr->Next = prev;

		prev = curr;
		curr = next;
	}

	list->Next = prev;
	lastNodeAfterReverse->Next = list;
	return SUCCESS;
}
