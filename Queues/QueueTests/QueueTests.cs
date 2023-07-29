using Queue;
using Xunit;

namespace DoublyCircularLinkListTests
{
    public class QueueTests
    {
        QueueService queue;

        public QueueTests()
        {
            queue = new QueueService();
        }

        [Fact]
        public void IsEmpty()
        {
            Assert.True(queue.IsEmpty());
            queue.Enqueue(100);
            Assert.False(queue.IsEmpty());
        }

        [Fact]
        public void EmptyPop()
        {
            Assert.True(queue.IsEmpty());
            Assert.True(queue.Dequeue() == -1);
            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void PushCheck()
        {
            queue.Enqueue(100);
            queue.Enqueue(200);
            queue.Enqueue(300);
            queue.Enqueue(400);
            Assert.True(queue.Dequeue() == 100);
            Assert.True(queue.Dequeue() == 200);
            Assert.True(queue.Dequeue() == 300);
            Assert.True(queue.Dequeue() == 400);
            Assert.True(queue.IsEmpty());
        }

        [Fact]
        public void PeekCheck()
        {
            queue.Enqueue(100);
            queue.Enqueue(200);
            queue.Enqueue(300);
            queue.Enqueue(400);
            Assert.True(queue.Dequeue() == 100);
            Assert.True(queue.Dequeue() == 200);
            Assert.True(queue.Dequeue() == 300);
            Assert.True(queue.Dequeue() == 400);
        }
    }
}
