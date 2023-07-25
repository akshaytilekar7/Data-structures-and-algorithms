using DoublyCircularLinkList.PriorityQueue;
using Xunit;

namespace DoublyCircularLinkListTests
{
    public class PriorityQueueTests
    {
        PriorityQueue priorityQueue;

        public PriorityQueueTests()
        {
            priorityQueue = new PriorityQueue();
        }

        [Fact]
        public void IsEmpty()
        {
            Assert.True(priorityQueue.IsEmptyQueue());
            priorityQueue.QueueAdd(100);
            Assert.False(priorityQueue.IsEmptyQueue());
        }

        [Fact]
        public void EmptyPop()
        {
            Assert.True(priorityQueue.IsEmptyQueue());
            Assert.True(priorityQueue.Dequeue() == -1);
            Assert.True(priorityQueue.IsEmptyQueue());
        }

        [Fact]
        public void PushCheck()
        {
            priorityQueue.QueueAdd(100);
            priorityQueue.QueueAdd(200);
            priorityQueue.QueueAdd(400);
            priorityQueue.QueueAdd(300);
            Assert.True(priorityQueue.Dequeue() == 400);
            Assert.True(priorityQueue.Dequeue() == 300);
            Assert.True(priorityQueue.Dequeue() == 200);
            Assert.True(priorityQueue.Dequeue() == 100);
            Assert.True(priorityQueue.IsEmptyQueue());
        }

        [Fact]
        public void PeekCheck()
        {
            priorityQueue.QueueAdd(300);
            priorityQueue.QueueAdd(200);
            priorityQueue.QueueAdd(400);
            priorityQueue.QueueAdd(100);
            Assert.True(priorityQueue.Dequeue() == 400);
            Assert.True(priorityQueue.Dequeue() == 300);
            Assert.True(priorityQueue.Dequeue() == 200);
            Assert.True(priorityQueue.Dequeue() == 100);
        }
    }
}
