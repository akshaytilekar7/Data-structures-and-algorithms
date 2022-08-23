namespace CSharp
{
    public class SetService
    {
        public Set CreateSet(int r_element)
        {
            Set p_set = new Set();
            PushBack(p_set, r_element);
            p_set.RepresentativeElement = r_element;
            return (p_set);
        }

        public int PushBack(Set set, int element)
        {
            set.TotalElements += 1;
            set.NumberSetArr = new int[set.TotalElements];
            set.NumberSetArr[set.TotalElements - 1] = element; // why -1
            return (1);
        }

        public int search_element(Set set, int search_element)
        {
            for (int i = 0; i < set.TotalElements; ++i)
                if (set.NumberSetArr[i] == search_element)
                    return (1);
            return (0);
        }

        public int destroy_set(Set p_set)
        {

            if (p_set != null)
            {
                if (p_set.NumberSetArr != null)
                    p_set.NumberSetArr = null;
            }
            return (1);
        }

    }

}
