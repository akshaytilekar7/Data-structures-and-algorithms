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

	status = RemoveEdge(graph, 1, 6);
	assert(status == SUCCESS);
	status = RemoveEdge(graph, 5, 3);
	assert(status == SUCCESS);

	Print(graph, "graph after removing edges, (1, 6), (5, 3)");

	status = RemoveVertex(graph, 2);
	assert(status == SUCCESS);
	Print(graph, "graph after removing vertex 2");

	status = AddVertex(graph, 7);
	assert(status == SUCCESS);

	status = AddEdge(graph, 1, 7);
	assert(status == SUCCESS);

	status = AddEdge(graph, 1, 4);
	assert(status == SUCCESS);

	status = AddEdge(graph, 3, 7);
	assert(status == SUCCESS);

	status = AddEdge(graph, 5, 7);
	assert(status == SUCCESS);

	Print(graph, "graph after adding vertex 7 and adding edges (1, 7), (1, 4), (3, 7), (5, 7):");

	//PrintDFS(graph);

	puts("\n************ END SUCCESS ************");

	return (EXIT_SUCCESS);
}