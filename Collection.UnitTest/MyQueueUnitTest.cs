using Interface.MyCollection;
using Interface.InterfaceCollectionGeneric;

namespace Collection.UnitTest
{
    [TestClass]
    public class MyQueueUnitTest
    {
        MyQueue<int> myQueue = new();

        [TestInitialize]
        public void Init()
        {
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(4);
            myQueue.Enqueue(5);
            myQueue.Enqueue(6);
            myQueue.Enqueue(7);
            myQueue.Enqueue(8);
            myQueue.Enqueue(9);
            myQueue.Enqueue(10);
        }

        [TestMethod]
        [TestCategory("Queue")]
        [TestCategory("Queue Property")]
        public void Queue_Test_Count()
        {
            Assert.AreEqual(10, myQueue.Count);
        }

        [TestMethod]
        [TestCategory("Queue")]
        [TestCategory("Queue Methods")]
        [DataRow(1)]
        [DataRow(6)]
        [DataRow(10)]
        public void Queue_Test_Peeks(int peeks)
        {
            for (int i = 0; i < peeks; i++)
            {
                Assert.AreEqual(1, myQueue.Peek());
            }
        }

        [TestMethod]
        [TestCategory("Queue")]
        [TestCategory("Queue Methods")]
        [DataRow(1)]
        [DataRow(4)]
        [DataRow(6)]
        [DataRow(9)]
        public void Queue_Test_Dequeues(int dequeues)
        {
            for (int i = 0; i < dequeues; i++)
            {
                Assert.AreEqual(i + 1, myQueue.Dequeue());
            }
        }

        [TestMethod]
        [TestCategory("Queue")]
        [TestCategory("Queue Methods")]
        public void Queue_Test_ToArray()
        {
            var actualArray = myQueue.ToArray();
            for (int i = 0; i < myQueue.Count; i++)
            {
                Assert.AreEqual(i + 1, actualArray[i]);
            }
        }
    }
}
