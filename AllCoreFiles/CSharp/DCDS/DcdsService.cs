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

        public DynamicCollectionOfDisjointSets create_dcds()
        {
            DynamicCollectionOfDisjointSets dcds = get_dcds_node(null);
            dcds.prev = dcds;
            dcds.next = dcds;
            return (dcds);
        }

        public int make_set(DynamicCollectionOfDisjointSets dcds, int r_element)
        {
            DynamicCollectionOfDisjointSets traverse;
            for (traverse = dcds.next; traverse != dcds; traverse = traverse.next)
            {
                int s = SetService.search_element(traverse.set, r_element);
                if (s == 1)
                    return (Constants.DCDS_REPRESENTATIVE_EXISTS);
            }

            Set p_new_set = SetService.CreateSet(r_element);
            generic_dcds_insert(dcds.prev, get_dcds_node(p_new_set), dcds);

            return (1);
        }

        public int union_set(DynamicCollectionOfDisjointSets p_dcds, int r_data_1, int r_data_2)
        {
            Set p_set_1 = null;
            Set p_set_2 = null;

            DynamicCollectionOfDisjointSets p_dcds_node_2 = null;
            DynamicCollectionOfDisjointSets p_dcds_run;
            for (p_dcds_run = p_dcds.next; p_dcds_run != p_dcds; p_dcds_run = p_dcds_run.next)
            {
                if (p_dcds_run.set.RepresentativeElement == r_data_1)
                    p_set_1 = p_dcds_run.set;
                if (p_dcds_run.set.RepresentativeElement == r_data_2)
                {
                    p_dcds_node_2 = p_dcds_run;
                    p_set_2 = p_dcds_run.set;
                }
            }

            if (p_set_1 == null || p_set_2 == null)
                return (Constants.REPRESENTATIVE_ELEMENT_NOT_FOUND);

            int i;
            for (i = 0; i < p_set_2.RepresentativeElement; ++i)
                SetService.PushBack(p_set_1, p_set_2.NumberSetArr[i]);

            SetService.destroy_set(p_set_2);
            generic_dcds_delete(p_dcds_node_2);

            return (1);
        }

        public Set find_set(DynamicCollectionOfDisjointSets dcds, int r_data)
        {
            for (var traverse = dcds.next; traverse != dcds; traverse = traverse.next)
                if (traverse.set.RepresentativeElement == r_data)
                    return (traverse.set);

            return (null);
        }

        public void show_dcds(DynamicCollectionOfDisjointSets dcds, string msg)
        {
            if (msg != null)
                Console.WriteLine(msg);

            for (var traverse = dcds.next; traverse != dcds; traverse = traverse.next)
            {
                Console.Write("[SET]\t.\t[" + traverse.set.RepresentativeElement + "]\t");
                int i;
                for (i = 0; i < traverse.set.TotalElements; ++i)
                    Console.Write("[" + traverse.set.NumberSetArr[i] + "]");
                Console.WriteLine("[END]");
            }
        }

        public int destroy_dcds(DynamicCollectionOfDisjointSets dcds)
        {
            DynamicCollectionOfDisjointSets dcds1 = dcds;
            DynamicCollectionOfDisjointSets next;
            
            for (var traverse = dcds1.next; traverse != dcds1; traverse = next)
            {
                next = traverse.next;
                SetService.destroy_set(traverse.set);
            }
            return (1);
        }

        public void generic_dcds_insert(DynamicCollectionOfDisjointSets p_beg, DynamicCollectionOfDisjointSets p_mid, DynamicCollectionOfDisjointSets p_end)
        {
            p_mid.next = p_end;
            p_mid.prev = p_beg;
            p_beg.next = p_mid;
            p_end.prev = p_mid;
        }

        public void generic_dcds_delete(DynamicCollectionOfDisjointSets p_delete_node)
        {
            p_delete_node.prev.next = p_delete_node.next;
            p_delete_node.next.prev = p_delete_node.prev;
        }

        public DynamicCollectionOfDisjointSets get_dcds_node(Set p_set)
        {
            DynamicCollectionOfDisjointSets p_new_node = new DynamicCollectionOfDisjointSets();
            p_new_node.set = p_set;
            return (p_new_node);
        }
    }
}
