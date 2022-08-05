#ifndef _LIST_H 
#define _LIST_H 

#include <stdio.h> 

#define SUCCESS	1
#define TRUE	1
#define FALSE	0

#define ListIsEmpty 2
#define DataNotFound 2

typedef int dataType;
typedef int statusType;
typedef int lenType;
typedef int bool;

struct Node {
	dataType Data;
	struct Node* Next;
	struct Node* Prev;
};

typedef struct Node NodeType;
typedef NodeType ListType;

ListType* CreateList();

statusType InsertAtStart(ListType* list, dataType data);
statusType InsertAtEnd(ListType* list, dataType data);
statusType InsertAfter(ListType* list, dataType data, dataType newData);
statusType InsertBefore(ListType* list, dataType data, dataType newData);

statusType GetStart(ListType* list, dataType* pData);
statusType GetEnd(ListType* list, dataType* pData);
statusType PopStart(ListType* list, dataType* pData);
statusType PopEnd(ListType* list, dataType* pData);

statusType RemoveFirst(ListType* list);
statusType RemoveEnd(ListType* list);
statusType RemoveFirstOccurenceOfData(ListType* list, dataType data);
statusType RemoveLastOccurenceOfData(ListType* list, dataType data);
statusType RemoveAllOccurenceOfData(ListType* list, dataType data);

bool IsEmpty(ListType* list);
bool IsExist(ListType* list, dataType data);
dataType GetLength(ListType* list);
dataType RecusiveGetLength(ListType* list);
static dataType RecusiveGetLengthHelper(ListType* list, ListType* end);
void PrintList(ListType* list, char* msg);

//statusType Destroy(ListType** list);
ListType* ConcatImmutable(ListType* list1, ListType* list2);
statusType ConcatMutable(ListType* list1, ListType* list2);
ListType* ReverseListImmutable(ListType* list);
statusType ReverseListMutableBySwap(ListType* list);
statusType ReverseListByNode(ListType* list);


/* Auxilory functions*/
static void GenericInsert(NodeType* start, NodeType* midNode, NodeType* end);
static void GenericDelete(NodeType* deleteNode);
static NodeType* Search(ListType* list, dataType data);
static NodeType* GetNewNode(dataType data);

static void* xcalloc(size_t noOfElements, size_t sizePerElemet);

#endif 













