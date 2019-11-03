using NUnit.Framework;
using CSharpDataStructures;
using System;

namespace Tests.Generics
{
    class GenericSearchTreeInsertWithAllTypeOfKeyTest
    {
        class Wallet : IComparable<Wallet>
        {
            private double money;

            public Wallet(float money)
            {
                this.money = money;
            }
            
            public int CompareTo(Wallet other)
            {
                if (money < other.money)
                    return -1;
                if (money > other.money)
                    return 1;

                return 0;
            }
        }

        SearchTree<Wallet, string> searchTree;

        [SetUp]
        public void Setup()
        {
            searchTree = new SearchTree<Wallet, string>();
        }

        [Test]
        public void InsertOneNodeResultTreeIsLeafTest()
        {
            Wallet newKey = new Wallet(1);
            string newData = "Allan";

            int isDataInsertedCorrectly = searchTree.Insert(newKey, newData);
            Node<Wallet> treeRoot = searchTree.Tree;
            DataNode<Wallet, string> treeData = treeRoot.Left as DataNode<Wallet, string>;

            Assert.AreEqual(0, isDataInsertedCorrectly);
            Assert.AreEqual(newKey, treeRoot.Key);
            Assert.NotNull(treeRoot.Left);
            Assert.Null(treeRoot.Right);
            Assert.AreEqual(newData, treeData.Data);
            Assert.Null(treeData.Left);
            Assert.Null(treeData.Right);
        }

        [Test]
        public void InsertTwoNodeWithIncreasingKeysResultTreeWithTwoLeavesTest()
        {
            Wallet firstNewKey = new Wallet(1);
            string firstNewData = "Allan";
            Wallet secondNewKey = new Wallet(2);
            string secondNewData = "Jose";

            int isFirstDataInsertedCorrectly = searchTree.Insert(firstNewKey, firstNewData);
            int isSecondDataInsertedCorrectly = searchTree.Insert(secondNewKey, secondNewData);
            Node<Wallet> treeRoot = searchTree.Tree;
            Node<Wallet> leftLeaf = treeRoot.Left;
            Node<Wallet> rightLeaf = treeRoot.Right;
            DataNode<Wallet, string> leftLeafDataNode = leftLeaf.Left as DataNode<Wallet, string>;
            DataNode<Wallet, string> rightLeafDataNode = rightLeaf.Left as DataNode<Wallet, string>;

            Assert.Zero(isFirstDataInsertedCorrectly);
            Assert.Zero(isSecondDataInsertedCorrectly);
            Assert.AreEqual(secondNewKey, treeRoot.Key);
            Assert.AreEqual(firstNewKey, leftLeaf.Key);
            Assert.AreEqual(secondNewKey, rightLeaf.Key);
            Assert.AreEqual(firstNewData, leftLeafDataNode.Data);
            Assert.AreEqual(secondNewData, rightLeafDataNode.Data);
        }

        [Test]
        public void InsertTwoNodeWithDecreasingKeysResultTreeWithTwoLeavesTest()
        {
            Wallet firstNewKey = new Wallet(2);
            string firstNewData = "Jordan";
            Wallet secondNewKey = new Wallet(1);
            string secondNewData = "Allan";

            int isFirstDataInsertedCorrectly = searchTree.Insert(firstNewKey, firstNewData);
            int isSecondDataInsertedCorrectly = searchTree.Insert(secondNewKey, secondNewData);
            Node<Wallet> treeRoot = searchTree.Tree;
            Node<Wallet> leftLeaf = treeRoot.Left;
            Node<Wallet> rightLeaf = treeRoot.Right;
            DataNode<Wallet, string> leftLeafDataNode = leftLeaf.Left as DataNode<Wallet, string>;
            DataNode<Wallet, string> rightLeafDataNode = rightLeaf.Left as DataNode<Wallet, string>;

            Assert.Zero(isFirstDataInsertedCorrectly);
            Assert.Zero(isSecondDataInsertedCorrectly);
            Assert.AreEqual(firstNewKey, treeRoot.Key);
            Assert.AreEqual(secondNewKey, leftLeaf.Key);
            Assert.AreEqual(firstNewKey, rightLeaf.Key);
            Assert.AreEqual(secondNewData, leftLeafDataNode.Data);
            Assert.AreEqual(firstNewData, rightLeafDataNode.Data);
        }

        [Test]
        public void InsertKeyWhichExistsOnTreeResultZeroTest()
        {
            Wallet firstNewKey = new Wallet(2);
            string firstNewData = "joao";
            Wallet secondNewKey = new Wallet(2);
            string secondNewData = "allan";

            int isFirstDataInsertedCorrectly = searchTree.Insert(firstNewKey, firstNewData);
            int isSecondDataInsertedCorrectly = searchTree.Insert(secondNewKey, secondNewData);
            Node<Wallet> treeRoot = searchTree.Tree;
            DataNode<Wallet, string> leftDataNode = treeRoot.Left as DataNode<Wallet, string>;

            Assert.Zero(isFirstDataInsertedCorrectly);
            Assert.AreEqual(-1, isSecondDataInsertedCorrectly);
            Assert.AreEqual(firstNewKey, treeRoot.Key);
            Assert.AreEqual(firstNewData, leftDataNode.Data);
            Assert.IsNull(treeRoot.Right);
        }
    }
}
