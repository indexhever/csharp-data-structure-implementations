using NUnit.Framework;
using CSharpDataStructures;
using System;

namespace Tests.Generics
{
    class DeleteWithAllTypesOfKeys
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
        public void DeleteKeyWhichExistsTest()
        {
            Wallet queryKey = firstKey;

            DataNode<Wallet, int> deletedData = searchTree.Delete(queryKey);

            Assert.IsNotNull(deletedData);
            Assert.AreEqual(firstData, deletedData.Data);
        }

        [Test]
        public void DeleteKeyWhichDoesNotExistsTest()
        {
            Wallet queryKey = new Wallet(10);

            DataNode<Wallet, int> deletedData = searchTree.Delete(queryKey);

            Assert.IsNull(deletedData);
        }

        [Test]
        public void FinalStructureOrganizationAfterDeleteFirstKeyTest()
        {
            Wallet queryKey = firstKey;
            Node<Wallet> oldRoot = searchTree.Tree;
            Node<Wallet> oldRootLeftNode = oldRoot.Left;

            DataNode<Wallet, int> deletedData = searchTree.Delete(queryKey);
            Node<Wallet> newRoot = searchTree.Tree;
            DataNode<Wallet, int> newRootData = newRoot.Left as DataNode<Wallet, int>;
            Node<Wallet> newRootRightNode = newRoot.Right;

            Assert.IsNotNull(deletedData);
            Assert.AreEqual(secondKey, newRoot.Key);
            Assert.IsNotNull(newRootData);
            Assert.AreEqual(secondData, newRootData.Data);
            Assert.IsNull(newRootRightNode);
        }

        [Test]
        public void FinalStructureOrganizationAfterDeleteSecondKeyTest()
        {
            Wallet queryKey = secondKey;
            Node<Wallet> oldRoot = searchTree.Tree;
            Node<Wallet> oldRootRightNode = oldRoot.Right;

            DataNode<Wallet, int> deletedData = searchTree.Delete(queryKey);
            Node<Wallet> newRoot = searchTree.Tree;
            DataNode<Wallet, int> newRootData = newRoot.Left as DataNode<Wallet, int>;
            Node<Wallet> newRootRightNode = newRoot.Right;

            Assert.IsNotNull(deletedData);
            Assert.AreEqual(firstKey, newRoot.Key);
            Assert.IsNotNull(newRootData);
            Assert.AreEqual(firstData, newRootData.Data);
            Assert.IsNull(newRootRightNode);
        }

        [Test]
        public void DeleteLeafRootTest()
        {
            SearchTree<Wallet, int> leafSearchTree = new SearchTree<Wallet, int>();
            leafSearchTree.Insert(secondKey, secondData);
            Wallet queryKey = secondKey;

            DataNode<Wallet, int> deletedData = leafSearchTree.Delete(queryKey);
            Node<Wallet> newTree = leafSearchTree.Tree;

            Assert.IsNotNull(deletedData);
            Assert.AreEqual(secondData, deletedData.Data);
            Assert.IsNull(newTree.Left);
            Assert.IsNull(newTree.Right);
        }
    }
}
