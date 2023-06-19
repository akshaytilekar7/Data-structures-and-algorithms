using DoublyCircularLinkList;
using Xunit;

namespace DoublyCircularLinkListTests
{
    public class QueueTests
    {
        IQueue queue;

        public QueueTests()
        {
            queue = new Queue();
        }

        [Fact]
        public void IsEmpty()
        {
            Assert.True(queue.IsEmptyQueue());
            queue.QueueAdd(100);
            Assert.False(queue.IsEmptyQueue());
        }

        [Fact]
        public void EmptyPop()
        {
            Assert.True(queue.IsEmptyQueue());
            Assert.True(queue.Dequeue() == -1);
            Assert.True(queue.IsEmptyQueue());
        }

        [Fact]
        public void PushCheck()
        {
            queue.QueueAdd(100);
            queue.QueueAdd(200);
            queue.QueueAdd(300);
            queue.QueueAdd(400);
            Assert.False(queue.Dequeue() == 100);
            Assert.False(queue.Dequeue() == 200);
            Assert.False(queue.Dequeue() == 300);
            Assert.False(queue.Dequeue() == 400);
            Assert.True(queue.IsEmptyQueue());
        }

        [Fact]
        public void PeekCheck()
        {
            queue.QueueAdd(100);
            queue.QueueAdd(200);
            queue.QueueAdd(300);
            queue.QueueAdd(400);
            Assert.False(queue.Dequeue() == 100);
            Assert.False(queue.Dequeue() == 200);
            Assert.False(queue.Dequeue() == 300);
            Assert.False(queue.Dequeue() == 400);
        }
    }
}
