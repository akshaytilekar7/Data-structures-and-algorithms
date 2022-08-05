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

	int V[] = { 5, 1, 3, 2, 6, 7, 8, 4, 9, 10, 11, 12, 13, 14 };
	struct Edge E[] = { { 5, 1},
						 { 5, 3},
						 { 5, 2},

						 { 3, 6},

						{ 6, 7},

						{ 7, 8},
						{ 7, 4},
						{ 7, 9},

						{ 10, 11},
						{ 10, 12},

						{ 11, 13},
						{ 12, 14},

	};


	graph = CreateGraph();

	for (i = 0; i < sizeof(V) / sizeof(V[0]); ++i)
		assert(AddVertex(graph, V[i]) == SUCCESS);
	for (i = 0; i < sizeof(E) / sizeof(E[0]); ++i)
		assert(AddEdge(graph, E[i].VertexStart, E[i].VertexEnd) == SUCCESS);

	Print(graph, "Initial State:");
	printf("TotalVertex: %d\n", graph->TotalVertex);
	printf("TotalEdges: %d\n", graph->TotalEdges);

	/*status = RemoveEdge(graph, 1, 6);
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

	printf("TotalVertex: %d\n", graph->TotalVertex);
	printf("TotalEdges: %d\n", graph->TotalEdges);

	Print(graph, "graph after adding vertex 7 and adding edges (1, 7), (1, 4), (3, 7), (5, 7):");*/

	DFSRecursive(graph);

	BFSUsingArray(graph);

	puts("\n************ END SUCCESS ************");

	return (EXIT_SUCCESS);
}