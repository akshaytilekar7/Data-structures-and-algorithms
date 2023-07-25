using AvlTree;
using System.Collections.Generic;
using Xunit;

namespace TreeTest
{
    public class TreeTest
    {
        AvlTreeService tree;

        public TreeTest()
        {
            tree = new AvlTreeService();
        }

        [Fact]
        public void IsEmpty()
        {
            Assert.True(tree.IsEmpty());
            tree.Insert(20);
            Assert.False(tree.IsEmpty());

        }
        [Fact]
        public void IsExist()
        {
            Assert.False(tree.IsExist(20));
            tree.Insert(20);
            Assert.True(tree.IsExist(20));
            Assert.False(tree.IsExist(200));
        }

        [Fact]
        public void DeleteEmpty()
        {
            Assert.True(tree.IsEmpty());
            tree.Delete(100);
            Assert.True(tree.IsEmpty());
        }

        [Fact]
        public void DeleteSingleRoot()
        {
            Assert.True(tree.IsEmpty());
            tree.Insert(20);
            tree.Delete(20);
            Assert.True(IsSorted(tree.GetInorderList()));
            Assert.True(tree.IsEmpty());
        }

        [Fact]
        public void DeleteRoot_havingOnlyRightNode()
        {
            Assert.True(tree.IsEmpty());
            tree.Insert(100);
            tree.Insert(200);
            tree.Delete(200);
            Assert.True(tree.IsExist(100));
            Assert.False(tree.IsExist(200));
            Assert.True(IsSorted(tree.GetInorderList()));
            Assert.False(tree.IsEmpty());
        }

        [Fact]
        public void DeleteRoot_havingOnlyLeftNode()
        {
            Assert.True(tree.IsEmpty());
            tree.Insert(100);
            tree.Insert(50);

            tree.Delete(100);
            Assert.True(tree.IsExist(50));
            Assert.False(tree.IsExist(100));
            Assert.True(IsSorted(tree.GetInorderList()));
            Assert.False(tree.IsEmpty());
        }

        [Fact]
        public void DeleteRoot_havingBothNode()
        {
            Assert.True(tree.IsEmpty());
            tree.Insert(100);
            tree.Insert(50);
            tree.Insert(150);

            tree.Delete(100);
            Assert.True(tree.IsExist(50));
            Assert.True(tree.IsExist(150));
            Assert.False(tree.IsExist(100));
            Assert.True(IsSorted(tree.GetInorderList()));
            Assert.False(tree.IsEmpty());
        }

        [Fact]
        public void DeleteNonRootNode_havingBothNode()
        {
            Assert.True(tree.IsEmpty());
            tree.Insert(100);
            tree.Insert(200);
            tree.Insert(150);
            tree.Insert(300);

            tree.Delete(200);

            Assert.False(tree.IsExist(200));
            Assert.True(tree.IsExist(100));
            Assert.True(tree.IsExist(150));
            Assert.True(tree.IsExist(300));
            Assert.False(tree.IsEmpty());
        }

        [Fact]
        public void DeleteNonRootNode_havingOnlyRightNode()
        {
            Assert.True(tree.IsEmpty());
            tree.Insert(100);
            tree.Insert(200);
            tree.Insert(300);

            tree.Delete(200);

            Assert.False(tree.IsExist(200));
            Assert.True(tree.IsExist(100));
            Assert.True(tree.IsExist(300));
            Assert.True(IsSorted(tree.GetInorderList()));
            Assert.False(tree.IsEmpty());
        }

        [Fact]
        public void DeleteNonRootNode_havingOnlyLeftNode()
        {
            Assert.True(tree.IsEmpty());
            tree.Insert(100);
            tree.Insert(200);
            tree.Insert(150);

            tree.Delete(200);

            Assert.False(tree.IsExist(200));
            Assert.True(tree.IsExist(100));
            Assert.True(tree.IsExist(150));
            Assert.True(IsSorted(tree.GetInorderList()));
            Assert.False(tree.IsEmpty());
        }

        [Fact]
        public void DeleteNonRootNode_havingBothNode_InorderSucessorCase()
        {
            Assert.True(tree.IsEmpty());
            tree.Insert(100);
            tree.Insert(200);
            tree.Insert(150);
            tree.Insert(250);
            tree.Insert(350);

            tree.Delete(200);

            Assert.False(tree.IsExist(200));

            Assert.True(tree.IsExist(100));
            Assert.True(tree.IsExist(150));
            Assert.True(tree.IsExist(250));
            Assert.True(tree.IsExist(350));

            Assert.True(IsSorted(tree.GetInorderList()));
            Assert.False(tree.IsEmpty());
        }

        [Fact]
        public void DeleteNonRootNode_havingBothNode_NonInorderSucessorCase()
        {
            Assert.True(tree.IsEmpty());
            tree.Insert(100);
            tree.Insert(200);
            tree.Insert(150);
            tree.Insert(250);
            tree.Insert(225);
            tree.Insert(230);
            tree.Insert(235);
            tree.Insert(350);

            tree.Delete(200);

            Assert.False(tree.IsExist(200));

            Assert.True(tree.IsExist(100));
            Assert.True(tree.IsExist(150));
            Assert.True(tree.IsExist(250));
            Assert.True(tree.IsExist(350));
            Assert.True(tree.IsExist(250));
            Assert.True(tree.IsExist(230));
            Assert.True(tree.IsExist(235));
            Assert.True(IsSorted(tree.GetInorderList()));
            Assert.False(tree.IsEmpty());
        }

        static bool IsSorted(List<int> list)
        {
            int j = list.Count - 1;
            if (j < 1) return true;
            int ai = list[0], i = 1;
            while (i <= j && ai <= (ai = list[i])) i++;
            return i > j;
        }
    }



}