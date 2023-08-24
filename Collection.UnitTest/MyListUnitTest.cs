using Interface.MyCollection;

namespace Collection.UnitTest
{
    [TestClass]
    public class MyListUnitTest
    {
        [TestMethod]
        [TestCategory("List")]
        [TestCategory("List Methods")]
        public void List_Test_Add()
        {
            MyList<int> myList = new();
            
            myList.Add(1);
            Assert.AreEqual(1, myList[myList.Count-1]);
            
            myList.Add(2);
            Assert.AreEqual(2, myList[myList.Count-1]);
            
            myList.Add(3);
            Assert.AreEqual(3, myList[myList.Count-1]);
            
            myList.Add(4);
            Assert.AreEqual(4, myList[myList.Count-1]);
            
            myList.Add(5);
            Assert.AreEqual(5, myList[myList.Count-1]);
            
            myList.Add(6);
            Assert.AreEqual(6, myList[myList.Count-1]);
            
            myList.Add(7);
            Assert.AreEqual(7, myList[myList.Count-1]);
            
            myList.Add(8);
            Assert.AreEqual(8, myList[myList.Count-1]);
            
            myList.Add(9);
            Assert.AreEqual(9, myList[myList.Count-1]);
            
            myList.Add(10);    
            Assert.AreEqual(10, myList[myList.Count-1]);

            Assert.AreEqual(10, myList.Count);
        }
        
        [TestMethod]
        [TestCategory("List")]
        [TestCategory("List Methods")]
        [DataRow(1)]
        [DataRow(4)]
        [DataRow(10)]
        public void List_Remove_One_Four_Ten(int toRemove)
        {
            MyList<int> myList = new()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            myList.Remove(toRemove);

            Assert.AreNotEqual(toRemove, myList[toRemove - 1]);
        }
        
        
        [TestMethod]
        [TestCategory("List")]
        [TestCategory("List Methods")]
        [DataRow(1)]
        [DataRow(4)]
        [DataRow(9)]
        public void List_RemoveAt_One_Four_Ten(int toRemoveAt)
        {
            MyList<int> myList = new()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            myList.RemoveAt(toRemoveAt);

            Assert.AreNotEqual(toRemoveAt + 1, myList[toRemoveAt]);
        }
        
        [TestMethod]
        [TestCategory("List")]
        [TestCategory("List Methods")]
        [DataRow(2, 3)]
        [DataRow(5, 1)]
        [DataRow(0, 9)]
        public void List_Insert_Three_One_Nine(int position, int toInsert)
        {
            MyList<int> myList = new()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            myList.Insert(position, toInsert);

            Assert.AreEqual(toInsert, myList[position]);
        }
        
        [TestMethod]
        [TestCategory("List")]
        [TestCategory("List Methods")]
        [DataRow(2, 1)]
        [DataRow(5, 4)]
        [DataRow(8, 7)]
        public void List_IndexOf_Three_One_Nine(int value, int atIndex)
        {
            MyList<int> myList = new()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            var actual = myList.IndexOf(value);

            Assert.AreEqual(myList[atIndex], myList[actual]);
        }

        [TestMethod]
        [TestCategory("List")]
        [TestCategory("List Methods")]
        [DataRow(3)]
        [DataRow(1)]
        [DataRow(9)]
        public void List_Contains_Three_One_Nine(int isContain)
        {
            MyList<int> myList = new()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            myList.Contains(isContain);

            Assert.IsTrue(myList.Contains(isContain));
        }

        [TestMethod]
        [TestCategory("List")]
        [TestCategory("List Methods")]
        [DataRow(0)]
        [DataRow(5)]
        [DataRow(11)]
        public void List_NotContains_Zero_Five_Eleven(int isContain)
        {
            MyList<int> myList = new()
            {
                1, 2, 3, 4, 6, 7, 8, 9, 10
            };

            myList.Contains(isContain);

            Assert.IsFalse(myList.Contains(isContain));
        }

        [TestMethod]
        [TestCategory("List")]
        [TestCategory("List Methods")]
        [DataRow(0)]
        [DataRow(5)]
        [DataRow(11)]
        public void List_Reverse(int isContain)
        {
            MyList<int> myList = new()
            {
                1, 2, 3, 4, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21
            };

            myList.Reverse();

            Assert.AreEqual(21, myList[0]);
        }


        [TestMethod]
        [TestCategory("List")]
        [TestCategory("List Methods")]
        public void List_Sort()
        {
            MyList<int> myList = new()
            {
                3, 7, 1, 2, 8, 10, 6, 4, 9, 5
            };

            myList.Sort();

            for (int i = 0; i < myList.Count; i++)
            {
                Assert.AreEqual(i + 1, myList[i]);
            }
        }


        [TestMethod]
        [TestCategory("List")]
        [TestCategory("List Methods")]
        [DataRow(3, 2)]
        [DataRow(1, 0)]
        [DataRow(10, 9)]
        public void List_BinarySearch(int findItem, int expectedIndex)
        {
            MyList<int> myList = new()
            {
                3, 7, 1, 2, 8, 10, 6, 4, 9, 5
            };

            var actualIndex = myList.BinarySearch(findItem);

            Assert.AreEqual(expectedIndex, actualIndex);
            
        }
        

        [TestMethod]
        [TestCategory("List")]
        [TestCategory("List Methods")]
        public void List_ToArray()
        {
            MyList<int> myList = new()
            {
                3, 7, 1, 2, 8, 10, 6, 4, 9, 5
            };

            var result = myList.ToArray();

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(myList[i], result[i]);
            }

            Assert.AreEqual(myList.Count, result.Length);
        }

        [TestMethod]
        [TestCategory("List")]
        [TestCategory("List Methods")]
        public void List_Clear()
        {
            MyList<int> myList = new()
            {
                3, 7, 1, 2, 8, 10, 6, 4, 9, 5
            };

            myList.Clear();

            Assert.AreEqual(0, myList.Count);

        }

        [TestMethod]
        [TestCategory("List")]
        [TestCategory("List Property")]
        public void List_Count()
        {
            MyList<int> myList = new()
            {
                3, 7, 1, 2, 8, 10, 6, 4, 9, 5
            };

            Assert.AreEqual(10, myList.Count);

        }
        
        [TestMethod]
        [TestCategory("List")]
        [TestCategory("List Property")]
        public void List_Capacity()
        {
            MyList<int> myList = new()
            {
                3, 7, 1, 2, 8, 10, 6, 4, 9, 5
            };

            Assert.AreEqual(16, myList.Capañity);

        }
    }
}