using Interface.MyCollection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection.UnitTest
{
    [TestClass]
    public class MyStackUnitTest
    {
        MyStack<int> myStack = new();

        [TestInitialize]
        public void Init()
        {
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            myStack.Push(5);
            myStack.Push(6);
            myStack.Push(7);
            myStack.Push(8);
            myStack.Push(9);
            myStack.Push(10);
        }

        [TestMethod]
        [TestCategory("Stack")]
        [TestCategory("Stack Property")]
        public void Stack_Test_Count()
        {
            Assert.AreEqual(10, myStack.Count);
        }

        [TestMethod]
        [TestCategory("Stack")]
        [TestCategory("Stack Methods")]
        [DataRow(1)]
        [DataRow(6)]
        [DataRow(10)]
        public void Stack_Test_Pop(int pop)
        {
            for (int i = 0; i < pop; i++)
            {
                Assert.AreEqual(myStack.Count, myStack.Pop());
            }
        }

        [TestMethod]
        [TestCategory("Stack")]
        [TestCategory("Stack Methods")]
        [DataRow(1)]
        [DataRow(4)]
        [DataRow(6)]
        [DataRow(9)]
        public void Stack_Test_Peek(int peeks)
        {
            for (int i = 0; i < peeks; i++)
            {
                Assert.AreEqual(10, myStack.Peek());
            }
        }

        [TestMethod]
        [TestCategory("Stack")]
        [TestCategory("Stack Methods")]
        public void Stack_Test_ToArray()
        {
            var actualArray = myStack.ToArray();
            for (int i = 0; i < myStack.Count; i++)
            {
                Assert.AreEqual(i + 1, actualArray[i]);
            }
        }
    }
}
