namespace AllCoreFiles.CSharp.GraphDSA.GraphDcds
{
    public class DcdsService
    {
        List<Set> sets = new List<Set>();
        public int MakeSet(int element)
        {
            foreach (var item in sets)
            {
                if (item.listInt.Contains(element))
                    return Constants.Dcds_representative_exists;
            }

            Set set = new Set();
            set.listInt.Add(element);
            set.FirstElementPk = element;

            sets.Add(set);
            return 1;
        }

        internal int UnionSet(int pk1, int pk2)
        {
            Set set1 = null;
            Set set2 = null;

            foreach (var set in sets)
            {
                if (set.FirstElementPk == pk1)
                    set1 = set;
                if (set.FirstElementPk == pk2)
                    set2 = set;
            }

            sets.Remove(set1);
            sets.Remove(set2);

            var newSet = new Set();
            newSet.FirstElementPk = pk1;
            newSet.listInt.AddRange(set1.listInt);
            newSet.listInt.AddRange(set2.listInt);

            sets.Add(newSet);

            return 1;
        }

        public Set FindSetByElememt(int element)
        {
            foreach (var item in sets)
            {
                if (item.listInt.Contains(element))
                    return item;
            }
            return null;
        }

        public void ShowDcds(string msg)
        {
            if (msg != null)
                Console.WriteLine(msg);

            foreach (var item in sets)
            {
                Console.Write("[SET]\t->\t[" + item.FirstElementPk + "]\t");
                int i;
                for (i = 0; i < item.listInt.Count; ++i)
                    Console.Write("[" + item.listInt[i] + "]");
                Console.WriteLine("[END]");
            }
        }
    }
}
