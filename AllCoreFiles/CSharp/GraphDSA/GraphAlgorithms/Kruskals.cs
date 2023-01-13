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
            DcdsService dcds = new DcdsService();

            // Graph Edges list
            List<Edge> graphEdges = BuildEdgesFromGraph();

            // Graph Edges order by non-decresing order 
            graphEdges = graphEdges.OrderBy(x => x.Weight).ToList();

            // make individual set of vertice N like {1}, {2}, {3},.., {N}
            for (var pv_run = graphManagement._graph.Root.Next; pv_run != graphManagement._graph.Root; pv_run = pv_run.Next)
                dcds.CreateSet(pv_run.Vertex);

            List<Edge> resultEdges = new List<Edge>();
            for (int i = 0; i < graphEdges.Count(); ++i)
            {
                // get FirstElementPk by individual vertex
                var set1 = dcds.GetSetBy(graphEdges[i].VertexStart);
                var set2 = dcds.GetSetBy(graphEdges[i].VertexEnd);

                if (set1 != set2)
                {
                    // if not equal - UNION them by setting FirstElementPk of set 1
                    dcds.UnionSet(set1.Pk, set2.Pk);
                    resultEdges.Add(graphEdges[i]);
                }
            }

            return resultEdges;
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

                        traverseLinkList.Color = VertexNodeInLinkListNode.Color = Color.BLACK;

                        var individualEdge = graphManagement.GetEdge(traverseVertex.Vertex, traverseLinkList.Vertex, traverseLinkList.Weight);
                        listEdges.Add(individualEdge);
                    }
                }
            }
            return listEdges;
        }
    }
}
