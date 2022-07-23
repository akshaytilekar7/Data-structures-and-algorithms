#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>
#include <stdbool.h>
#include "Graph.h"

struct Graph* CreateGraph()
{
	struct Graph* graph = (struct Graph*)malloc(sizeof(struct Graph));
	graph->HeadNode = CreateHeadNode();
	graph->TotalEdges = 0;
	graph->TotalVertex = 0;
	return graph;
}

struct HeadNode* CreateHeadNode()
{
	struct HeadNode* headNode = (struct HeadNode*)malloc(sizeof(struct HeadNode));
	headNode->LinkList = CreateNode();
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

#pragma region GraphMethods

int AddVertex(struct Graph* graph, int vertex)
{
	if (IsVertexExist(graph->HeadNode, vertex))
		return VertexAlreadyExist;

	InsertAtEndVertex(graph->HeadNode, vertex);
	return SUCCESS;
}

int AddEdge(struct Graph* graph, int vertexStart, int vertexEnd)
{
	if (!IsVertexExist(graph->HeadNode, vertexEnd))
		AddVertex(graph, vertexEnd);

	struct HeadNode* vertexHead = SearchVertex(graph->HeadNode, vertexEnd);

	if (IsNodeExist(vertexHead->LinkList, vertexEnd))
		return EdgeAlreadyExists;

	InsertAtEndNode(vertexHead->LinkList, vertexEnd);
	
	return SUCCESS;
}

int RemoveVertex(struct Graph* graph, int vertex)
{

}

int RemoveEdge(struct Graph* graph, int vertexStart, int vertexEnd)
{
}

void Print(struct Graph* graph, const char* msg)
{
	printf("%s\n", msg);
	PrintHeadNode(graph->HeadNode);
}

void PrintHeadNode(struct HeadNode* headNode)
{
	printf("[START] \n");
	struct HeadNode* travese = headNode->Next;
	while (travese != headNode->Next)
	{
		printf(" [%d] \n", headNode->Vertex);
		PrintNode(headNode->LinkList);
		travese = travese->Next;
	}
	printf("\n[END] ");
}

void PrintNode(struct Node* node)
{
	printf(" [START] ");
	struct Node* travese = node->Next;
	while (travese != node->Next)
	{
		printf(" [%d] ", node->Vertex);
		travese = travese->Next;
	}
	printf(" [END] ");
}

#pragma endregion

#pragma region VertexMethods

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
	newNode->Next = next;
	newNode->Prev = prev;
	prev->Next = newNode;
	next->Prev = newNode;
}

void GenericDeleteVertex(struct HeadNode* prev)
{
	struct HeadNode* toBeDeleted = prev->Next;
	prev->Next = toBeDeleted->Next;
	toBeDeleted->Next->Prev = prev;
	free(toBeDeleted);
}


void InsertAtEndVertex(struct HeadNode* headNode, int vertex)
{
	struct HeadNode* newNode = CreateHeadNode();
	newNode->Vertex = vertex;
	GenericInsertVertex(headNode->Prev, newNode, headNode);
}

#pragma endregion 

#pragma region NodeMethods

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

void GenericDeleteNode(struct Node* prev)
{
	struct Node* toBeDeleted = prev->Next;
	prev->Next = toBeDeleted->Next;
	toBeDeleted->Next->Prev = prev;
	free(toBeDeleted);
}

void InsertAtEndNode(struct Node* node, int vertex)
{
	struct Node* newNode = CreateNode();
	newNode->Vertex = vertex;
	GenericInsertNode(node->Prev, newNode, node);
}

#pragma endregion
