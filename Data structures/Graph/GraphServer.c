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

	int status = InsertAtEndVertex(graph->HeadNode, vertex);
	assert(status == SUCCESS);
	graph->TotalVertex++;
	return SUCCESS;
}

int AddEdge(struct Graph* graph, int vertexStart, int vertexEnd)
{
	int status;

	struct HeadNode* vertexStartHead = SearchVertex(graph->HeadNode, vertexStart);
	if (vertexStartHead == NULL)
		return (InvalidVertex);

	struct HeadNode* vertexEndHead = SearchVertex(graph->HeadNode, vertexEnd);
	if (vertexEndHead == NULL)
		return (InvalidVertex);

	struct Node* edgeInStart = SearchNode(vertexStartHead->LinkList, vertexEnd);
	struct Node* edgeInEnd = SearchNode(vertexEndHead->LinkList, vertexStart);

	if (edgeInStart && edgeInEnd)
		return (EdgeAlreadyExists);

	if ((edgeInStart != NULL) ^ (edgeInEnd != NULL))
		return (G_CORRUPTED);

	status = InsertAtEndNode(vertexStartHead->LinkList, vertexEnd);
	assert(status == SUCCESS);
	
	status = InsertAtEndNode(vertexEndHead->LinkList, vertexStart);
	assert(status == SUCCESS);

	graph->TotalEdges++;

	return SUCCESS;
}

// TODO
int RemoveVertex(struct Graph* graph, int vertex)
{
	struct HeadNode* deleteheadNode = SearchVertex(graph->HeadNode, vertex);
	if (deleteheadNode == NULL)
		return (InvalidVertex);

	DestroyLinkList(graph, deleteheadNode->LinkList);
	GenericDeleteVertex(deleteheadNode);

	graph->TotalVertex--;
	return SUCCESS;
}

int DestroyLinkList(struct Graph* graph, struct Node* node)
{
	struct Node* traverse = node->Next;

	while (traverse != node)
	{
		struct Node* toBeDeleted = traverse;
		traverse = traverse->Next;
		free(toBeDeleted);
		graph->TotalEdges--;
	}
}

int RemoveEdge(struct Graph* graph, int vertexStart, int vertexEnd)
{
	if (!IsVertexExist(graph->HeadNode, vertexStart))
		return InvalidVertex;

	if (!IsVertexExist(graph->HeadNode, vertexEnd))
		return InvalidVertex;

	struct HeadNode* headStartNode = SearchVertex(graph->HeadNode, vertexStart);
	struct HeadNode* headEndNode = SearchVertex(graph->HeadNode, vertexEnd);

	if (!IsNodeExist(headStartNode->LinkList, vertexEnd))
		return InvalidEdge;

	if (!IsNodeExist(headEndNode->LinkList, vertexStart))
		return InvalidEdge;

	struct Node* nodeStart = SearchNode(headStartNode->LinkList, vertexEnd);
	GenericDeleteNode(nodeStart);
	graph->TotalEdges--;

	struct Node* nodeEnd = SearchNode(headEndNode->LinkList, vertexStart);
	GenericDeleteNode(nodeEnd);
	graph->TotalEdges--;

	return SUCCESS;
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
	while (travese != headNode)
	{
		printf(" [%d] -> ", travese->Vertex);
		PrintNode(travese->LinkList);
		travese = travese->Next;
	}
	printf("[END]\n");
}

void PrintNode(struct Node* node)
{
	struct Node* travese = node->Next;
	while (travese != node)
	{
		printf(" [%d] ", travese->Vertex);
		travese = travese->Next;
	}
	printf("\n");
}

#pragma endregion

#pragma region VertexMethods

bool IsVertexExist(struct HeadNode* headNode, int vertex)
{
	return SearchVertex(headNode, vertex) != NULL;
}

struct HeadNode* SearchVertex(struct HeadNode* headNode, int vertex)
{
	struct HeadNode* traverse = headNode->Next;

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

void GenericDeleteVertex(struct HeadNode* deletedNode)
{
	deletedNode->Prev->Next = deletedNode->Next;
	deletedNode->Next->Prev = deletedNode->Prev;
	free(deletedNode);
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
	return SearchNode(node, vertex) != NULL;
}

struct Node* SearchNode(struct Node* node, int vertex)
{
	struct Node* traverse = node->Next;

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

void GenericDeleteNode(struct Node* deletedNode)
{
	deletedNode->Prev->Next = deletedNode->Next;
	deletedNode->Next->Prev = deletedNode->Prev;
	free(deletedNode);
}

void InsertAtEndNode(struct Node* node, int vertex)
{
	struct Node* newNode = CreateNode();
	newNode->Vertex = vertex;
	GenericInsertNode(node->Prev, newNode, node);
}

#pragma endregion
