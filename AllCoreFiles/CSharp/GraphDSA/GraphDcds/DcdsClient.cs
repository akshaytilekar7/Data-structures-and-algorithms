namespace AllCoreFiles.CSharp.GraphDSA.GraphDcds
{
    internal class DcdsClient
    {
        public static void Main123()
        {
            Console.WriteLine("C##");

            DcdsService dcdsService = new DcdsService();

            dcdsService.CreateSet(10);
            dcdsService.ShowDcds("after make_set(10):");

            dcdsService.CreateSet(20);
            dcdsService.ShowDcds("after make_set(20):");

            dcdsService.CreateSet(30);
            dcdsService.ShowDcds("after make_set(30):");

            dcdsService.CreateSet(40);
            dcdsService.ShowDcds("after make_set(40):");

            dcdsService.UnionSet(10, 20);
            dcdsService.ShowDcds("after union_set(10, 20):");

            dcdsService.UnionSet(30, 40);
            dcdsService.ShowDcds("after union_set(30, 40):");

            dcdsService.UnionSet(30, 10);
            dcdsService.ShowDcds("after union_set(30, 10):");
        }
    }
}
