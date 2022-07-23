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
	
	Print(graph, "Initial State:");

	puts("end success");

	return (EXIT_SUCCESS);
}