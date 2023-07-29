using Stack;
using Xunit;

namespace DoublyCircularLinkListTests
{
    public class StackTests
    {
        StackService stack;

        public StackTests()
        {
            stack = new StackService();
        }

        [Fact]
        public void IsEmpty()
        {
            Assert.True(stack.IsEmpty());
            stack.Push(100);
            Assert.False(stack.IsEmpty());
        }

        [Fact]
        public void EmptyPop()
        {
            Assert.True(stack.IsEmpty());
            Assert.True(stack.Pop() == -1);
            Assert.True(stack.IsEmpty());
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
            Assert.True(stack.IsEmpty());
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
