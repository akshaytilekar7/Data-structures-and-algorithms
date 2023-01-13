
namespace Graph
{
    public class Set
    {
        public Set()
        {
            HorizontalSets = new List<int>();
        }
        public List<int> HorizontalSets { get; set; } // no duplication allowed
        public int Pk { get; set; }
    }

    public class DcdsService
    {
        private readonly List<Set> _sets;
        public DcdsService()
        {
            _sets = new List<Set>();
        }

        public void Create(int value)
        {
            if (_sets.Any( s => s.HorizontalSets.Any(x => x == value)))
                return;

            _sets.Add(new Set() { 
                Pk = value,
                HorizontalSets = new List<int> { value }    
            });
        }

        public Set GetSetByValue(int value)
        {
            return _sets.FirstOrDefault(x => x.HorizontalSets.Contains(value));
        }

        public void MakeUnion(int pk1, int pk2)
        {
            var set1 = _sets.FirstOrDefault( x => x.Pk == pk1);
            var set2 = _sets.FirstOrDefault(x => x.Pk == pk2);

            _sets.Remove(set1);
            _sets.Remove(set2);

            var newSet = new Set();
            newSet.Pk = pk1;
            newSet.HorizontalSets = new List<int>();
            newSet.HorizontalSets.AddRange(set1.HorizontalSets);
            newSet.HorizontalSets.AddRange(set2.HorizontalSets);
            _sets.Add(newSet);
        }

        public void Print(string msg = "")
        {
            Console.WriteLine(msg);

            foreach (var set in _sets)
            {
                Console.Write("[SET]  [" + set.Pk + "]  ->");
                foreach (var value in set.HorizontalSets)
                    Console.Write("[" + value + "]");
                Console.WriteLine("\t[END]");
            }
        }

    }
}
