using NUnit.Framework;
using CSharpDataStructures;

namespace Tests
{
    public class SearchTreeFindTest
    {
        SearchTree searchTree;
        int firstKey;
        int firstData;
        int secondKey;
        int secondData;

        [SetUp]
        public void Setup()
        {
            firstKey = 2;
            firstData = 2;
            secondKey = 1;
            secondData = 4;
            searchTree = new SearchTree();
            searchTree.Insert(firstKey, firstData);
            searchTree.Insert(secondKey, secondData);
        }

        [Test]
        public void FindKeyWhichExistsTest()
        {
            DataNode dataFound = searchTree.Find(firstKey);

            Assert.IsNotNull(dataFound);
            Assert.AreEqual(firstData, dataFound.Data);
        }

        [Test]
        public void FindKeyWhichDoesNotExistsTest()
        {
            int searchedKey = 10;

            DataNode dataFound = searchTree.Find(searchedKey);

            Assert.IsNull(dataFound);
        }

        [Test]
        public void FindTwoKeysTest()
        {
            DataNode firstDataFound = searchTree.Find(firstKey);
            DataNode secondDataFound = searchTree.Find(secondKey);

            Assert.IsNotNull(firstDataFound);
            Assert.IsNotNull(secondDataFound);
            Assert.AreEqual(firstData, firstDataFound.Data);
            Assert.AreEqual(secondData, secondDataFound.Data);
        }

        [Test]
        public void FindNewKeyTest()
        {
            int newKey = 7;
            int newData = 9;

            int isNewKeyInsertedCorrectly = searchTree.Insert(newKey, newData);
            DataNode dataFound = searchTree.Find(newKey);

            Assert.Zero(isNewKeyInsertedCorrectly);
            Assert.IsNotNull(dataFound);
            Assert.AreEqual(newData, dataFound.Data);
        }
    }
}
