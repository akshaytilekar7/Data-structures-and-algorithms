using SLL;
using Xunit;

namespace SinglyLinkListTests
{
    public class SLLServiceTest
    {
        SLLService linklist;

        public SLLServiceTest()
        {
            linklist = new SLLService();
        }

        [Fact]
        public void IsEmpty()
        {
            Assert.True(linklist.IsEmpty());
            linklist.AddLast(100);
            Assert.False(linklist.IsEmpty());
        }

        [Fact]
        public void AddFirst_1()
        {
            linklist.AddFirst(100);
            Assert.True(linklist.GetFirst() == 100);
            Assert.True(linklist.GetLength() == 1);
        }

        [Fact]
        public void AddFirst_2()
        {
            linklist.AddFirst(100);
            linklist.AddFirst(200);
            linklist.AddLast(300);

            Assert.True(linklist.GetFirst() == 200);
            Assert.True(linklist.GetLength() == 3);
        }

        [Fact]
        public void AddLast_1()
        {
            linklist.AddLast(100);
            Assert.True(linklist.GetFirst() == 100);
            Assert.True(linklist.GetLength() == 1);
        }

        [Fact]
        public void AddLast_2()
        {
            linklist.AddFirst(100);
            linklist.AddFirst(200);
            linklist.AddLast(100);
            Assert.True(linklist.GetLast() == 100);
            Assert.True(linklist.GetLength() == 3);
        }

        [Fact]
        public void AddLast_3()
        {
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.AddLast(100);
            Assert.True(linklist.GetLast() == 100);
            Assert.True(linklist.GetLength() == 3);
        }

        [Fact]
        public void AddAfter_1()
        {
            linklist.AddLast(100);
            linklist.AddAfter(100, 150);

            Assert.True(linklist.GetLength() == 2);
            Assert.True(linklist.GetFirst() == 100);
            Assert.True(linklist.GetLast() == 150);
            Assert.True(linklist.IsExist(150));
        }

        [Fact]
        public void AddAfter_2()
        {
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.AddAfter(100, 150);

            Assert.True(linklist.GetLength() == 3);
            Assert.True(linklist.GetFirst() == 100);
            Assert.True(linklist.GetLast() == 200);
            Assert.True(linklist.IsExist(150));
        }

        [Fact]
        public void AddBefore_1()
        {
            linklist.AddLast(100);
            linklist.AddBefore(100, 50);

            Assert.True(linklist.GetLength() == 2);
            Assert.True(linklist.GetFirst() == 50);
            Assert.True(linklist.GetLast() == 100);
            Assert.True(linklist.IsExist(50));
        }

        [Fact]
        public void AddBefore_2()
        {
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.AddBefore(200, 150);

            Assert.True(linklist.GetLength() == 3);
            Assert.True(linklist.GetFirst() == 100);
            Assert.True(linklist.GetLast() == 200);
            Assert.True(linklist.IsExist(150));
        }

        [Fact]
        public void GetNode()
        {
            Assert.True(linklist.GetNode(100) == null);
            Assert.True(linklist.GetLength() == 0);

            linklist.AddLast(100);

            Assert.True(linklist.GetNode(100) != null);
            Assert.True(linklist.GetNode(40) == null);
            Assert.True(linklist.GetLength() == 1);
        }

        [Fact]
        public void IsExist()
        {
            Assert.False(linklist.IsExist(100));
            Assert.True(linklist.GetLength() == 0);

            linklist.AddLast(100);

            Assert.True(linklist.IsExist(100));
            Assert.False(linklist.IsExist(40));
            Assert.True(linklist.GetLength() == 1);
        }

        [Fact]
        public void Delete_WhenEmpty()
        {
            linklist.Delete(400);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void Delete_Single()
        {
            linklist.AddLast(400);
            Assert.True(linklist.GetLength() == 1);
            linklist.Delete(400);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void Delete_Last()
        {
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.AddLast(300);
            linklist.AddLast(400);

            Assert.True(linklist.GetLength() == 4);

            linklist.Delete(400);
            Assert.True(linklist.GetLength() == 3);

            Assert.False(linklist.IsExist(400));

            Assert.True(linklist.IsExist(100));
            Assert.True(linklist.IsExist(200));
            Assert.True(linklist.IsExist(300));
        }

        [Fact]
        public void Delete_First()
        {
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.AddLast(300);
            linklist.AddLast(400);

            Assert.True(linklist.GetLength() == 4);

            linklist.Delete(100);
            Assert.True(linklist.GetLength() == 3);

            Assert.False(linklist.IsExist(100));

            Assert.True(linklist.IsExist(200));
            Assert.True(linklist.IsExist(300));
            Assert.True(linklist.IsExist(400));
        }

        [Fact]
        public void Delete_MiddleSomewher()
        {
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.AddLast(300);
            linklist.AddLast(400);

            Assert.True(linklist.GetLength() == 4);

            linklist.Delete(200);
            Assert.True(linklist.GetLength() == 3);

            Assert.False(linklist.IsExist(200));

            Assert.True(linklist.IsExist(100));
            Assert.True(linklist.IsExist(300));
            Assert.True(linklist.IsExist(400));
        }

        [Fact]
        public void Delete_All()
        {
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.AddLast(300);
            linklist.AddLast(400);

            Assert.True(linklist.GetLength() == 4);

            linklist.Delete(100);
            Assert.True(linklist.GetLength() == 3);
            linklist.Delete(400);
            Assert.True(linklist.GetLength() == 2);
            linklist.Delete(200);
            Assert.True(linklist.GetLength() == 1);
            linklist.Delete(300);
            Assert.True(linklist.GetLength() == 0);

            Assert.False(linklist.IsExist(100));
            Assert.False(linklist.IsExist(200));
            Assert.False(linklist.IsExist(300));
            Assert.False(linklist.IsExist(400));
        }

        [Fact]
        public void PopFirst_Empty()
        {
            Assert.True(linklist.PopFirst() == -1);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void PopFirst_Single()
        {
            linklist.AddLast(100);
            Assert.True(linklist.GetLength() == 1);
            Assert.True(linklist.PopFirst() == 100);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void PopFirst_TwoNode()
        {
            linklist.AddLast(100);
            linklist.AddLast(200);
            Assert.True(linklist.GetLength() == 2);
            Assert.True(linklist.PopFirst() == 100);
            Assert.True(linklist.GetLength() == 1);
            Assert.True(linklist.PopFirst() == 200);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void PopFirst_Multiple()
        {
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.AddLast(300);
            Assert.True(linklist.GetLength() == 3);
            Assert.True(linklist.PopFirst() == 100);
            Assert.True(linklist.GetLength() == 2);
            Assert.True(linklist.PopFirst() == 200);
            Assert.True(linklist.GetLength() == 1);
            Assert.True(linklist.PopFirst() == 300);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void PopLast_Empty()
        {
            Assert.True(linklist.PopLast() == -1);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void PopLast_Single()
        {
            linklist.AddLast(100);
            Assert.True(linklist.GetLength() == 1);
            Assert.True(linklist.PopLast() == 100);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void PopLast_TwoNode()
        {
            linklist.AddLast(100);
            linklist.AddLast(200);
            Assert.True(linklist.GetLength() == 2);
            Assert.True(linklist.PopLast() == 200);
            Assert.True(linklist.GetLength() == 1);
            Assert.True(linklist.PopLast() == 100);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void PopLast_Multiple()
        {
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.AddLast(300);
            Assert.True(linklist.GetLength() == 3);
            Assert.True(linklist.PopLast() == 300);
            Assert.True(linklist.GetLength() == 2);
            Assert.True(linklist.PopLast() == 200);
            Assert.True(linklist.GetLength() == 1);
            Assert.True(linklist.PopLast() == 100);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void GetFirst_Empty()
        {
            Assert.True(linklist.GetFirst() == -1);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void GetFirst_Single()
        {
            linklist.AddLast(100);
            Assert.True(linklist.GetLength() == 1);
            Assert.True(linklist.GetFirst() == 100);
            Assert.True(linklist.GetLength() == 1);
        }

        [Fact]
        public void GetFirst_TwoNode()
        {
            linklist.AddLast(100);
            linklist.AddLast(200);
            Assert.True(linklist.GetLength() == 2);
            Assert.True(linklist.GetFirst() == 100);
            Assert.True(linklist.GetLength() == 2);
            Assert.True(linklist.GetFirst() == 100);
            Assert.True(linklist.GetLength() == 2);
        }

        [Fact]
        public void GetFirst_Multiple()
        {
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.AddLast(300);
            Assert.True(linklist.GetLength() == 3);
            Assert.True(linklist.GetFirst() == 100);
            Assert.True(linklist.GetLength() == 3);
            Assert.True(linklist.GetFirst() == 100);
            Assert.True(linklist.GetLength() == 3);
            Assert.True(linklist.GetFirst() == 100);
            Assert.True(linklist.GetLength() == 3);
        }

        [Fact]
        public void GetLast_Empty()
        {
            Assert.True(linklist.GetLast() == -1);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void GetLast_Single()
        {
            linklist.AddLast(100);
            Assert.True(linklist.GetLength() == 1);
            Assert.True(linklist.GetLast() == 100);
            Assert.True(linklist.GetLength() == 1);
        }

        [Fact]
        public void GetLast_TwoNode()
        {
            linklist.AddLast(100);
            linklist.AddLast(200);
            Assert.True(linklist.GetLength() == 2);
            Assert.True(linklist.GetLast() == 200);
            Assert.True(linklist.GetLength() == 2);
            Assert.True(linklist.GetLast() == 200);
            Assert.True(linklist.GetLength() == 2);
        }

        [Fact]
        public void GetLast_Multiple()
        {
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.AddLast(300);
            Assert.True(linklist.GetLength() == 3);
            Assert.True(linklist.GetLast() == 300);
            Assert.True(linklist.GetLength() == 3);
            Assert.True(linklist.GetLast() == 300);
            Assert.True(linklist.GetLength() == 3);
            Assert.True(linklist.GetLast() == 300);
            Assert.True(linklist.GetLength() == 3);
        }

        [Fact]
        public void DeleteFirstOccurence_WhenEmpty()
        {
            Assert.True(linklist.GetLength() == 0);
            linklist.DeleteFirstOccurance(500);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void DeleteFirstOccurence_WhenSingle()
        {
            Assert.True(linklist.GetLength() == 0);
            linklist.AddLast(100);
            linklist.DeleteFirstOccurance(100);
            linklist.DeleteFirstOccurance(500);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void DeleteFirstOccurence_When2Same_DeletedItemLocationStart()
        {
            Assert.True(linklist.GetLength() == 0);
            linklist.AddLast(100);
            linklist.AddLast(100);
            linklist.DeleteFirstOccurance(100);
            Assert.True(linklist.GetLength() == 1);
            linklist.DeleteFirstOccurance(100);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void DeleteFirstOccurence_When2AreNotSame_DeletedItemLocationStart()
        {
            Assert.True(linklist.GetLength() == 0);
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.DeleteFirstOccurance(100);
            Assert.True(linklist.GetLength() == 1);
            linklist.DeleteFirstOccurance(100);
            Assert.True(linklist.GetLength() == 1);
        }

        [Fact]
        public void DeleteFirstOccurence_WhenMultiple_DeletedItemLocationStart()
        {
            Assert.True(linklist.GetLength() == 0);
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.AddLast(100);
            linklist.AddLast(300);
            linklist.AddLast(400);
            linklist.AddLast(100);

            linklist.DeleteFirstOccurance(100);
            Assert.True(linklist.GetLength() == 5);
            Assert.True(linklist.IsExist(100));
            linklist.DeleteFirstOccurance(100);
            Assert.True(linklist.GetLength() == 4);
            Assert.True(linklist.IsExist(100));
            linklist.DeleteFirstOccurance(100);
            Assert.True(linklist.GetLength() == 3);
            Assert.False(linklist.IsExist(100));
        }

        [Fact]
        public void DeleteFirstOccurence_DeletedItemLocationLast()
        {
            Assert.True(linklist.GetLength() == 0);
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.AddLast(300);
            linklist.AddLast(400);
            Assert.True(linklist.GetLength() == 4);

            linklist.DeleteFirstOccurance(400);
            Assert.True(linklist.GetLength() == 3);
            Assert.False(linklist.IsExist(400));
        }

        [Fact]
        public void DeleteFirstOccurence_DeletedItemLocationLastMultiple()
        {
            Assert.True(linklist.GetLength() == 0);
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.AddLast(300);
            linklist.AddLast(400);
            linklist.AddLast(400);
            Assert.True(linklist.GetLength() == 5);

            linklist.DeleteFirstOccurance(400);
            linklist.DeleteFirstOccurance(400);
            linklist.DeleteFirstOccurance(400);

            Assert.True(linklist.GetLength() == 3);
            Assert.False(linklist.IsExist(400));
        }

        [Fact]
        public void DeleteLastOccurence_WhenEmpty()
        {
            Assert.True(linklist.GetLength() == 0);
            linklist.DeleteLastOccurance(500);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void DeleteLastOccurence_WhenSingle()
        {
            Assert.True(linklist.GetLength() == 0);
            linklist.AddLast(100);
            linklist.DeleteLastOccurance(100);
            linklist.DeleteLastOccurance(500);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void DeleteLastOccurence_When2Same_DeletedItemLocationStart()
        {
            Assert.True(linklist.GetLength() == 0);
            linklist.AddLast(100);
            linklist.AddLast(100);
            linklist.DeleteLastOccurance(100);
            Assert.True(linklist.GetLength() == 1);
            linklist.DeleteLastOccurance(100);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void DeleteLastOccurence_When2AreNotSame_DeletedItemLocationStart()
        {
            Assert.True(linklist.GetLength() == 0);
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.AddLast(100);
            linklist.DeleteLastOccurance(100);
            Assert.True(linklist.GetFirst() == 100);
            Assert.True(linklist.GetLength() == 2);
            linklist.DeleteLastOccurance(100);
            Assert.True(linklist.GetFirst() == 200);
            Assert.True(linklist.GetLength() == 1);
        }

        [Fact]
        public void DeleteLastOccurence_WhenMultiple_DeletedItemLocationStart()
        {
            Assert.True(linklist.GetLength() == 0);
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.AddLast(100);
            linklist.AddLast(300);
            linklist.AddLast(400);
            linklist.AddLast(100);

            linklist.DeleteLastOccurance(100);
            Assert.True(linklist.GetFirst() == 100);
            Assert.True(linklist.GetLast() == 400);
            Assert.True(linklist.GetLength() == 5);
            Assert.True(linklist.IsExist(100));

            linklist.DeleteLastOccurance(100);
            Assert.True(linklist.GetFirst() == 100);
            Assert.True(linklist.GetLast() == 400);
            Assert.True(linklist.GetLength() == 4);
            Assert.True(linklist.IsExist(100));

            linklist.DeleteLastOccurance(100);
            Assert.True(linklist.GetFirst() == 200);
            Assert.True(linklist.GetLast() == 400);
            Assert.True(linklist.GetLength() == 3);
            Assert.False(linklist.IsExist(100));
        }

        [Fact]
        public void DeleteLastOccurence_DeletedItemLocationLast()
        {
            Assert.True(linklist.GetLength() == 0);
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.AddLast(300);
            linklist.AddLast(400);
            Assert.True(linklist.GetLength() == 4);

            linklist.DeleteLastOccurance(400);
            Assert.True(linklist.GetLength() == 3);
            Assert.False(linklist.IsExist(400));
        }

        [Fact]
        public void DeleteLastOccurence_DeletedItemLocationLastMultiple()
        {
            Assert.True(linklist.GetLength() == 0);
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.AddLast(300);
            linklist.AddLast(400);
            linklist.AddLast(400);
            Assert.True(linklist.GetLength() == 5);

            linklist.DeleteLastOccurance(400);
            linklist.DeleteLastOccurance(400);
            linklist.DeleteLastOccurance(400);

            Assert.True(linklist.GetLength() == 3);
            Assert.False(linklist.IsExist(400));
        }

        [Fact]
        public void DeleteAllOccurence_WhenEmpty()
        {
            Assert.True(linklist.GetLength() == 0);
            linklist.DeleteAllOccurance(500);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void DeleteAllOccurence_WhenSingle()
        {
            Assert.True(linklist.GetLength() == 0);
            linklist.AddLast(100);
            linklist.DeleteAllOccurance(500);
            linklist.DeleteAllOccurance(100);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void DeleteAllOccurence_WhenAllItemAreSame()
        {
            Assert.True(linklist.GetLength() == 0);
            linklist.AddLast(100);
            linklist.AddLast(100);
            linklist.AddLast(100);
            Assert.True(linklist.GetLength() == 3);
            linklist.DeleteAllOccurance(500);
            linklist.DeleteAllOccurance(100);
            Assert.True(linklist.GetLength() == 0);
        }

        [Fact]
        public void DeleteAllOccurence_WhenAllItemAreNotSame_StartEnd()
        {
            Assert.True(linklist.GetLength() == 0);
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.AddLast(100);
            linklist.AddLast(300);
            linklist.AddLast(100);
            Assert.True(linklist.GetLength() == 5);
            linklist.DeleteAllOccurance(500);
            linklist.DeleteAllOccurance(100);
            Assert.True(linklist.GetLength() == 2);
            Assert.False(linklist.IsExist(100));
            Assert.True(linklist.IsExist(200));
            Assert.True(linklist.IsExist(300));

        }

        [Fact]
        public void DeleteAllOccurence_WhenAllItemAreNotSame_2()
        {
            Assert.True(linklist.GetLength() == 0);
            linklist.AddLast(50);
            linklist.AddLast(200);
            linklist.AddLast(100);
            linklist.AddLast(300);
            linklist.AddLast(400);
            Assert.True(linklist.GetLength() == 5);
            linklist.DeleteAllOccurance(500);
            linklist.DeleteAllOccurance(100);
            Assert.True(linklist.GetLength() == 4);
            Assert.False(linklist.IsExist(100));
            Assert.True(linklist.IsExist(200));
            Assert.True(linklist.IsExist(300));
            Assert.True(linklist.IsExist(400));
        }

        [Fact]
        public void DeleteAllOccurence_WhenAllItemAreNotSame_3()
        {
            Assert.True(linklist.GetLength() == 0);
            linklist.AddLast(100);
            linklist.AddLast(100);
            linklist.AddLast(200);
            linklist.AddLast(100);
            linklist.AddLast(100);
            Assert.True(linklist.GetLength() == 5);
            linklist.DeleteAllOccurance(500);
            linklist.DeleteAllOccurance(100);
            Assert.True(linklist.GetLength() == 1);
            Assert.True(linklist.IsExist(200));
        }
    }
}
