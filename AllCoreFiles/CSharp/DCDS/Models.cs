namespace CSharp
{
    public class DCDS
    {
        public Set Set;
        public DCDS Prev;
        public DCDS Next;
    };

    public class Set
    {
        public List<int> listInt = new List<int>();
        public int Count;
        public int PrimaryKey; // primary key
    };
    public static class Constants
    {
        public static int Dcds_representative_exists = 2;
        public static int Representative_element_not_found = 3;
    }
}
