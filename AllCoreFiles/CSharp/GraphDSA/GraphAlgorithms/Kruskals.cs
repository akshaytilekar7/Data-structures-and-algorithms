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

            var graphEdges = BuildEdgesFromGraph();

            graphEdges = graphEdges.OrderBy(x => x.Weight).ToList();

            for (var pv_run = graphManagement._graph.Root.Next; pv_run != graphManagement._graph.Root; pv_run = pv_run.Next)
                dcdsService.MakeSet(pv_run.Vertex);

            for (int i = 0; i < graphEdges.Count(); ++i)
            {
                var set1 = dcdsService.FindSet(graphEdges[i].VertexStart);
                var set2 = dcdsService.FindSet(graphEdges[i].VertexEnd);
                if (set1 != set2)
                {
                    dcdsService.UnionSet(set1.FirstElementPk, set2.FirstElementPk);
                    edges.Add(graphEdges[i]);
                }
            }

            return edges;
        }
        List<Edge> BuildEdgesFromGraph()
        {
            List<Edge> listEdges = new List<Edge>();

            for (var traverse = graphManagement._graph.Root.Next; traverse != graphManagement._graph.Root; traverse = traverse.Next)
            {
                for (var traverseInner = traverse.LinkList.Next; traverseInner != traverse.LinkList; traverseInner = traverseInner.Next)
                {
                    if (traverseInner.Color == Color.WHITE)
                    {
                        traverseInner.Color = Color.BLACK;
                        var vertexNode = graphManagement.SearchVertexNode(graphManagement._graph.Root, traverseInner.Vertex);
                        var linkListNode = graphManagement.SearchVertexLinkList(vertexNode.LinkList, traverse.Vertex);
                        linkListNode.Color = Color.BLACK;
                        var newEdge = graphManagement.GetEdge(traverse.Vertex, traverseInner.Vertex, traverseInner.Weight);
                        listEdges.Add(newEdge);
                    }
                }
            }
            return listEdges;
        }
    }
}
