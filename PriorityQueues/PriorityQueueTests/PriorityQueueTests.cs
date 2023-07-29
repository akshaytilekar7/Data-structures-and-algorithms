using PriorityQueue;
using Xunit;

namespace DoublyCircularLinkListTests
{
    public class PriorityQueueTests
    {
        PriorityQueueService priorityQueue;

        public PriorityQueueTests()
        {
            priorityQueue = new PriorityQueueService();
        }

        [Fact]
        public void IsEmpty()
        {
            Assert.True(priorityQueue.IsEmpty());
            priorityQueue.Enqueue(100);
            Assert.False(priorityQueue.IsEmpty());
        }

        [Fact]
        public void EmptyPop()
        {
            Assert.True(priorityQueue.IsEmpty());
            Assert.True(priorityQueue.Dequeue() == -1);
            Assert.True(priorityQueue.IsEmpty());
        }

        [Fact]
        public void PushCheck()
        {
            priorityQueue.Enqueue(100);
            priorityQueue.Enqueue(200);
            priorityQueue.Enqueue(400);
            priorityQueue.Enqueue(300);
            Assert.True(priorityQueue.Dequeue() == 400);
            Assert.True(priorityQueue.Dequeue() == 300);
            Assert.True(priorityQueue.Dequeue() == 200);
            Assert.True(priorityQueue.Dequeue() == 100);
            Assert.True(priorityQueue.IsEmpty());
        }

        [Fact]
        public void PeekCheck()
        {
            priorityQueue.Enqueue(300);
            priorityQueue.Enqueue(200);
            priorityQueue.Enqueue(400);
            priorityQueue.Enqueue(100);
            Assert.True(priorityQueue.Dequeue() == 400);
            Assert.True(priorityQueue.Dequeue() == 300);
            Assert.True(priorityQueue.Dequeue() == 200);
            Assert.True(priorityQueue.Dequeue() == 100);
        }
    }
}
