using NUnit.Framework;
using CSharpDataStructures;

namespace Tests.Generics
{
    class CreationTest
    {
        [Test]
        public void CreateKeyNodeTest()
        {
            KeyNode<int> node = new KeyNode<int>();
            node.Key = 1;
            node.Left = new KeyNode<int>();
            node.Right = new KeyNode<int>();

            Assert.AreEqual(1, node.Key);
            Assert.AreNotEqual(null, node.Left);
            Assert.AreNotEqual(null, node.Right);
        }

        [Test]
        public void CreateSearchTreeNodeTest()
        {
            Node<int> node = SearchTree<int, int>.CreateKeyNodeNode();

            Assert.AreEqual(null, node.Left);
        }

        [Test]
        public void CreateEmptyTreeTest()
        {
            SearchTree<int, int> searchTree = new SearchTree<int, int>();

            Assert.IsTrue(searchTree.IsEmpty());
        }

        [Test]
        public void CreateDataNodeTest()
        {
            DataNode<int, int> dataNode = SearchTree<int, int>.CreateDataNode(1);

            Assert.AreEqual(1, dataNode.Data);
        }
    }
}
