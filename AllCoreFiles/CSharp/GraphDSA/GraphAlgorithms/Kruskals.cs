using AllCoreFiles.CSharp.GraphDSA.GraphDcds;
using AllCoreFiles.CSharp.GraphDSA.GraphManagement;

namespace AllCoreFiles.CSharp.GraphDSA.GraphAlgorithms
{
    public class Kruskals
    {
        private readonly GraphService graphManagement;
        public Kruskals(GraphService graphManagement)
        {
            this.graphManagement = graphManagement;
        }
        public List<Edge> kruskal()
        {
            DcdsService dcdsService = new DcdsService();
            List<Edge> edges = new List<Edge>();

            // Graph Edges list
            var graphEdges = BuildEdgesFromGraph();

            // Graph Edges order by non-decresing order 
            graphEdges = graphEdges.OrderBy(x => x.Weight).ToList();

            // make individual set of vertice N like {1}, {2}, {3},.., {N}
            for (var pv_run = graphManagement._graph.Root.Next; pv_run != graphManagement._graph.Root; pv_run = pv_run.Next)
                dcdsService.MakeSet(pv_run.Vertex);

            for (int i = 0; i < graphEdges.Count(); ++i)
            {
                // get FirstElementPk by individual vertex
                var set1 = dcdsService.FindSetByElememt(graphEdges[i].VertexStart);
                var set2 = dcdsService.FindSetByElememt(graphEdges[i].VertexEnd);

                if (set1 != set2)
                {
                    // if not equal - UNION them by setting FirstElementPk of set 1
                    dcdsService.UnionSet(set1.FirstElementPk, set2.FirstElementPk);
                    edges.Add(graphEdges[i]);
                }
            }

            return edges;
        }
        List<Edge> BuildEdgesFromGraph()
        {
            var root = graphManagement._graph.Root;
            List<Edge> listEdges = new List<Edge>();

            for (var traverseVertex = root.Next; traverseVertex != root; traverseVertex = traverseVertex.Next)
            {
                for (var traverseLinkList = traverseVertex.LinkList.Next; traverseLinkList != traverseVertex.LinkList; traverseLinkList = traverseLinkList.Next)
                {
                    if (traverseLinkList.Color == Color.WHITE)
                    {
                        var vertexNode = graphManagement.SearchVertexNode(root, traverseLinkList.Vertex);
                        var VertexNodeInLinkListNode = graphManagement.SearchVertexLinkList(vertexNode.LinkList, traverseVertex.Vertex);
                        
                        traverseLinkList.Color = Color.BLACK;
                        VertexNodeInLinkListNode.Color = Color.BLACK;
                        
                        var individualEdge = graphManagement.GetEdge(traverseVertex.Vertex, traverseLinkList.Vertex, traverseLinkList.Weight);
                        listEdges.Add(individualEdge);
                    }
                }
            }
            return listEdges;
        }
    }
}
