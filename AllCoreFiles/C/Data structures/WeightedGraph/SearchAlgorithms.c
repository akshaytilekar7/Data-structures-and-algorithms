#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>
#include <stdbool.h>
#include "Graph.h"

#define Infinity 5000;

void ResetColor(struct Graph* graph)
{
	struct VertexNode* traverse = graph->VertexNode->Next;
	while (traverse != graph->VertexNode)
	{
		traverse->Color = WHITE;
		traverse = traverse->Next;
	}
}

void DFSRecursive(struct Graph* graph)
{
	puts("\nDFS START");
	ResetColor(graph);

	struct VertexNode* traverse = graph->VertexNode->Next;
	while (traverse != graph->VertexNode)
	{
		int connectedComponentCount = 0;
		if (traverse->Color == WHITE)
		{
			printf("connected component: %d\n", ++connectedComponentCount);
			printf("[START]-> ");
			DFSRecursiveHelper(graph, traverse);
			printf(" <-[END]\n");
		}
		traverse = traverse->Next;
	}
	puts("DFS END");
}

static void DFSRecursiveHelper(struct Graph* graph, struct VertexNode* vertexNode)
{
	vertexNode->Color = GRAY;
	printf("%d ", vertexNode->Vertex);

	struct LinkListNode* linkListNode = vertexNode->LinkList->Next;
	while (linkListNode != vertexNode->LinkList)
	{
		struct VertexNode* node = SearchVertex(graph->VertexNode, linkListNode->Vertex);
		if (node->Color == WHITE)
			DFSRecursiveHelper(graph, node);
		linkListNode = linkListNode->Next;
	}
	vertexNode->Color = BLACK;
}

void BFSUsingArray(struct Graph* graph)
{
	puts("\nBFS START");
	ResetColor(graph);

	struct VertexNode* traverse = graph->VertexNode->Next;
	int connectedComponentCount = 0;
	while (traverse != graph->VertexNode)
	{
		if (traverse->Color == WHITE)
		{
			printf("connected component: %d\n", ++connectedComponentCount);
			printf("[START]-> ");
			BFSUsingArrayHelper(graph, traverse);
			printf(" <-[END]\n");
		}
		traverse = traverse->Next;
	}
	puts("BFS END");
}

static void BFSUsingArrayHelper(struct Graph* graph, struct VertexNode* vertexNode)
{
	int index = 0, queueStartIndex = 0;
	struct VertexNode** arr = (struct VertexNode**)calloc(graph->TotalVertex, sizeof(struct VertexNode*));
	vertexNode->Color = GRAY;
	arr[index++] = vertexNode;

	while (index > 0 && queueStartIndex < graph->TotalVertex && arr[queueStartIndex] != NULL)
	{
		struct VertexNode* node = arr[queueStartIndex];
		arr[queueStartIndex] = NULL;
		queueStartIndex++;
		node->Color = GRAY;
		printf("%d ", node->Vertex);
		struct LinkListNode* traverse = node->LinkList->Next;
		while (traverse != node->LinkList)
		{
			struct VertexNode* vv = SearchVertex(graph->VertexNode, traverse->Vertex);
			if (vv->Color == WHITE && !IsExist(arr, index, vv))
				arr[index++] = vv;
			traverse = traverse->Next;
		}
	}
}

static bool IsExist(struct VertexNode** arr, int size, struct VertexNode* element)
{
	for (int i = 0; i < size; i++)
	{
		if (arr[i] == element)
			return true;
	}
	return false;
}

void DijkstraShortestPath(struct Graph* graph, int src)
{
	// basic init
	struct Dijkstra** priorityQueue = (struct Dijkstra**)calloc(graph->TotalVertex, sizeof(struct Dijkstra*));
	struct VertexNode* travese = graph->VertexNode->Next;
	int index = 0;

	while (travese != graph->VertexNode)
	{
		struct Dijkstra* temp = (struct Dijkstra*)calloc(1, sizeof(struct Dijkstra));
		temp->Vertex = travese;
		temp->Distance = travese->Vertex == src ? 0 : Infinity;
		temp->Prev = NULL;
		temp->Visited = false;
		priorityQueue[index++] = temp;
		travese = travese->Next;
	}

	// priority queue as array
	while (!AllProcess(priorityQueue, graph->TotalVertex))
	{
		struct Dijkstra* ele = GetMin(priorityQueue, graph->TotalVertex);
		struct LinkListNode* travese = ele->Vertex->LinkList->Next;
		while (travese != ele->Vertex->LinkList)
		{
			struct Dijkstra* dest = FindVertex(priorityQueue, graph->TotalVertex, travese->Vertex);
			Relax(&ele, &dest, travese->Weight);
			travese = travese->Next;
		}
	}

	PrintDijkstra(priorityQueue, graph->TotalVertex);
}

static struct Dijkstra* FindVertex(struct Dijkstra** arr, int size, int vertex)
{
	for (int i = 0; i < size; i++)
	{
		if ((*arr[i]).Vertex->Vertex == vertex)
			return arr[i];
	}
	return NULL;
}

static void PrintDijkstra(struct Dijkstra** arr, int size)
{
	puts("Dijkstra Table");
	puts("vertex |  dist  |   prev");
	for (int i = 0; i < size; i++)
	{
		int d = arr[i]->Prev == NULL ? 0 : arr[i]->Prev->Vertex->Vertex;
		printf("%d      |   %d    |    %d\n", arr[i]->Vertex->Vertex, arr[i]->Distance, d);
	}
}

static void Relax(struct Dijkstra** src, struct Dijkstra** dest, int weight)
{
	if ((*dest)->Distance > ((*src)->Distance) + weight)
	{
		(*dest)->Distance = (*src)->Distance + weight;
		(*dest)->Prev = (*src);
	}
}

static struct Dijkstra* GetMin(struct Dijkstra** priorityQueue, int size)
{
	struct Dijkstra* min = (struct Dijkstra*)calloc(1, sizeof(struct Dijkstra));
	min->Distance = Infinity;
	for (int i = 0; i < size; i++)
	{
		if (priorityQueue[i] != NULL && !priorityQueue[i]->Visited
			&& priorityQueue[i]->Distance < min->Distance)
		{
			min = priorityQueue[i];
			priorityQueue[i]->Visited = true;
		}
	}
	return min;
}

static bool AllProcess(struct Dijkstra** priorityQueue, int size)
{
	for (int i = 0; i < size; i++)
	{
		if (priorityQueue[i]->Visited == false)
			return false;
	}
	return true;
}

