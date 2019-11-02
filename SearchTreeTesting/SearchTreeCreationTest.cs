using NUnit.Framework;
using CSharpDataStructures;

namespace Tests
{
    public class SearchTreeCreationTest
    {
        SearchTree searchTree;

        [SetUp]
        public void Setup()
        {
            searchTree = new SearchTree();
        }

        [Test]
        public void CreateKeyNodeTest()
        {
            KeyNode node = new KeyNode();
            node.Key = 1;
            node.Left = new KeyNode();
            node.Right = new KeyNode();

            Assert.AreEqual(1, node.Key);
            Assert.AreNotEqual(null, node.Left);
            Assert.AreNotEqual(null, node.Right);
        }

        [Test]
        public void CreateSearchTreeNodeTest()
        {
            Node node = SearchTree.CreateKeyNodeNode();

            Assert.AreEqual(null, node.Left);
        }

        [Test]
        public void CreateEmptyTreeTest()
        {
            Assert.IsTrue(searchTree.IsEmpty());
        }

        [Test]
        public void CreateDataNodeTest()
        {
            DataNode dataNode = SearchTree.CreateDataNode(1);

            Assert.AreEqual(1, dataNode.Data);
        }
    }
}