using NUnit.Framework;
using CSharpDataStructures;

namespace Tests
{
    class SearchTreeDeleteTest
    {
        SearchTree searchTree;
        int firstKey;
        int firstData;
        int secondKey;
        int secondData;

        [SetUp]
        public void Setup()
        {
            searchTree = new SearchTree();
            firstKey = 2;
            firstData = 2;
            secondKey = 1;
            secondData = 4;
            searchTree.Insert(firstKey, firstData);
            searchTree.Insert(secondKey, secondData);
        }

        [Test]
        public void DeleteKeyWhichExistsTest()
        {
            int queryKey = firstKey;

            DataNode deletedData = searchTree.Delete(queryKey);

            Assert.IsNotNull(deletedData);
            Assert.AreEqual(firstData, deletedData.Data);
        }

        [Test]
        public void DeleteKeyWhichDoesNotExistsTest()
        {
            int queryKey = 10;

            DataNode deletedData = searchTree.Delete(queryKey);

            Assert.IsNull(deletedData);
        }

        [Test]
        public void FinalStructureOrganizationAfterDeleteFirstKeyTest()
        {
            int queryKey = firstKey;
            Node oldRoot = searchTree.Tree;
            Node oldRootLeftNode = oldRoot.Left;

            DataNode deletedData = searchTree.Delete(queryKey);
            Node newRoot = searchTree.Tree;
            DataNode newRootData = newRoot.Left as DataNode;
            Node newRootRightNode = newRoot.Right;

            Assert.IsNotNull(deletedData);
            Assert.AreEqual(secondKey, newRoot.Key);
            Assert.IsNotNull(newRootData);
            Assert.AreEqual(secondData, newRootData.Data);
            Assert.IsNull(newRootRightNode);
        }

        [Test]
        public void FinalStructureOrganizationAfterDeleteSecondKeyTest()
        {
            int queryKey = secondKey;
            Node oldRoot = searchTree.Tree;
            Node oldRootRightNode = oldRoot.Right;

            DataNode deletedData = searchTree.Delete(queryKey);
            Node newRoot = searchTree.Tree;
            DataNode newRootData = newRoot.Left as DataNode;
            Node newRootRightNode = newRoot.Right;

            Assert.IsNotNull(deletedData);
            Assert.AreEqual(firstKey, newRoot.Key);
            Assert.IsNotNull(newRootData);
            Assert.AreEqual(firstData, newRootData.Data);
            Assert.IsNull(newRootRightNode);
        }

        [Test]
        public void DeleteLeafRootTest()
        {
            SearchTree leafSearchTree = new SearchTree();
            leafSearchTree.Insert(secondKey, secondData);
            int queryKey = secondKey;

            DataNode deletedData = leafSearchTree.Delete(queryKey);
            Node newTree = leafSearchTree.Tree;

            Assert.IsNotNull(deletedData);
            Assert.AreEqual(secondData, deletedData.Data);
            Assert.IsNull(newTree.Left);
            Assert.IsNull(newTree.Right);
        }
    }
}
