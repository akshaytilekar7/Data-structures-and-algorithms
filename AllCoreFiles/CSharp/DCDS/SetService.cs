namespace CSharp
{
    public class SetService
    {
        public Set CreateSet(int totalElements)
        {
            Set p_set = new Set();
            PushBack(p_set, totalElements);
            p_set.RepresentativeElement = totalElements;
            return (p_set);
        }

        public int PushBack(Set set, int element)
        {
            set.TotalElements += 1;
            set.NumberSets.Add(element); // why -1
            return (1);
        }

        public int SearchElement(Set set, int searchElement)
        {
            for (int i = 0; i < set.TotalElements; ++i)
                if (set.NumberSets[i] == searchElement)
                    return (1);
            return (0);
        }

        public int DestroySet(Set set)
        {

            if (set != null)
            {
                if (set.NumberSets != null)
                    set.NumberSets = null;
            }
            return (1);
        }

    }

}
