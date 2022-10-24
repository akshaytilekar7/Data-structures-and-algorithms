namespace CSharp
{
    public class DynamicCollectionOfDisjointSets
    {
        public Set Set;
        public DynamicCollectionOfDisjointSets Prev;
        public DynamicCollectionOfDisjointSets Next;
    };

    public class Set
    {
        public List<int> NumberSets = new List<int>();
        public int TotalElements;
        public int RepresentativeElement; // primary key
    };
    public static class Constants
    {
        public static int Dcds_representative_exists = 2;
        public static int Representative_element_not_found = 3;
    }
}
