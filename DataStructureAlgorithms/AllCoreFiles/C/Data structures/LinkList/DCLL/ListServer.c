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
	node->Prev = NULL;
	return node;
}

ListType* CreateList()
{
	NodeType* node = GetNewNode(-1);
	node->Next = node->Prev = node;
	return node;
}

static void GenericInsert(NodeType* start, NodeType* midNode, NodeType* end)
{
	midNode->Next = end;
	midNode->Prev = start;
	start->Next = midNode;
	end->Prev = midNode;
}

static void GenericDelete(NodeType* deleteNode)
{
	deleteNode->Prev->Next = deleteNode->Next;
	deleteNode->Next->Prev = deleteNode->Prev;
	free(deleteNode);
	deleteNode = NULL;
}

static NodeType* Search(ListType* list, dataType data)
{
	ListType* traverse = list->Next;
	while (traverse != list->Prev)
	{
		if (traverse->Data == data) return traverse;
		traverse = traverse->Next;
	}
	return NULL;
}

statusType InsertAtStart(ListType* list, dataType data)
{
	NodeType* node = GetNewNode(data);
	GenericInsert(list, node, list->Next); // first and second
	return (SUCCESS);
}

statusType InsertAtEnd(ListType* list, dataType data)
{
	NodeType* node = GetNewNode(data);
	GenericInsert(list->Prev, node, list); // last and first 
	return (SUCCESS);
}

statusType InsertAfter(ListType* list, dataType data, dataType newData)
{
	NodeType* node = Search(list, data);
	if (node == NULL) return DataNotFound;

	GenericInsert(node, GetNewNode(newData), node->Next); // node and node cha next
	return SUCCESS;
}

statusType InsertBefore(ListType* list, dataType data, dataType newData)
{
	NodeType* node = Search(list, data);
	if (node == NULL) return DataNotFound;

	GenericInsert(node->Prev, GetNewNode(newData), node); // node cha prev and node
	return SUCCESS;
}

bool IsEmpty(ListType* list)
{
	if (list == NULL) return ListIsEmpty;
	return (list->Prev == list && list->Next == list);
}

bool IsExist(ListType* list, dataType data)
{
	NodeType* node = Search(list, data);
	return (node == NULL);
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
	return RecusiveGetLengthHelper(list->Next, list->Prev);
}

static dataType RecusiveGetLengthHelper(ListType* list, ListType* end)
{
	if (list == end)
		return 1;
	return 1 + RecusiveGetLengthHelper(list->Next, end);
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

statusType GetStart(ListType* list, dataType* pData)
{
	if (IsEmpty(list)) return ListIsEmpty;
	*pData = list->Next->Data;
	return SUCCESS;
}

statusType GetEnd(ListType* list, dataType* pData)
{
	if (IsEmpty(list)) return ListIsEmpty;
	*pData = list->Prev->Data;
	return SUCCESS;
}

statusType PopStart(ListType* list, dataType* pData)
{
	if (IsEmpty(list)) return ListIsEmpty;
	*pData = list->Next->Data;
	GenericDelete(list->Next);
	return SUCCESS;
}

statusType PopEnd(ListType* list, dataType* pData)
{
	if (IsEmpty(list)) return ListIsEmpty;
	*pData = list->Prev->Data;
	GenericDelete(list->Prev);
	return SUCCESS;
}

statusType RemoveFirst(ListType* list)
{
	if (IsEmpty(list)) return ListIsEmpty;
	GenericDelete(list->Next);
	return SUCCESS;
}

statusType RemoveEnd(ListType* list)
{
	if (IsEmpty(list)) return ListIsEmpty;
	GenericDelete(list->Prev);
	return SUCCESS;
}

statusType RemoveFirstOccurenceOfData(ListType* list, dataType data)
{
	if (IsEmpty(list)) return ListIsEmpty;
	ListType* travel = list->Next;
	while (travel != list)
	{
		if (travel->Data == data)
		{
			GenericDelete(travel);
			return SUCCESS;
		}
		travel = travel->Next;
	}
	return DataNotFound;
}

statusType RemoveLastOccurenceOfData(ListType* list, dataType data)
{
	ListType* travel = list->Prev;

	while (travel != list)
	{
		if (travel->Data == data)
		{
			GenericDelete(travel);
			return SUCCESS;
		}
		travel = travel->Prev;
	}
}

statusType RemoveAllOccurenceOfData(ListType* list, dataType data)
{
	if (IsEmpty(list)) return ListIsEmpty;
	ListType* travel = list->Next;
	bool isFound = 0;
	while (travel != list)
	{
		ListType* temp = travel->Next;
		if (travel->Data == data)
		{
			isFound = 1;
			GenericDelete(travel);
			travel = temp;
		}
		else
			travel = travel->Next;
	}
	return isFound == 1 ? SUCCESS : DataNotFound;
}

ListType* ConcatImmutable(ListType* list1, ListType* list2)
{
	if (IsEmpty(list1)) return list1 = list2;
	if (IsEmpty(list2)) return list1;

	ListType* result = CreateList();

	ListType* travel1 = list1->Next;
	while (travel1 != list1)
	{
		InsertAtEnd(result, travel1->Data);
		travel1 = travel1->Next;
	}

	ListType* travel2 = list2->Next;
	while (travel2 != list2)
	{
		InsertAtEnd(result, travel2->Data);
		travel2 = travel2->Next;
	}

	return result;
}

statusType ConcatMutable(ListType* list1, ListType* list2)
{
	if (IsEmpty(list1)) list1 = list2;
	if (IsEmpty(list2)) return SUCCESS;

	list1->Prev->Next = list2->Next; // list 1 cha last cha next => list 2 cha first
	list2->Prev->Next = list1; // list 2 cha last cha next => list1 (-1 Node)
	list2->Next->Prev = list1->Prev; // list 2 cha first cha prev => list1 cha last
	list1->Prev = list2->Prev; // list 1 cha prev => list 2 cha prev
	free(list2);
	list2 = NULL;
	return SUCCESS;
}

ListType* ReverseListImmutable(ListType* list)
{
	ListType* travel = list->Prev;
	ListType* result = CreateList();

	while (travel != list)
	{
		InsertAtEnd(result, travel->Data);
		travel = travel->Prev;
	}

	return result;
}

statusType ReverseListMutableBySwap(ListType* list)
{
	if (IsEmpty(list)) return ListIsEmpty;

	ListType* start = list->Next;
	ListType* end = list->Prev;
	ListType* fast = list->Next;

	while (fast != list && fast->Next != list)
	{
		int data = start->Data;
		start->Data = end->Data;
		end->Data = data;
		start = start->Next;
		end = end->Prev;
		fast = fast->Next->Next;
	}

	return SUCCESS;
}

statusType ReverseListByNode(ListType* list)
{

}