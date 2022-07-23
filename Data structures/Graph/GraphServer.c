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
	headNode->Next = NULL;
	headNode->Prev = NULL;
	headNode->Vertex = 0;
	return headNode;
}

struct Node* CreateNode()
{
	struct Node* node = (struct Node*)malloc(sizeof(struct Node));
	node->Next = NULL;
	node->Prev = NULL;
	node->Vertex = 0;
	return node;
}



