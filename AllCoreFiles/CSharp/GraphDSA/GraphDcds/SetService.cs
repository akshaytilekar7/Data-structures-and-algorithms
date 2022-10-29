namespace AllCoreFiles.CSharp.GraphDSA.GraphDcds
{
    public class SetService
    {
        public Set CreateNewSet(int item)
        {
            Set set = new Set();
            set.listInt.Add(item);
            set.FirstElementPk = item;
            return set;
        }

        public int Add(Set set, int item)
        {
            set.listInt.Add(item);
            return 1;
        }

        public int Search(Set set, int item)
        {
            for (int i = 0; i < set.listInt.Count; ++i)
                if (set.listInt[i] == item)
                    return 1;
            return 0;
        }

        public int Destroy(Set set)
        {
            if (set != null)
            {
                if (set.listInt != null)
                    set.listInt = null;
            }
            return 1;
        }

    }

}
