
#ifndef _LIST_H 
#define _LIST_H 

#include <stdio.h> 

#define SUCCESS	1
#define TRUE	1
#define FALSE	0

#define StackIsEmpty 2
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
statusType InsertAtEnd(ListType* list, dataType data);

statusType Peek(ListType* list, dataType* pData);
statusType Pop(ListType* list, dataType* pData);

bool IsEmpty(ListType* list);
dataType GetLength(ListType* list);
void PrintList(ListType* list, char* msg);

/* Auxilory functions*/
static void GenericInsert(NodeType* prev, NodeType* mid, NodeType* next);
static void GenericDelete(NodeType* deleteNode);
static NodeType* GetNewNode(dataType data);

#endif 













