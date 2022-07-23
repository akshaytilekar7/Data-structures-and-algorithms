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
#define Corrupted 6 

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

int AddVertex(struct Graph* graph, int vertex);
int AddEdge(struct Graph* graph, int vertexStart, int vertexEnd);
int RemoveVertex(struct Graph* graph, int vertex);
int RemoveEdge(struct Graph* graph, int vertexStart, int vertexEnd);
void Print(struct Graph* graph, const char* msg);

void GenericInsertVertex(struct HeadNode* prev, struct HeadNode* newNode, struct HeadNode* next);
void GenericInsertNode(struct Node* prev, struct Node* newNode, struct Node* next);

void InsertAtEndVertex(struct HeadNode* headNode, int vertex);
void InsertAtEndNode(struct Node* node, int vertex);

struct Node* SearchNode(struct Node* node, int vertex);
struct HeadNode* SearchVertex(struct HeadNode* headNode, int vertex);

bool IsNodeExist(struct Node* node, int vertex);
bool IsVertexExist(struct HeadNode* headNode, int vertex);

void PrintHeadNode(struct HeadNode* headNode);
void PrintNode(struct Node* node);
