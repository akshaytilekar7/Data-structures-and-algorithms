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
            DCDS p_dcds = dcdsService.CreateDcds();

            List<Edge> p_edge_A = new List<Edge>();

            var p_edge_vector = BuildEdges();
            p_edge_vector = Sort(p_edge_vector);

            for (var pv_run = graphManagement._graph.Root.Next; pv_run != graphManagement._graph.Root; pv_run = pv_run.Next)
                dcdsService.MakeSet(p_dcds, pv_run.Vertex);

            for (int i = 0; i < p_edge_vector.Count(); ++i)
            {
                var pu_set = dcdsService.FindSet(p_dcds, p_edge_vector[i].VertexStart);
                var pv_set = dcdsService.FindSet(p_dcds, p_edge_vector[i].VertexEnd);
                if (pu_set != pv_set && pv_set != null)
                {
                    if (pu_set != null)
                        dcdsService.UnionSet(p_dcds, pu_set.PrimaryKey, pv_set.PrimaryKey);
                    p_edge_A.Add(p_edge_vector[i]);
                }
            }

            dcdsService.DestroyDcds(p_dcds);
            return p_edge_A;
        }
        List<Edge> Sort(List<Edge> edges)
        {
            edges = edges.OrderBy(x => x.Weight).ToList();
            return edges;
        }
        List<Edge> BuildEdges()
        {
            List<Edge> listEdges = new List<Edge>();

            for (var pv_run = graphManagement._graph.Root.Next; pv_run != graphManagement._graph.Root; pv_run = pv_run.Next)
            {
                for (var ph_run = pv_run.LinkList.Next; ph_run != pv_run.LinkList; ph_run = ph_run.Next)
                {
                    if (ph_run.Color == Color.WHITE)
                    {
                        ph_run.Color = Color.BLACK;
                        var vertexNode = graphManagement.SearchVertexNode(graphManagement._graph.Root, ph_run.Vertex);
                        var ph_node = graphManagement.SearchVertexLinkList(vertexNode.LinkList, pv_run.Vertex);
                        ph_node.Color = Color.BLACK;
                        var p_new_edge = graphManagement.GetEdge(pv_run.Vertex, ph_run.Vertex, ph_run.Weight);
                        listEdges.Add(p_new_edge);
                    }
                }
            }
            return listEdges;
        }
    }
}
