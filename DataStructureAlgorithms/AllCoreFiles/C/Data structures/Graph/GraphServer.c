#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>
#include <stdbool.h>
#include "Graph.h"

struct Graph* CreateGraph()
{
	struct Graph* graph = (struct Graph*)malloc(sizeof(struct Graph));
	graph->VertexNode = CreateHeadNode();
	graph->TotalEdges = 0;
	graph->TotalVertex = 0;
	return graph;
}

struct VertexNode* CreateHeadNode()
{
	struct VertexNode* vertexNode = (struct VertexNode*)malloc(sizeof(struct VertexNode));
	vertexNode->LinkList = CreateNode();
	vertexNode->Next = vertexNode;
	vertexNode->Prev = vertexNode;
	vertexNode->Vertex = 0;
	vertexNode->Color = WHITE;
	return vertexNode;
}

struct LinkListNode* CreateNode()
{
	struct LinkListNode* linkListNode = (struct LinkListNode*)malloc(sizeof(struct LinkListNode));
	linkListNode->Next = linkListNode;
	linkListNode->Prev = linkListNode;
	linkListNode->Vertex = 0;
	return linkListNode;
}

#pragma region GraphMethods

int AddVertex(struct Graph* graph, int vertex)
{
	if (IsVertexExist(graph->VertexNode, vertex))
		return VertexAlreadyExist;

	InsertAtEndVertex(graph->VertexNode, vertex);
	graph->TotalVertex++;
	return SUCCESS;
}

int AddEdge(struct Graph* graph, int vertexStart, int vertexEnd)
{
	struct VertexNode* vertexStartHead = SearchVertex(graph->VertexNode, vertexStart);
	if (vertexStartHead == NULL)
		return (InvalidVertex);

	struct VertexNode* vertexEndHead = SearchVertex(graph->VertexNode, vertexEnd);
	if (vertexEndHead == NULL)
		return (InvalidVertex);

	struct LinkListNode* edgeInStart = SearchNode(vertexStartHead->LinkList, vertexEnd);
	struct LinkListNode* edgeInEnd = SearchNode(vertexEndHead->LinkList, vertexStart);

	if (edgeInStart && edgeInEnd)
		return (EdgeAlreadyExists);

	if ((edgeInStart != NULL) ^ (edgeInEnd != NULL))
		return (GraphIsCorrupted);

	InsertAtEndNode(vertexStartHead->LinkList, vertexEnd);
	InsertAtEndNode(vertexEndHead->LinkList, vertexStart);

	graph->TotalEdges++;

	return SUCCESS;
}

int RemoveVertexOtherWay(struct Graph* graph, int vertex)
{
	struct VertexNode* deletedHeadNode = SearchVertex(graph->VertexNode, vertex);
	if (deletedHeadNode == NULL)
		return (InvalidVertex);

	struct LinkListNode* traverse = deletedHeadNode->LinkList->Next;
	while (traverse != deletedHeadNode->LinkList)
	{
		struct LinkListNode* traverseNext = traverse->Next;
		RemoveEdge(graph, traverse->Vertex, vertex);
		traverse = traverseNext;
	}

	GenericDeleteVertex(deletedHeadNode);
	graph->TotalVertex--;
	return SUCCESS;
}

int RemoveVertex(struct Graph* graph, int vertex)
{
	struct LinkListNode* traverseNext = NULL, * edge = NULL, * traverse = NULL;
	struct VertexNode* adjecencyVertex = NULL, * deletedHeadNode = NULL;

	deletedHeadNode = SearchVertex(graph->VertexNode, vertex);
	if (deletedHeadNode == NULL)
		return (InvalidVertex);

	traverse = deletedHeadNode->LinkList->Next;
	while (traverse != deletedHeadNode->LinkList)
	{
		traverseNext = traverse->Next;
		adjecencyVertex = SearchVertex(graph->VertexNode, traverse->Vertex);
		edge = SearchNode(adjecencyVertex->LinkList, vertex);
		if (edge == NULL)
			return (GraphIsCorrupted);
		GenericDeleteNode(edge);
		free(traverse);
		graph->TotalEdges--;
		traverse = traverseNext;
	}

	GenericDeleteVertex(deletedHeadNode);
	graph->TotalVertex--;
	return SUCCESS;

}

int RemoveEdge(struct Graph* graph, int vertexStart, int vertexEnd)
{
	struct VertexNode* vertexStartHead = SearchVertex(graph->VertexNode, vertexStart);
	if (vertexStartHead == NULL)
		return (InvalidVertex);

	struct VertexNode* vertexEndHead = SearchVertex(graph->VertexNode, vertexEnd);
	if (vertexEndHead == NULL)
		return (InvalidVertex);

	struct LinkListNode* edgeInStart = SearchNode(vertexStartHead->LinkList, vertexEnd);
	struct LinkListNode* edgeInEnd = SearchNode(vertexEndHead->LinkList, vertexStart);

	if (edgeInStart == NULL && edgeInEnd == NULL)
		return (InvalidEdge);

	if ((edgeInStart != NULL) ^ (edgeInEnd != NULL))
		return (GraphIsCorrupted);

	GenericDeleteNode(edgeInStart);
	GenericDeleteNode(edgeInEnd);
	graph->TotalEdges--;

	return SUCCESS;
}

void Print(struct Graph* graph, const char* msg)
{
	printf("%s\n", msg);
	PrintVertexNode(graph->VertexNode);
}

void PrintVertexNode(struct VertexNode* vertexNode)
{
	printf("[START] \n");
	struct VertexNode* travese = vertexNode->Next;
	while (travese != vertexNode)
	{
		printf(" [%d] -> ", travese->Vertex);
		PrintLinkListNode(travese->LinkList);
		travese = travese->Next;
	}
	printf("[END]\n");
}

void PrintLinkListNode(struct LinkListNode* linkListNode)
{
	struct LinkListNode* travese = linkListNode->Next;
	while (travese != linkListNode)
	{
		printf(" [%d] ", travese->Vertex);
		travese = travese->Next;
	}
	printf("\n");
}

#pragma endregion

#pragma region VertexMethods

bool IsVertexExist(struct VertexNode* vertexNode, int vertex)
{
	return SearchVertex(vertexNode, vertex) != NULL;
}

struct VertexNode* SearchVertex(struct VertexNode* vertexNode, int vertex)
{
	struct VertexNode* traverse = vertexNode->Next;

	while (traverse != vertexNode)
	{
		if (traverse->Vertex == vertex)
			return traverse;

		traverse = traverse->Next;
	}
	return NULL;
}

void GenericInsertVertex(struct VertexNode* prev, struct VertexNode* newNode, struct VertexNode* next)
{
	newNode->Next = next;
	newNode->Prev = prev;
	prev->Next = newNode;
	next->Prev = newNode;
}

void GenericDeleteVertex(struct VertexNode* deletedNode)
{
	deletedNode->Prev->Next = deletedNode->Next;
	deletedNode->Next->Prev = deletedNode->Prev;
	free(deletedNode);
}

void InsertAtEndVertex(struct VertexNode* vertexNode, int vertex)
{
	struct VertexNode* newNode = CreateHeadNode();
	newNode->Vertex = vertex;
	GenericInsertVertex(vertexNode->Prev, newNode, vertexNode);
}

#pragma endregion 

#pragma region NodeMethods

bool IsNodeExist(struct LinkListNode* linkListNode, int vertex)
{
	return SearchNode(linkListNode, vertex) != NULL;
}

struct LinkListNode* SearchNode(struct LinkListNode* linkListNode, int vertex)
{
	struct LinkListNode* traverse = linkListNode->Next;

	while (traverse != linkListNode)
	{
		if (traverse->Vertex == vertex)
			return traverse;

		traverse = traverse->Next;
	}
	return NULL;
}

void GenericInsertNode(struct LinkListNode* prev, struct LinkListNode* newNode, struct LinkListNode* next)
{
	newNode->Next = next;
	newNode->Prev = prev;
	prev->Next = newNode;
	next->Prev = newNode;
}

void GenericDeleteNode(struct LinkListNode* deletedNode)
{
	deletedNode->Prev->Next = deletedNode->Next;
	deletedNode->Next->Prev = deletedNode->Prev;
	free(deletedNode);
}

void InsertAtEndNode(struct LinkListNode* linkListNode, int vertex)
{
	struct LinkListNode* newNode = CreateNode();
	newNode->Vertex = vertex;
	GenericInsertNode(linkListNode->Prev, newNode, linkListNode);
}

#pragma endregion
