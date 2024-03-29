﻿using NUnit.Framework;
using CSharpDataStructures;

namespace Tests
{
    public class SearchTreeInsertTest
    {
        SearchTree searchTree;

        [SetUp]
        public void Setup()
        {
            searchTree = new SearchTree();
        }

        [Test]
        public void InsertOneNodeResultTreeIsLeafTest()
        {
            int newKey = 1;
            int newData = 4;

            int isDataInsertedCorrectly = searchTree.Insert(newKey, newData);
            Node treeRoot = searchTree.Tree;
            DataNode treeData = treeRoot.Left as DataNode;

            Assert.AreEqual(0, isDataInsertedCorrectly);
            Assert.AreEqual(1, treeRoot.Key);
            Assert.NotNull(treeRoot.Left);
            Assert.Null(treeRoot.Right);
            Assert.AreEqual(newData, treeData.Data);
            Assert.Null(treeData.Left);
            Assert.Null(treeData.Right);
        }

        [Test]
        public void InsertTwoNodeWithIncreasingKeysResultTreeWithTwoLeavesTest()
        {
            int firstNewKey = 1;
            int firstNewData = 4;
            int secondNewKey = 2;
            int secondNewData = 2;

            int isFirstDataInsertedCorrectly = searchTree.Insert(firstNewKey, firstNewData);
            int isSecondDataInsertedCorrectly = searchTree.Insert(secondNewKey, secondNewData);
            Node treeRoot = searchTree.Tree;
            Node leftLeaf = treeRoot.Left;
            Node rightLeaf = treeRoot.Right;
            DataNode leftLeafDataNode = leftLeaf.Left as DataNode;
            DataNode rightLeafDataNode = rightLeaf.Left as DataNode;

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
            int firstNewKey = 2;
            int firstNewData = 2;
            int secondNewKey = 1;
            int secondNewData = 4;

            int isFirstDataInsertedCorrectly = searchTree.Insert(firstNewKey, firstNewData);
            int isSecondDataInsertedCorrectly = searchTree.Insert(secondNewKey, secondNewData);
            Node treeRoot = searchTree.Tree;
            Node leftLeaf = treeRoot.Left;
            Node rightLeaf = treeRoot.Right;
            DataNode leftLeafDataNode = leftLeaf.Left as DataNode;
            DataNode rightLeafDataNode = rightLeaf.Left as DataNode;

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
            int firstNewKey = 1;
            int firstNewData = 4;
            int secondNewKey = 1;
            int secondNewData = 2;

            int isFirstDataInsertedCorrectly = searchTree.Insert(firstNewKey, firstNewData);
            int isSecondDataInsertedCorrectly = searchTree.Insert(secondNewKey, secondNewData);
            Node treeRoot = searchTree.Tree;
            DataNode leftDataNode = treeRoot.Left as DataNode;

            Assert.Zero(isFirstDataInsertedCorrectly);
            Assert.AreEqual(-1, isSecondDataInsertedCorrectly);
            Assert.AreEqual(firstNewKey, treeRoot.Key);
            Assert.AreEqual(firstNewData, leftDataNode.Data);
            Assert.IsNull(treeRoot.Right);
        }
    }
}
