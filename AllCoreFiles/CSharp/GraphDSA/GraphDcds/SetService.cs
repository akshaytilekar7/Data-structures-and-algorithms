namespace AllCoreFiles.CSharp.GraphDSA.GraphDcds
{
    public class SetService
    {
        public Set CreateNewSet(int item)
        {
            Set set = new Set();
            set.Ints.Add(item);
            set.Pk = item;
            return set;
        }

        public int Add(Set set, int item)
        {
            set.Ints.Add(item);
            return 1;
        }

        public int Search(Set set, int item)
        {
            for (int i = 0; i < set.Ints.Count; ++i)
                if (set.Ints[i] == item)
                    return 1;
            return 0;
        }

        public int Destroy(Set set)
        {
            if (set != null)
            {
                if (set.Ints != null)
                    set.Ints = null;
            }
            return 1;
        }

    }

}
