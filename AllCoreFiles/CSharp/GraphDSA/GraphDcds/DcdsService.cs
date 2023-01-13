namespace AllCoreFiles.CSharp.GraphDSA.GraphDcds
{
    public class DcdsService
    {
        List<Set> sets = new List<Set>();
        public int CreateSet(int element)
        {
            if (sets.Any(x => x.Ints.Contains(element)))
                return Constants.Dcds_representative_exists;

            sets.Add(new Set()
            {
                Ints = new List<int>() { element },
                Pk = element
            });

            return 1;
        }
        public int UnionSet(int pk1, int pk2)
        {
            var set1 = sets.FirstOrDefault(x => x.Pk == pk1);
            var set2 = sets.FirstOrDefault(x => x.Pk == pk2);

            sets.Remove(set1);
            sets.Remove(set2);

            var newSet = new Set();
            newSet.Pk = pk1;
            newSet.Ints.AddRange(set1.Ints);
            newSet.Ints.AddRange(set2.Ints);

            sets.Add(newSet);
            return 1;
        }
        public Set GetSetBy(int element)
        {
            return sets.FirstOrDefault(x => x.Ints.Contains(element));
        }
        public void ShowDcds(string msg)
        {
            if (msg != null)
                Console.WriteLine(msg);

            foreach (var item in sets)
            {
                Console.Write("[SET]\t->\t[" + item.Pk + "]\t");
                int i;
                for (i = 0; i < item.Ints.Count; ++i)
                    Console.Write("[" + item.Ints[i] + "]");
                Console.WriteLine("[END]");
            }
        }
    }
}
