using NUnit.Framework;
using CSharpDataStructures;

namespace Tests
{
    public class SearchTreeTest
    {
        [SetUp]
        public void Setup()
        {
            
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
    }
}