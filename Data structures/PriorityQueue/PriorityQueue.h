
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

struct Employee
{
	dataType RollNumber;
	char* FirstName;
	char* LastName;
};

struct Node {
	struct Employee* Employee;
	struct Node* Next;
	struct Node* Prev;
};

typedef struct Employee EmployeeType;
typedef struct Node NodeType;
typedef NodeType ListType;

ListType* CreateList();

statusType Enqueue(ListType* list, EmployeeType* employee);
statusType Peek(ListType* list, EmployeeType* employee);
statusType Dequeue(ListType* list, EmployeeType *employee);

bool IsEmpty(ListType* list);
dataType GetLength(ListType* list);
void PrintList(ListType* list, char* msg);
void PrintEmployee(char *msg, EmployeeType* data);

/* Auxilory functions*/
static void GenericInsert(NodeType* prev, NodeType* mid, NodeType* next);
static void GenericDelete(NodeType* deleteNode);
static NodeType* GetNewNode(EmployeeType* employee);

#endif 













