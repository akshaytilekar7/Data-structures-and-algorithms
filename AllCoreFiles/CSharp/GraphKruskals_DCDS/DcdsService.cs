namespace CSharp.DCDS
{
    public class DcdsService
    {
        SetService SetService = new SetService();

        public DCDS CreateDcds()
        {
            var dcds = GetDcdsNode(null);
            dcds.Prev = dcds;
            dcds.Next = dcds;
            return dcds;
        }

        public int MakeSet(DCDS dcds, int element)
        {
            for (var traverse = dcds.Next; traverse != dcds; traverse = traverse.Next)
            {
                int s = SetService.Search(traverse.Set, element);
                if (s == 1)
                    return Constants.Dcds_representative_exists;
            }

            Set set = SetService.CreateNewSet(element);
            GenericDcdsInsert(dcds.Prev, GetDcdsNode(set), dcds);
            return 1;
        }

        internal int UnionSet(DCDS dcds, int pk1, int pk2)
        {
            Set set1 = null;
            Set set2 = null;
            DCDS dcds2 = null;
            int i;
            int s;

            for (var traverse = dcds.Next; traverse != dcds; traverse = traverse.Next)
            {
                if (traverse.Set.PrimaryKey == pk1)
                    set1 = traverse.Set;
                if (traverse.Set.PrimaryKey == pk2)
                {
                    dcds2 = traverse;
                    set2 = traverse.Set;
                }
            }

            if (set1 == null || set2 == null)
                return Constants.Representative_element_not_found;

            for (i = 0; i < set2.Count; ++i)
                SetService.Add(set1, set2.listInt[i]);

            GenericDcdsDelete(dcds2);

            return 1;
        }

        public Set FindSet(DCDS dcds, int pk)
        {
            for (var traverse = dcds.Next; traverse != dcds; traverse = traverse.Next)
                if (traverse.Set.PrimaryKey == pk)
                    return traverse.Set;

            return null;
        }

        public void ShowDcds(DCDS dcds, string msg)
        {
            if (msg != null)
                Console.WriteLine(msg);

            for (var traverse = dcds.Next; traverse != dcds; traverse = traverse.Next)
            {
                Console.Write("[SET]\t->\t[" + traverse.Set.PrimaryKey + "]\t");
                int i;
                for (i = 0; i < traverse.Set.Count; ++i)
                    Console.Write("[" + traverse.Set.listInt[i] + "]");
                Console.WriteLine("[END]");
            }
        }

        public int DestroyDcds(DCDS dcds)
        {
            DCDS dcds1 = dcds;
            DCDS next;

            for (var traverse = dcds1.Next; traverse != dcds1; traverse = next)
            {
                next = traverse.Next;
                SetService.Destroy(traverse.Set);
            }
            return 1;
        }

        public void GenericDcdsInsert(DCDS start, DCDS mid, DCDS end)
        {
            mid.Next = end;
            mid.Prev = start;
            start.Next = mid;
            end.Prev = mid;
        }

        public void GenericDcdsDelete(DCDS deletedNode)
        {
            deletedNode.Prev.Next = deletedNode.Next;
            deletedNode.Next.Prev = deletedNode.Prev;
        }

        public DCDS GetDcdsNode(Set set)
        {
            var newNode = new DCDS()
            {
                Set = set,
            };
            return (newNode);
        }
    }
}
