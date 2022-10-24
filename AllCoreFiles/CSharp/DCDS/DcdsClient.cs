namespace CSharp
{
    internal class DcdsClient
    {
        public static void Main()
        {
            Console.WriteLine("C##");

            DcdsService dcdsService = new DcdsService();
            DCDS dcds = dcdsService.CreateDcds();

            dcdsService.MakeSet(dcds, 10);
            dcdsService.ShowDcds(dcds, "after make_set(10):");

            dcdsService.MakeSet(dcds, 20);
            dcdsService.ShowDcds(dcds, "after make_set(20):");

            dcdsService.MakeSet(dcds, 30);
            dcdsService.ShowDcds(dcds, "after make_set(30):");

            dcdsService.MakeSet(dcds, 40);
            dcdsService.ShowDcds(dcds, "after make_set(40):");

            dcdsService.UnionSet(dcds, 10, 20);
            dcdsService.ShowDcds(dcds, "after union_set(10, 20):");

            dcdsService.UnionSet(dcds, 30, 40);
            dcdsService.ShowDcds(dcds, "after union_set(30, 40):");

            dcdsService.UnionSet(dcds, 30, 10);
            dcdsService.ShowDcds(dcds, "after union_set(30, 10):");
        }
    }
}
