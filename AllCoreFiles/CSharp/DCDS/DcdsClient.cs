namespace CSharp
{
    internal class DcdsClient
    {
        public static void Main123()
        {
            DcdsService dcdsService = new DcdsService();

            DynamicCollectionOfDisjointSets p_dcds = dcdsService.create_dcds();
            int s = dcdsService.make_set(p_dcds, 10);
            dcdsService.show_dcds(p_dcds, "after make_set(10):");

            s = dcdsService.make_set(p_dcds, 20);
            dcdsService.show_dcds(p_dcds, "after make_set(20):");

            s = dcdsService.make_set(p_dcds, 30);
            dcdsService.show_dcds(p_dcds, "after make_set(30):");

            s = dcdsService.make_set(p_dcds, 40);
            dcdsService.show_dcds(p_dcds, "after make_set(40):");

            s = dcdsService.union_set(p_dcds, 10, 20);
            dcdsService.show_dcds(p_dcds, "after union_set(10, 20):");

            s = dcdsService.union_set(p_dcds, 30, 40);
            dcdsService.show_dcds(p_dcds, "after union_set(30, 40):");

            s = dcdsService.union_set(p_dcds, 30, 10);
            dcdsService.show_dcds(p_dcds, "after union_set(30, 10):");
        }
    }
}
