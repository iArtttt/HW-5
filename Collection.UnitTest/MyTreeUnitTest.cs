using Interface.MyCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection.UnitTest
{
    [TestClass]
    public class MyTreeUnitTest
    {
        [TestMethod]
        [TestCategory("Tree")]
        public void MyTree_AddFrom1to5_CountCheck()
        {
            MyTree<int> ints = new MyTree<int>();

            ints.Add(1);
            Assert.AreEqual(1, ints.Count);

            ints.Add(2);
            Assert.AreEqual(2, ints.Count);

            ints.Add(3);
            Assert.AreEqual(3, ints.Count);

            ints.Add(4);
            Assert.AreEqual(4, ints.Count);

            ints.Add(5);
            Assert.AreEqual(5, ints.Count);

        }

        [TestMethod]
        [TestCategory("Tree")]
        [DataRow(5, new []{5, 1, 4, 7, 9, 52, 2})]
        [DataRow(11, new []{11, 54, 66, 4, 5, 90})]
        [DataRow(67, new []{67, 13, 2, 97, 93, 12, 23})]
        public void MyTree_Test_RootItemCheck(int expectedRoot, int[] ints)
        {
            MyTree<int> myTree = new MyTree<int>();
            
            for (int i = 0; i < ints.Length; i++)
            {
                myTree.Add(ints[i]);
            }
            
            Assert.AreEqual(expectedRoot, myTree.Root.Item);

        }

        [TestMethod]
        [TestCategory("Tree")]
        [DataRow(new[] { 1, 2, 4, 5 ,7, 9, 52, }, new []{5, 1, 4, 7, 9, 52, 2})]
        [DataRow(new[] { 4, 5, 11, 54, 66, 90 }, new []{11, 54, 66, 4, 5, 90})]
        [DataRow(new[] { 2, 12, 13, 23, 67, 93, 97 }, new []{67, 13, 2, 97, 93, 12, 23})]
        public void MyTree_Test_ToArray(int[] expectedArray, int[] ints)
        {
            MyTree<int> myTree = new MyTree<int>();
            
            for (int i = 0; i < ints.Length; i++)
            {
                myTree.Add(ints[i]);
            }
            var actualArray = myTree.ToArray();
            for (int i = 0; i < actualArray.Length; i++)
            {
                Assert.AreEqual(expectedArray[i], actualArray[i]);
            }

        }

        [TestMethod]
        [TestCategory("Tree")]
        [DataRow(9, new[] { 5, 1, 4, 7, 9, 52, 2 })]
        [DataRow(54, new[] { 11, 54, 66, 4, 5, 90 })]
        [DataRow(67, new[] { 67, 13, 2, 97, 93, 12, 23 })]
        public void MyTree_Test_ContainsTrue(int expectedContainsTrue, int[] ints)
        {
            MyTree<int> myTree = new MyTree<int>();

            for (int i = 0; i < ints.Length; i++)
            {
                myTree.Add(ints[i]);
            }

            Assert.IsTrue(myTree.Contains(expectedContainsTrue));

        }

        [TestMethod]
        [TestCategory("Tree")]
        [DataRow(3, new[] { 5, 1, 4, 7, 9, 52, 2 })]
        [DataRow(64, new[] { 11, 54, 66, 4, 5, 90 })]
        [DataRow(50, new[] { 67, 13, 2, 97, 93, 12, 23 })]
        public void MyTree_Test_ContainsFalse(int expectedContainsFalse, int[] ints)
        {
            MyTree<int> myTree = new MyTree<int>();

            for (int i = 0; i < ints.Length; i++)
            {
                myTree.Add(ints[i]);
            }

            Assert.IsFalse(myTree.Contains(expectedContainsFalse));

        }
    }
}
