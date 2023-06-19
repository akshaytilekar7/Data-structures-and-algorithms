using DoublyCircularLinkList;
using Xunit;

namespace DoublyCircularLinkListTests
{
    public class StackTests
    {
        IStack stack;

        public StackTests()
        {
            stack = new Stack();
        }

        [Fact]
        public void IsEmpty()
        {
            Assert.True(stack.IsEmptyStack());
            stack.Push(100);
            Assert.False(stack.IsEmptyStack());
        }

        [Fact]
        public void EmptyPop()
        {
            Assert.True(stack.IsEmptyStack());
            Assert.True(stack.Pop() == -1);
            Assert.True(stack.IsEmptyStack());
        }

        [Fact]
        public void PushCheck()
        {
            stack.Push(100);
            stack.Push(200);
            stack.Push(300);
            stack.Push(400);
            Assert.True(stack.Pop() == 400);
            Assert.True(stack.Pop() == 300);
            Assert.True(stack.Pop() == 200);
            Assert.True(stack.Pop() == 100);
            Assert.True(stack.IsEmptyStack());
        }

        [Fact]
        public void PeekCheck()
        {
            stack.Push(100);
            stack.Push(200);
            stack.Push(300);
            stack.Push(400);
            Assert.True(stack.Peek() == 400);
            Assert.True(stack.Pop() == 400);
            Assert.True(stack.Pop() == 300);
            Assert.True(stack.Pop() == 200);
            Assert.True(stack.Pop() == 100);
            Assert.True(stack.Peek() == -1);
        }
    }
}
