﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Graph
{
    public class Test
    {
        public static void Main123(string[] args)
        {
            int i;

            int[] V = { 5, 1, 3, 2, 6, 7, 8, 4, 9, 10, 11, 12, 13, 14 };

            Edge[] E = { new Edge() { VertexStart = 5, VertexEnd=  1},
                         new Edge() { VertexStart = 5, VertexEnd=  3},
                         new Edge() { VertexStart = 5, VertexEnd=  2},

                        new Edge() { VertexStart = 3, VertexEnd=  6},

                        new Edge() { VertexStart = 6, VertexEnd=  7},

                        new Edge() { VertexStart = 7, VertexEnd=  8},
                        new Edge() { VertexStart = 7, VertexEnd=  4},
                        new Edge() { VertexStart = 7, VertexEnd=  9},

                        new Edge() { VertexStart = 10, VertexEnd=  11},
                        new Edge() { VertexStart = 10, VertexEnd=  12},

                        new Edge() { VertexStart = 11, VertexEnd=  13},
                        new Edge() { VertexStart = 12, VertexEnd=  14},

                        };

            GraphService graphService = new GraphService();
            Graph graph = graphService.CreateGraph();
            
            for (i = 0; i < V.Length; ++i)
                graphService.AddVertex(graph, V[i]);
            
            for (i = 0; i < E.Length; ++i)
                graphService.AddEdge(graph, E[i].VertexStart, E[i].VertexEnd);

            graphService.Print(graph, "Initial State:");
            
            graphService.DFSRecursive(graph);
            
            graphService.BFSUsingArray(graph);
            graphService.BFSUsingQueue(graph);

            Console.Write("\n************ C# END SUCCESS ************");
            Console.ReadLine();
        }
    }
}
