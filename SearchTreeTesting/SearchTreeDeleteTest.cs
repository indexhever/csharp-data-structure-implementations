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
    }
}
