using NUnit.Framework;
using CSharpDataStructures;

namespace Tests
{
    public class SearchTreeTest
    {
        SearchTree searchTree;

        [SetUp]
        public void Setup()
        {
            searchTree = new SearchTree();
        }

        [Test]
        public void CreateNodeTest()
        {
            Node node = new Node();
            node.Key = 1;
            node.Left = new Node();
            node.Right = new Node();

            Assert.AreEqual(1, node.Key);
            Assert.AreNotEqual(null, node.Left);
            Assert.AreNotEqual(null, node.Right);
        }

        [Test]
        public void CreateSearchTreeNodeTest()
        {
            Node node = SearchTree.CreateNode();
            Assert.AreEqual(null, node.Left);
        }

        [Test]
        public void CreateEmptyTreeTest()
        {
            Assert.IsTrue(searchTree.IsEmpty());
        }
    }
}