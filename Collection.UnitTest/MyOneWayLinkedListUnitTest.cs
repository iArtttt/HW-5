using Interface.MyCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection.UnitTest
{
    [TestClass]
    public class MyOneWayLinkedListUnitTest
    {
        [TestMethod]
        [TestCategory("OneWayLinkedList")]
        public void OneWayLinkedList_AddFrom1to5_CountCheck()
        {
            MyOneWayLinkedList<int> oneWayTestLinkedList = new MyOneWayLinkedList<int>();

            oneWayTestLinkedList.Add(1);
            Assert.AreEqual(1, oneWayTestLinkedList.Count);

            oneWayTestLinkedList.Add(2);
            Assert.AreEqual(2, oneWayTestLinkedList.Count);

            oneWayTestLinkedList.Add(3);
            Assert.AreEqual(3, oneWayTestLinkedList.Count);

            oneWayTestLinkedList.Add(4);
            Assert.AreEqual(4, oneWayTestLinkedList.Count);

            oneWayTestLinkedList.Add(5);
            Assert.AreEqual(5, oneWayTestLinkedList.Count);

        }

        [TestMethod]
        [TestCategory("OneWayLinkedList")]
        [DataRow(16, new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [DataRow(5, new[] { 32, 12, 1, 54, 8, 15 })]
        [DataRow(111, new[] { 4, 5, 26, 7, 41, 1, 9 })]
        public void OneWayLinkedList_AddFirst_ItemCheck(int expected, int[] ints)
        {
            MyOneWayLinkedList<int> myOneWayLinkedList = new();
            
            for (int i = 0; i < ints.Length; i++)
            {
                myOneWayLinkedList.Add(ints[i]);
            }

            myOneWayLinkedList.AddFirst(expected);
            Assert.AreEqual(expected, myOneWayLinkedList.First.Item);
        }

        [TestMethod]
        [TestCategory("OneWayLinkedList")]
        [DataRow(16, new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [DataRow(5,new[] { 32, 12, 1, 54, 8, 15   })]
        [DataRow(111,new[] { 4, 5, 26, 7, 41, 1, 9  })]
        public void OneWayLinkedList_AddFirst_ReferenceCheck(int item, int[] ints)
        {
            MyOneWayLinkedList<int> myOneWayLinkedList = new();

            for (int i = 0; i < ints.Length; i++)
            {
                myOneWayLinkedList.Add(ints[i]);
            }
            var notExpected = myOneWayLinkedList.First;
            myOneWayLinkedList.AddFirst(item);
            Assert.AreNotSame(notExpected, myOneWayLinkedList.First);
        }

        [TestMethod]
        [TestCategory("OneWayLinkedList")]
        [DataRow(16, new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [DataRow(5,new[] { 32, 12, 1, 54, 8, 15   })]
        [DataRow(111,new[] { 4, 5, 26, 7, 41, 1, 9  })]
        public void OneWayLinkedList_Insert_ItemCheck(int expected, int[] ints)
        {
            MyOneWayLinkedList<int> myOneWayLinkedList = new();

            for (int i = 0; i < ints.Length; i++)
            {
                myOneWayLinkedList.Add(ints[i]);
            }

            myOneWayLinkedList.Insert(2, expected);
            Assert.AreEqual(expected, myOneWayLinkedList.First.Next.Next.Next.Item);
        }

        [TestMethod]
        [TestCategory("OneWayLinkedList")]
        [DataRow(16, new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [DataRow(5, new[] { 32, 12, 1, 54, 8, 15   })]
        [DataRow(111, new[] { 4, 5, 26, 7, 41, 1, 9  })]
        public void OneWayLinkedList_Insert_ReferenceCheck(int item, int[] ints)
        {
            MyOneWayLinkedList<int> myOneWayLinkedList = new();

            for (int i = 0; i < ints.Length; i++)
            {
                myOneWayLinkedList.Add(ints[i]);
            }

            var notExpected = myOneWayLinkedList.First.Next.Next.Next;
            myOneWayLinkedList.Insert(2, item);
            Assert.AreNotSame(notExpected, myOneWayLinkedList.First.Next.Next.Next);
        }

        [TestMethod]
        [TestCategory("OneWayLinkedList")]
        [DataRow(new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [DataRow(new[] { 32, 12, 1, 54, 8, 15 })]
        [DataRow(new[] { 4, 5, 26, 7, 41, 1, 9 })]
        public void OneWayLinkedList_ContainsTrue(int[] ints)
        {
            MyOneWayLinkedList<int> myOneWayLinkedList = new();

            for (int i = 0; i < ints.Length; i++)
            {
                myOneWayLinkedList.Add(ints[i]);
            }
            Assert.IsTrue(myOneWayLinkedList.Contains(1));
        }
        [TestMethod]
        [TestCategory("OneWayLinkedList")]
        [DataRow(new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [DataRow(new[] { 32, 12, 1, 54, 8, 15 })]
        [DataRow(new[] { 4, 5, 26, 7, 41, 1, 9 })]
        public void OneWayLinkedList_ContainsFalse(int[] ints)
        {
            MyOneWayLinkedList<int> myOneWayLinkedList = new();

            for (int i = 0; i < ints.Length; i++)
            {
                myOneWayLinkedList.Add(ints[i]);
            }
            Assert.IsFalse(myOneWayLinkedList.Contains(50));
        }
        [TestMethod]
        [TestCategory("OneWayLinkedList")]
        [DataRow(new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [DataRow(new[] { 32, 12, 1, 54, 8, 15 })]
        [DataRow(new[] { 4, 5, 26, 7, 41, 1, 9 })]
        public void OneWayLinkedList_ToArrayTest(int[] ints)
        {
            MyOneWayLinkedList<int> myOneWayLinkedList = new();

            for (int i = 0; i < ints.Length; i++)
            {
                myOneWayLinkedList.Add(ints[i]);
            }
            
            var actualArray = myOneWayLinkedList.ToArray();
            for (int i = 0;i < actualArray.Length; i++)
            {
                Assert.AreEqual(ints[i], actualArray[i]);
            }
        }

        [TestMethod]
        [TestCategory("OneWayLinkedList")]
        [DataRow(new[] { 1, 2, 3, 4, 5, 6, 7 })]
        [DataRow(new[] { 32, 12, 1, 54, 8, 15 })]
        [DataRow(new[] { 4, 5, 26, 7, 41, 1, 9 })]
        public void OneWayLinkedList_ClearTest(int[] ints)
        {
            MyOneWayLinkedList<int> myOneWayLinkedList = new();

            for (int i = 0; i < ints.Length; i++)
            {
                myOneWayLinkedList.Add(ints[i]);
            }
            myOneWayLinkedList.Clear();

            Assert.AreSame(null, myOneWayLinkedList.First);
        }
    }
}
