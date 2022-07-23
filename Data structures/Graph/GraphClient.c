#include <stdio.h> 
#include <stdlib.h>
#include <assert.h>
#include <stdbool.h>
#include "Graph.h"

int main()
{
	int i;
	int status;
	struct Graph* graph = NULL;

	int V[] = { 1, 2, 3, 4, 5, 6 };
	struct Edge E[] = { {1, 2}, {1, 6},
						{2, 6}, {2, 5}, {2, 3},
						{3, 5}, {3, 4},
						{4, 5},
						{5, 6}
	};


	graph = CreateGraph();

	for (i = 0; i < sizeof(V) / sizeof(V[0]); ++i)
		assert(AddVertex(graph, V[i]) == SUCCESS);

	for (i = 0; i < sizeof(E) / sizeof(E[0]); ++i)
		assert(AddEdge(graph, E[i].VertexStart, E[i].VertexEnd) == SUCCESS);

	printf("Total Vertex : %d\n", graph->TotalVertex);
	printf("Total Edges : %d\n", graph->TotalEdges);

	Print(graph, "Initial State:");

	assert(RemoveEdge(graph, 3, 5) == SUCCESS); // start
	assert(RemoveEdge(graph, 2, 5) == SUCCESS); // middle
	assert(RemoveEdge(graph, 100, 5) == InvalidVertex);
	assert(RemoveEdge(graph, 2, 100) == InvalidEdge);
	assert(RemoveEdge(graph, 100, 100) == InvalidVertex);
	assert(RemoveVertex(graph, 5) == SUCCESS);

	Print(graph, "after removal of some vertex and edge:");
	printf("Total Vertex : %d\n", graph->TotalVertex);
	printf("Total Edges : %d\n", graph->TotalEdges);
	for (i = 0; i < sizeof(E) / sizeof(E[0]); ++i)
		RemoveEdge(graph, E[i].VertexStart, E[i].VertexEnd);

	Print(graph, "after removal of all edges:");
	printf("Total Vertex : %d\n", graph->TotalVertex);
	printf("Total Edges : %d\n", graph->TotalEdges);

	for (i = 0; i < sizeof(V) / sizeof(V[0]); ++i)
		RemoveVertex(graph, V[i]);

	Print(graph, "after removal of all vertex:");
	printf("Total Vertex : %d\n", graph->TotalVertex);
	printf("Total Edges : %d\n", graph->TotalEdges);

	puts("\nEND SUCCESS");

	return (EXIT_SUCCESS);
}