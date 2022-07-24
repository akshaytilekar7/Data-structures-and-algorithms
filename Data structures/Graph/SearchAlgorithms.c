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
	struct VertexNode* traverse = graph->VertexNode->Next;
	ResetColor(graph);
	int index = 0;
	while (traverse != graph->VertexNode)
	{
		if (traverse->Color == WHITE)
		{
			printf("\n\nconnected graph: %d\n", ++index);
			printf("[START]<->");
			DFS(graph, traverse);
			puts("[END]");
		}
		traverse = traverse->Next;
	}
}

void DFS(struct Graph* graph, struct VertexNode* vertexNode)
{
	printf("[%d]<->", vertexNode->Vertex);
	vertexNode->Color = GRAY;

	struct VertexNode* traverse = vertexNode->LinkList->Next;
	while (traverse != vertexNode->LinkList)
	{
		struct VertexNode* vetexNode = SearchVertex(graph->VertexNode, traverse->Vertex);
		if (vetexNode->Color == WHITE)
			DFS(graph, vetexNode);
		traverse = traverse->Next;
	}
	vertexNode->Color = BLACK;
}

