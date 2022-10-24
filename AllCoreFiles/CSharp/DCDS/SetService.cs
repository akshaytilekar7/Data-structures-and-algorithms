namespace CSharp
{
    public class SetService
    {
        public Set CreateNewSet(int item)
        {
            Set set = new Set();
            set.listInt.Add(item);
            set.Count += 1;
            set.PrimaryKey = item;
            return set;
        }

        public int Add(Set set, int item)
        {
            set.Count += 1;
            set.listInt.Add(item);
            return 1;
        }

        public int Search(Set set, int item)
        {
            for (int i = 0; i < set.Count; ++i)
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
