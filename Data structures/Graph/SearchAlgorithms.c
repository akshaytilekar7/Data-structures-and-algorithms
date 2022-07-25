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

void PrintDFS(struct Graph* graph)
{
	ResetColor(graph);

	struct VertexNode* traverse = graph->VertexNode->Next;
	while (traverse != graph->VertexNode)
	{
		int connectedComponentCount = 0;
		if (traverse->Color == WHITE)
		{
			printf("connected component: %d\n", ++connectedComponentCount);
			printf("[START]-> ");
			DFS(graph, traverse);
			printf(" <-[END]\n");
		}
		traverse = traverse->Next;
	}
}

void DFS(struct Graph* graph, struct VertexNode* vertexNode)
{
	vertexNode->Color = GRAY;
	printf("%d ", vertexNode->Vertex);

	struct LinkListNode* linkListNode = vertexNode->LinkList->Next;
	while (linkListNode != vertexNode->LinkList)
	{
		struct VertexNode* node = SearchVertex(graph->VertexNode, linkListNode->Vertex);
		if (node->Color == WHITE)
			DFS(graph, node);
		linkListNode = linkListNode->Next;
	}
	vertexNode->Color = BLACK;
}

void PrintBFS(struct Graph* graph)
{
	/*struct VertexNode** arr = (struct VertexNode**)calloc(graph->TotalVertex, sizeof(struct VertexNode*));


	printf("%d ", graph->VertexNode->Vertex);
	int i, j = 0;

	struct LinkListNode* traverse = graph->VertexNode->LinkList->Next;
	while (traverse != graph->VertexNode->LinkList)
	{
		arr[i++] = traverse;
		traverse = traverse->Next;
	}*/

}
