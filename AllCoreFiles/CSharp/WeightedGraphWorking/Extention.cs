/*

    Dijkstras algorithm 
        is used only to find shortest path.

    Minimum Spanning tree (Prim's or Kruskal's algorithm) 
        get minimum egdes with minimum edge value.

    Prim [ w(u,v) ] and Dijkstra [ w(u,v) + u.key ] 
        algorithms are almost the same, except for the "relax function".

    GMST and MSTPrim
        MSTPrim ha GMST ahe
 
*/
namespace GraphAlgo
{
    public static class Extention
    {
        public static VerticleVertexNode PopMin(this List<VerticleVertexNode> priorityQueue)
        {
            var min = priorityQueue.OrderBy(p => p.Distance).First();
            priorityQueue.Remove(min);
            return min;
        }
    }
}