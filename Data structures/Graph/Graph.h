#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>
#include <stdbool.h>

struct Graph
{
	int TotalVertex;
	int TotalEdges;
	struct HeadNode* HeadNode;
};

struct Node
{
	int Vertex;
	struct Node* Prev;
	struct Node* Next;
};

struct HeadNode
{
	int Vertex;
	struct HeadNode* Prev;
	struct HeadNode* Next;
	struct Node* LinkList;
};

struct Graph* CreateGraph();
struct HeadNode* CreateHeadNode();
struct Node* CreateNode();

