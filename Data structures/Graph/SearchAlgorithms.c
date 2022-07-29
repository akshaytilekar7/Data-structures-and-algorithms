#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>
#include <stdbool.h>
#include "Graph.h"

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

	while (index > 0 && arr[queueStartIndex] != NULL)
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
