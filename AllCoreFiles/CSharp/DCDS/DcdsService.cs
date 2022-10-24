using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    public class DcdsService
    {
        SetService SetService = new SetService();
        public DynamicCollectionOfDisjointSets CreateDcds()
        {
            DynamicCollectionOfDisjointSets dcds = GetDcdsNode(null);
            dcds.Prev = dcds;
            dcds.Next = dcds;
            return (dcds);
        }

        public int MakeSet(DynamicCollectionOfDisjointSets dcds, int element)
        {
            for (var traverse = dcds.Next; traverse != dcds; traverse = traverse.Next)
            {
                int s = SetService.SearchElement(traverse.Set, element);
                if (s == 1)
                    return (Constants.Dcds_representative_exists);
            }

            Set p_new_set = SetService.CreateSet(element);
            GenericDcdsInsert(dcds.Prev, GetDcdsNode(p_new_set), dcds);

            return (1);
        }

        internal int UnionSet(DynamicCollectionOfDisjointSets p_dcds, int r_data_1, int r_data_2)
        {
            Set p_set_1 = null;
            Set p_set_2 = null;
            DynamicCollectionOfDisjointSets p_dcds_run = null;
            DynamicCollectionOfDisjointSets p_dcds_node_2 = null;
            int i;
            int s;

            for (p_dcds_run = p_dcds.Next; p_dcds_run != p_dcds; p_dcds_run = p_dcds_run.Next)
            {
                if (p_dcds_run.Set.RepresentativeElement == r_data_1)
                    p_set_1 = p_dcds_run.Set;
                if (p_dcds_run.Set.RepresentativeElement == r_data_2)
                {
                    p_dcds_node_2 = p_dcds_run;
                    p_set_2 = p_dcds_run.Set;
                }
            }

            if (p_set_1 == null || p_set_2 == null)
                return (Constants.Representative_element_not_found);

            for (i = 0; i < p_set_2.TotalElements; ++i)
                SetService.PushBack(p_set_1, p_set_2.NumberSets[i]);

            GenericDcdsDelete(p_dcds_node_2);

            return (1);
        }

        Set find_set(DynamicCollectionOfDisjointSets p_dcds, int r_data)
        {
            DynamicCollectionOfDisjointSets p_dcds_run = null;

            for (p_dcds_run = p_dcds.Next; p_dcds_run != p_dcds; p_dcds_run = p_dcds_run.Next)
                if (p_dcds_run.Set.RepresentativeElement == r_data)
                    return (p_dcds_run.Set);

            return (null);
        }

        public void ShowDcds(DynamicCollectionOfDisjointSets dcds, string msg)
        {
            if (msg != null)
                Console.WriteLine(msg);

            for (var traverse = dcds.Next; traverse != dcds; traverse = traverse.Next)
            {
                Console.Write("[SET]\t->\t[" + traverse.Set.RepresentativeElement + "]\t");
                int i;
                for (i = 0; i < traverse.Set.TotalElements; ++i)
                    Console.Write("[" + traverse.Set.NumberSets[i] + "]");
                Console.WriteLine("[END]");
            }
        }

        public int DestroyDcds(DynamicCollectionOfDisjointSets dcds)
        {
            DynamicCollectionOfDisjointSets dcds1 = dcds;
            DynamicCollectionOfDisjointSets next;
            
            for (var traverse = dcds1.Next; traverse != dcds1; traverse = next)
            {
                next = traverse.Next;
                SetService.DestroySet(traverse.Set);
            }
            return (1);
        }

        public void GenericDcdsInsert(DynamicCollectionOfDisjointSets start, DynamicCollectionOfDisjointSets mid, DynamicCollectionOfDisjointSets end)
        {
            mid.Next = end;
            mid.Prev = start;
            start.Next = mid;
            end.Prev = mid;
        }

        public void GenericDcdsDelete(DynamicCollectionOfDisjointSets deletedNode)
        {
            deletedNode.Prev.Next = deletedNode.Next;
            deletedNode.Next.Prev = deletedNode.Prev;
        }

        public DynamicCollectionOfDisjointSets GetDcdsNode(Set set)
        {
            DynamicCollectionOfDisjointSets newNode = new DynamicCollectionOfDisjointSets();
            newNode.Set = set;
            return (newNode);
        }
    }
}
