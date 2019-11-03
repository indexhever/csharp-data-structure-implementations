using NUnit.Framework;
using CSharpDataStructures;
using System;

namespace Tests.Generics
{
    class FindWithAllTypesOfKeyTest
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

        SearchTree<Wallet, int> searchTree;
        Wallet firstKey;
        int firstData;
        Wallet secondKey;
        int secondData;

        [SetUp]
        public void Setup()
        {
            searchTree = new SearchTree<Wallet, int>();
            firstKey = new Wallet(2);
            firstData = 2;
            secondKey = new Wallet(1);
            secondData = 4;
            searchTree.Insert(firstKey, firstData);
            searchTree.Insert(secondKey, secondData);
        }

        [Test]
        public void FindKeyWhichExistsTest()
        {
            DataNode<Wallet, int> dataFound = searchTree.Find(firstKey);

            Assert.IsNotNull(dataFound);
            Assert.AreEqual(firstData, dataFound.Data);
        }

        [Test]
        public void FindKeyWhichDoesNotExistsTest()
        {
            Wallet searchedKey = new Wallet(10);

            DataNode<Wallet, int> dataFound = searchTree.Find(searchedKey);

            Assert.IsNull(dataFound);
        }

        [Test]
        public void FindTwoKeysTest()
        {
            DataNode<Wallet, int> firstDataFound = searchTree.Find(firstKey);
            DataNode<Wallet, int> secondDataFound = searchTree.Find(secondKey);

            Assert.IsNotNull(firstDataFound);
            Assert.IsNotNull(secondDataFound);
            Assert.AreEqual(firstData, firstDataFound.Data);
            Assert.AreEqual(secondData, secondDataFound.Data);
        }

        [Test]
        public void FindNewKeyTest()
        {
            Wallet newKey = new Wallet(7);
            int newData = 9;

            int isNewKeyInsertedCorrectly = searchTree.Insert(newKey, newData);
            DataNode<Wallet, int> dataFound = searchTree.Find(newKey);

            Assert.Zero(isNewKeyInsertedCorrectly);
            Assert.IsNotNull(dataFound);
            Assert.AreEqual(newData, dataFound.Data);
        }
    }
}
