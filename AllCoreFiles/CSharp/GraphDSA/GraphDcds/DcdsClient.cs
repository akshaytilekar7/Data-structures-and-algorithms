namespace AllCoreFiles.CSharp.GraphDSA.GraphDcds
{
    internal class DcdsClient
    {
        public static void Main123()
        {
            Console.WriteLine("C##");

            DcdsService dcdsService = new DcdsService();

            dcdsService.MakeSet(10);
            dcdsService.ShowDcds("after make_set(10):");

            dcdsService.MakeSet(20);
            dcdsService.ShowDcds("after make_set(20):");

            dcdsService.MakeSet(30);
            dcdsService.ShowDcds("after make_set(30):");

            dcdsService.MakeSet(40);
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
