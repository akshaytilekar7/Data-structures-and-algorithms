using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    public class DynamicCollectionOfDisjointSets
    {
        public Set set;
        public DynamicCollectionOfDisjointSets prev;
        public DynamicCollectionOfDisjointSets next;
    };

    public class Set
    {
        public int[] NumberSetArr;
        public int TotalElements;
        public int RepresentativeElement; // primary key
    };
    public static class Constants
    {
        public static int DCDS_REPRESENTATIVE_EXISTS = 2;
        public static int REPRESENTATIVE_ELEMENT_NOT_FOUND = 3;
    }
}
