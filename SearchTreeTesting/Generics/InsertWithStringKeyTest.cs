using NUnit.Framework;
using CSharpDataStructures;

namespace Tests.Generics
{
    class InsertWithStringKeyTest
    {
        SearchTree<string, int> searchTree;

        [SetUp]
        public void Setup()
        {
            searchTree = new SearchTree<string, int>();
        }

        [Test]
        public void InsertOneNodeResultTreeIsLeafTest()
        {
            string newKey = "alan";
            int newData = 4;

            int isDataInsertedCorrectly = searchTree.Insert(newKey, newData);
            Node<string> treeRoot = searchTree.Tree;
            DataNode<string, int> treeData = treeRoot.Left as DataNode<string, int>;

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
            string firstNewKey = "alan";
            int firstNewData = 4;
            string secondNewKey = "jordan";
            int secondNewData = 2;

            int isFirstDataInsertedCorrectly = searchTree.Insert(firstNewKey, firstNewData);
            int isSecondDataInsertedCorrectly = searchTree.Insert(secondNewKey, secondNewData);
            Node<string> treeRoot = searchTree.Tree;
            Node<string> leftLeaf = treeRoot.Left;
            Node<string> rightLeaf = treeRoot.Right;
            DataNode<string, int> leftLeafDataNode = leftLeaf.Left as DataNode<string, int>;
            DataNode<string, int> rightLeafDataNode = rightLeaf.Left as DataNode<string, int>;

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
            string firstNewKey = "jordan";
            int firstNewData = 2;
            string secondNewKey = "alan";
            int secondNewData = 4;

            int isFirstDataInsertedCorrectly = searchTree.Insert(firstNewKey, firstNewData);
            int isSecondDataInsertedCorrectly = searchTree.Insert(secondNewKey, secondNewData);
            Node<string> treeRoot = searchTree.Tree;
            Node<string> leftLeaf = treeRoot.Left;
            Node<string> rightLeaf = treeRoot.Right;
            DataNode<string, int> leftLeafDataNode = leftLeaf.Left as DataNode<string, int>;
            DataNode<string, int> rightLeafDataNode = rightLeaf.Left as DataNode<string, int>;

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
            string firstNewKey = "alan";
            int firstNewData = 4;
            string secondNewKey = "alan";
            int secondNewData = 2;

            int isFirstDataInsertedCorrectly = searchTree.Insert(firstNewKey, firstNewData);
            int isSecondDataInsertedCorrectly = searchTree.Insert(secondNewKey, secondNewData);
            Node<string> treeRoot = searchTree.Tree;
            DataNode<string, int> leftDataNode = treeRoot.Left as DataNode<string, int>;

            Assert.Zero(isFirstDataInsertedCorrectly);
            Assert.AreEqual(-1, isSecondDataInsertedCorrectly);
            Assert.AreEqual(firstNewKey, treeRoot.Key);
            Assert.AreEqual(firstNewData, leftDataNode.Data);
            Assert.IsNull(treeRoot.Right);
        }
    }
}
