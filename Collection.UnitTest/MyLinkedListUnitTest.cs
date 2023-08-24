using Interface.MyCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection.UnitTest
{
    [TestClass]
    public class MyLinkedListUnitTest
    {
        [TestMethod]
        [TestCategory("LinkedList")]
        public void LinkedList_AddFrom1to5_CountCheck()
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();

            linkedList.Add(1);
            Assert.AreEqual(1, linkedList.Count);

            linkedList.Add(2);
            Assert.AreEqual(2, linkedList.Count);

            linkedList.Add(3);
            Assert.AreEqual(3, linkedList.Count);

            linkedList.Add(4);
            Assert.AreEqual(4, linkedList.Count);

            linkedList.Add(5);
            Assert.AreEqual(5, linkedList.Count);

        }

        [TestMethod]
        [TestCategory("LinkedList")]
        [DataRow(1, new[] {1, 2, 3, 4, 5, 6, 7})]
        [DataRow(32, new[] {32, 12, 1, 54, 8, 15})]
        [DataRow(4, new[] {4, 5, 26, 7, 41, 9})]
        public void LinkedList_FirstElementCheck(int expectedFirst, int[] ints)
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();

            for (int i = 0; i < ints.Length; i++)
            {
                linkedList.Add(ints[i]);
            }

            Assert.AreEqual(expectedFirst, linkedList.First!.Item);

        }

        [TestMethod]
        [TestCategory("LinkedList")]
        [DataRow(7, new[] {1, 2, 3, 4, 5, 6, 7})]
        [DataRow(15, new[] {32, 12, 1, 54, 8, 15})]
        [DataRow(9, new[] {4, 5, 26, 7, 41, 9})]
        public void LinkedList_AddFirstCheck(int expectedFirst, int[] ints)
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();

            for (int i = 0; i < ints.Length; i++)
            {
                linkedList.AddFirst(ints[i]);
            }

            Assert.AreEqual(expectedFirst, linkedList.First!.Item);

        }

        [TestMethod]
        [TestCategory("LinkedList")]
        [DataRow(2, new[] {1, 2, 3, 4, 5, 6, 7})]
        [DataRow(12, new[] {32, 12, 1, 54, 8, 15})]
        [DataRow(5, new[] {4, 5, 26, 7, 41, 9})]
        public void LinkedList_RemoveCheck(int toRemove, int[] ints)
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();

            for (int i = 0; i < ints.Length; i++)
            {
                linkedList.Add(ints[i]);
            }
            linkedList.Remove(toRemove);

            Assert.IsFalse(linkedList.Contains(toRemove));

        }

        [TestMethod]
        [TestCategory("LinkedList")]
        [DataRow(2, new[] {1, 2, 3, 4, 5, 6, 7})]
        [DataRow(12, new[] {32, 12, 1, 54, 8, 15})]
        [DataRow(5, new[] {4, 5, 26, 7, 41, 9})]
        public void LinkedList_RemoveFirstCheck(int expectedFirst, int[] ints)
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();

            for (int i = 0; i < ints.Length; i++)
            {
                linkedList.Add(ints[i]);
            }
            linkedList.RemoveFirst();

            Assert.AreEqual(expectedFirst, linkedList.First!.Item);

        }

        [TestMethod]
        [TestCategory("LinkedList")]
        [DataRow(6, new[] {1, 2, 3, 4, 5, 6, 7})]
        [DataRow(8, new[] {32, 12, 1, 54, 8, 15})]
        [DataRow(41, new[] {4, 5, 26, 7, 41, 9})]
        public void LinkedList_RemoveLastCheck(int expectedLast, int[] ints)
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();

            for (int i = 0; i < ints.Length; i++)
            {
                linkedList.Add(ints[i]);
            }
            linkedList.RemoveLast();

            Assert.AreEqual(expectedLast, linkedList.Last!.Item);

        }

        [TestMethod]
        [TestCategory("LinkedList")]
        [DataRow(6, new[] {1, 2, 3, 4, 5, 6, 7})]
        [DataRow(54, new[] {32, 12, 1, 54, 8, 15})]
        [DataRow(5, new[] {4, 5, 26, 7, 41, 9})]
        public void LinkedList_ContainsItemCheck(int isContain, int[] ints)
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();

            for (int i = 0; i < ints.Length; i++)
            {
                linkedList.Add(ints[i]);
            }

            Assert.IsTrue(linkedList.Contains(isContain));

        }

        [TestMethod]
        [TestCategory("LinkedList")]
        [DataRow(16, new[] {1, 2, 3, 4, 5, 6, 7})]
        [DataRow(0, new[] {32, 12, 1, 54, 8, 15})]
        [DataRow(64, new[] {4, 5, 26, 7, 41, 9})]
        public void LinkedList_NotContainsItemCheck(int isContain, int[] ints)
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();

            for (int i = 0; i < ints.Length; i++)
            {
                linkedList.Add(ints[i]);
            }

            Assert.IsFalse(linkedList.Contains(isContain));

        }

        [TestMethod]
        [TestCategory("LinkedList")]
        [DataRow(16, new[] {1, 2, 3, 4, 5, 6, 7})]
        [DataRow(0, new[] {32, 12, 1, 54, 8, 15})]
        [DataRow(64, new[] {4, 5, 26, 7, 41, 9})]
        public void LinkedList_InsertReferenceCheck(int itemInsert, int[] ints)
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();

            for (int i = 0; i < ints.Length; i++)
            {
                linkedList.Add(ints[i]);
            }
            var expected = linkedList.First.Next.Next;
            linkedList.Insert(2, itemInsert);
            Assert.AreNotSame(expected, linkedList.First.Next.Next);

        }

        [TestMethod]
        [TestCategory("LinkedList")]
        [DataRow(16, new[] {1, 2, 3, 4, 5, 6, 7})]
        [DataRow(0, new[] {32, 12, 1, 54, 8, 15})]
        [DataRow(64, new[] {4, 5, 26, 7, 41, 9})]
        public void LinkedList_InsertItemCheck(int itemInsert, int[] ints)
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();

            for (int i = 0; i < ints.Length; i++)
            {
                linkedList.Add(ints[i]);
            }
            var expected = linkedList.First.Next.Next.Item;
            linkedList.Insert(2, itemInsert);
            Assert.AreNotEqual(expected, linkedList.First.Next.Next.Item);

        }

        [TestMethod]
        [TestCategory("LinkedList")]
        [DataRow(new[] {1, 2, 3, 4, 5, 6, 7})]
        [DataRow(new[] {32, 12, 1, 54, 8, 15})]
        [DataRow(new[] {4, 5, 26, 7, 41, 9})]
        public void LinkedList_ClearTest(int[] ints)
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();

            for (int i = 0; i < ints.Length; i++)
            {
                linkedList.Add(ints[i]);
            }
            linkedList.Clear();

            Assert.AreSame(null, linkedList.First);

        }

        [TestMethod]
        [TestCategory("LinkedList")]
        [DataRow(new[] {1, 2, 3, 4, 5, 6, 7})]
        [DataRow(new[] {32, 12, 1, 54, 8, 15})]
        [DataRow(new[] {4, 5, 26, 7, 41, 9})]
        public void LinkedList_ToArrayTest(int[] ints)
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();

            for (int i = 0; i < ints.Length; i++)
            {
                linkedList.Add(ints[i]);
            }
            var actual = linkedList.ToArray();

            for (int i = 0;i < actual.Length; i++)
                Assert.AreEqual(ints[i], actual[i]);

        }


    }
    
}
