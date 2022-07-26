#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>
#include <stdbool.h>

#define SUCCESS 1 
#define TRUE 1 
#define FALSE 0 

#define VertexAlreadyExist   2 
#define EdgeAlreadyExists   3 
#define InvalidVertex  4 
#define InvalidEdge  5
#define GraphIsCorrupted 6 

struct Graph
{
	int TotalVertex;
	int TotalEdges;
	struct VertexNode* VertexNode;
};

struct LinkListNode
{
	int Vertex;
	struct LinkListNode* Prev;
	struct LinkListNode* Next;
};

enum Color
{
	WHITE = 0,
	GRAY,
	BLACK
};

struct VertexNode
{
	int Vertex;
	struct VertexNode* Prev;
	struct VertexNode* Next;
	struct LinkListNode* LinkList;
	enum Color Color;
};

struct Edge
{
	int VertexStart;
	int VertexEnd;
};



struct Graph* CreateGraph();
struct VertexNode* CreateHeadNode();
struct LinkListNode* CreateNode();

int AddVertex(struct Graph* graph, int vertex);
int RemoveVertex(struct Graph* graph, int vertex);
int RemoveVertexOtherWay(struct Graph* graph, int vertex);

int AddEdge(struct Graph* graph, int vertexStart, int vertexEnd);
int RemoveEdge(struct Graph* graph, int vertexStart, int vertexEnd);

void GenericInsertVertex(struct VertexNode* prev, struct VertexNode* newNode, struct VertexNode* next);
void GenericInsertNode(struct LinkListNode* prev, struct LinkListNode* newNode, struct LinkListNode* next);

void GenericDeleteVertex(struct VertexNode* deletedNode);
void GenericDeleteNode(struct LinkListNode* deletedNode);

void InsertAtEndVertex(struct VertexNode* vertexNode, int vertex);
void InsertAtEndNode(struct LinkListNode* linkListNode, int vertex);

struct LinkListNode* SearchNode(struct LinkListNode* linkListNode, int vertex);
struct VertexNode* SearchVertex(struct VertexNode* vertexNode, int vertex);

bool IsNodeExist(struct LinkListNode* linkListNode, int vertex);
bool IsVertexExist(struct VertexNode* vertexNode, int vertex);

void Print(struct Graph* graph, const char* msg);
void PrintVertexNode(struct VertexNode* vertexNode);
void PrintLinkListNode(struct LinkListNode* linkListNode);

void ResetColor(struct Graph* graph);
void DFS(struct Graph* graph, struct VertexNode* vertexNode);
void PrintDFS(struct Graph* graph);

void PrintBFS(struct Graph* graph);
void BFSArray(struct Graph* graph, struct VertexNode* vertexNode);

bool IsExist(struct VertexNode** arr, int size, struct VertexNode* element);
