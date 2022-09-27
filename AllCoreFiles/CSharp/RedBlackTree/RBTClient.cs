using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllCoreFiles.CSharp.RedBlackTree
{
    public class RBTClient
    {
        public static void Main()
        {
            int[] arr = { 50, 20, 70, 95, 10 };

            //for (int i = 0; i < 5; ++i)
            //    arr[i] = new Random().Next();

            RBTServices rbtServices = new RBTServices();

            for (int i = 0; i < 5; ++i)
                rbtServices.Insert(arr[i]);

            //printf("H = %d\n", rbtServices.He(p_rb));

            rbtServices.Inorder();

            Console.WriteLine("asasasasas");
            for (int i = 0; i < 50; i = i + 1)
            {
                //status = remove_from_rbtree(p_rb, arr[i]);
                //assert(status == SUCCESS);
                //printf("%d:Removed data:%d\n", i, arr[i]);
                //printf("Remaining nodes = %d, H = %d\n", 50 - (i + 1), get_rb_height(p_rb));
            }
        }
    }
}
