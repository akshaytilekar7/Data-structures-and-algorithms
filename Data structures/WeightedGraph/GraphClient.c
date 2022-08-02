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

	//int V[] = { 1,2,3,4 };
	//struct Edge E[] = { 
	//					{ 1, 2, 5},

	//					{ 2, 3, 5},
	//					{ 2, 4, 1},

	//					{ 3, 4, 1},
	//};

	int V[] = { 1,2,3,4,5 };
	struct Edge E[] = {
						{ 1, 2, 1},
						{ 1, 5, 3},


						{ 2, 1, 1},
						{ 2, 5, 4},
						{ 2, 3, 4},

						{ 3, 2, 4},
						{ 3, 5, 3},
						{ 3, 4, 2},

						{ 4, 3, 2},
						{ 4, 5, 1},

						{ 5, 1, 3},
						{ 5, 4, 1},

	};


	graph = CreateGraph();

	for (i = 0; i < sizeof(V) / sizeof(V[0]); ++i)
		assert(AddVertex(graph, V[i]) == SUCCESS);
	for (i = 0; i < sizeof(E) / sizeof(E[0]); ++i)
	{
		status = AddEdge(graph, E[i].VertexStart, E[i].VertexEnd, E[i].Weight);
		assert(status == SUCCESS || status == EdgeAlreadyExists);
	}
	Print(graph, "Initial State:");
	printf("TotalVertex: %d\n", graph->TotalVertex);
	printf("TotalEdges: %d\n", graph->TotalEdges);

	//DFSRecursive(graph);
	//BFSUsingArray(graph);

	DijkstraShortestPath(graph, 1);
	puts("\n************ END SUCCESS ************");

	return (EXIT_SUCCESS);
}