using BinarySearchTree;
using Xunit;

namespace TreeTest
{
    public class TreeTest
    {
        BstService tree;

        public TreeTest()
        {
            tree = new BstService();
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
            Assert.False(tree.IsEmpty());
        }

    }

}