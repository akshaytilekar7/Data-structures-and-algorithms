using A;
using PracticeProject;

public class Program
{
    public static void Main()
    {
        try
        {
            var lines = new[] {
            "a->b",
            "r->s",
            "b->c",
            "x->c",
            "q->r",
            "y->x",
            "w->z",
            "a, q, w",
            "a, c, r",
            "y, z, a, r",
            "a, w"
        };

            var x = GraphTestMethod(lines);
            foreach (var result in x)
                Console.WriteLine(result);

            Console.WriteLine("end 1");

            lines = new[] {
            "A->B",
            "G->B",
            "B->C",
            "C->D",
            "D->E",
            "H->J",
            "J->F",
            "A,G,E",
            "H,A",
            };

            x = GraphTestMethod(lines);
            foreach (var result in x)
                Console.WriteLine(result);

            Console.WriteLine("end 2");

            lines = new[] {
            "ABC->BCD",
            "BCD->CDE",
            "DEF->EFG",
            "EFG->BCD",
            "123->456",
            "ABC,CDE",
            "123,DEF",
            "ABC,DEF",
            };

            x = GraphTestMethod(lines);
            foreach (var result in x)
                Console.WriteLine(result);

            Console.WriteLine("end 3");


            lines = new[] {
            "X->Y",
            "Y->X",
            "A->B",
            "B->C",
            "X,A"
            };

            x = GraphTestMethod(lines);
            foreach (var result in x)
                Console.WriteLine(result);

            Console.WriteLine("end 4");

            Console.ReadLine();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public static IEnumerable<string> GraphTestMethod(string[] lines)
    {
        Akshay graphManagement = new Akshay();

        foreach (var line in lines)
        {
            if (line.Contains(','))
            {
                string returnValue;

                try
                {
                    returnValue = graphManagement.LinkedListIntersection(line.Split(',').Select(v => v.Trim()), graphManagement.graph).ToString();
                }
                catch (InvalidOperationException ex) when (ex.Message == "Cycle detected.")
                {
                    returnValue = "Error Thrown!";
                }

                yield return returnValue;
            }
            else if (line.Contains("->"))
            {
                var splitStr = line.Split("->", StringSplitOptions.None);
                var current = splitStr[0].Trim();
                var next = splitStr[1].Trim();
                graphManagement.AddNew(current, next);
            }
        }

    }


}
