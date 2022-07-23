#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>
#include <stdbool.h>
#include "Graph.h"

struct Graph* CreateGraph()
{
	struct Graph* graph = (struct Graph*)malloc(sizeof(struct Graph));
	graph->HeadNode = (struct HeadNode*)malloc(sizeof(struct HeadNode));
	graph->TotalEdges = 0;
	graph->TotalVertex = 0;
	return graph;
}

struct HeadNode* CreateHeadNode()
{
	struct HeadNode* headNode = (struct HeadNode*)malloc(sizeof(struct HeadNode));
	headNode->LinkList = (struct Node*)malloc(sizeof(struct Node));
	headNode->Next = headNode;
	headNode->Prev = headNode;
	headNode->Vertex = 0;
	return headNode;
}

struct Node* CreateNode()
{
	struct Node* node = (struct Node*)malloc(sizeof(struct Node));
	node->Next = node;
	node->Prev = node;
	node->Vertex = 0;
	return node;
}

int AddVertex(struct Graph* graph, int vertex)
{
	if (IsVertexExist(graph->HeadNode, vertex))
		return VertexAlreadyExist;
	return 0;
}

int AddEdge(struct Graph* graph, int vertexStart, int vertexEnd)
{
}

int RemoveVertex(struct Graph* graph, int vertex)
{
}

int RemoveEdge(struct Graph* graph, int vertexStart, int vertexEnd)
{
}

void Print(struct Graph* graph, const char* msg)
{
}

bool IsVertexExist(struct HeadNode* headNode, int vertex)
{
	return SearchVertex(headNode, vertex);
}

struct HeadNode* SearchVertex(struct HeadNode* headNode, int vertex)
{
	struct HeadNode* traverse = headNode;

	while (traverse != headNode)
	{
		if (traverse->Vertex == vertex)
			return traverse;

		traverse = traverse->Next;
	}
	return NULL;
}

void GenericInsertVertex(struct HeadNode* prev, struct HeadNode* newNode, struct HeadNode* next)
{
	newNode->Next= next;
	newNode->Prev = prev;
	prev->Next = newNode;
	next->Prev= newNode;
}

void InsertAtEndVertex(struct HeadNode* headNode, int vertex)
{
	struct HeadNode* newNode = CreateHeadNode();
	newNode->Vertex = vertex;
	GenericInsertVertex(headNode->Prev, newNode, headNode);
}

bool IsNodeExist(struct Node* node, int vertex)
{
	return SearchNode(node, vertex) == NULL;
}

struct Node* SearchNode(struct Node* node, int vertex)
{
	struct Node* traverse = node;

	while (traverse != node)
	{
		if (traverse->Vertex == vertex)
			return traverse;

		traverse = traverse->Next;
	}
	return NULL;
}

void GenericInsertNode(struct Node* prev, struct Node* newNode, struct Node* next)
{
	newNode->Next = next;
	newNode->Prev = prev;
	prev->Next = newNode;
	next->Prev = newNode;
}

void InsertAtEnd(struct Node* node, int vertex)
{
	struct Node* newNode = CreateNode();
	newNode->Vertex = vertex;
	GenericInsertNode(node->Prev, newNode, node);
}