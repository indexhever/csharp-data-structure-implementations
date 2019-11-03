using System;
using System.Collections.Generic;

namespace CSharpDataStructures
{
    public class SearchTree<TKey, TData> where TKey : IComparable<TKey>
    {
        #region Fields
        private Node<TKey> root;
        private IComparer<TKey> comparer;
        #endregion

        #region Properties
        public Node<TKey> Tree
        {
            get
            {
                return root;
            }
        }
        #endregion

        // TODO: create constructor which receive a comparer
        public SearchTree()
        {
            root = CreateKeyNodeNode();
            comparer = Comparer<TKey>.Default;
        }

        public static KeyNode<TKey> CreateKeyNodeNode()
        {
            return new KeyNode<TKey>();
        }

        public static DataNode<TKey, TData> CreateDataNode(TData data)
        {
            return new DataNode<TKey, TData>(data);
        }

        public int Insert(TKey newKey, TData newData)
        {
            return InsertKeyAndDataIntoTree(newKey, newData, root);
        }

        public DataNode<TKey, TData> Find(TKey queryKey)
        {
            return FindDataWithKeyOnTree(queryKey, root);
        }

        public DataNode<TKey, TData> Delete(TKey queryKey)
        {
            return DeleteKeyOnTree(queryKey, root);
        }

        private int InsertKeyAndDataIntoTree(TKey newKey, TData newData, Node<TKey> tree)
        {
            if (IsTreeEmpty(tree))
            {
                tree.Left = CreateDataNode(newData);
                tree.Key = newKey;
                tree.Right = null;
                return 0;
            }

            return TryInsertKeyAndDataOnBestPositionOfTree(newKey, newData, tree);
        }

        private DataNode<TKey, TData> FindDataWithKeyOnTree(TKey queryKey, Node<TKey> tree)
        {
            if (IsTreeEmpty(tree))
                return null;

            Node<TKey> tempNode = FindNodeOfKeyOnTree(queryKey, tree);
            if (AreKeysEqual(tempNode.Key, queryKey))
                return tempNode.Left as DataNode<TKey, TData>;

            return null;
        }

        private DataNode<TKey, TData> DeleteKeyOnTree(TKey keyToDelete, Node<TKey> tree)
        {
            if (IsTreeEmpty(tree))
                return null;

            if (IsLeafNode(tree))
            {
                if (!AreKeysEqual(tree.Key, keyToDelete))
                    return null;

                DataNode<TKey, TData> deletedData = tree.Left as DataNode<TKey, TData>;
                tree.Left = null;
                return deletedData;
            }

            return DeleteKeyOnTreeAndOrganizeStructure(keyToDelete, tree);
        }

        private int TryInsertKeyAndDataOnBestPositionOfTree(TKey newKey, TData newData, Node<TKey> tree)
        {
            Node<TKey> tempNode = FindNodeOfKeyOnTree(newKey, tree);

            // Not allowed to add key which is alread inside tree
            if (AreKeysEqual(tempNode.Key, newKey))
                return -1;

            Node<TKey> oldLeaf = CreateOldLeafFromNode(tempNode);
            Node<TKey> newLeaf = CreateNewLeafWithKeyAndData(newKey, newData);
            SwitchLeavesOnNodeAccordingToNewKey(oldLeaf, newLeaf, tempNode, newKey);

            return 0;
        }

        private Node<TKey> FindNodeOfKeyOnTree(TKey queryKey, Node<TKey> tree)
        {
            Node<TKey> tempNode = tree;
            while (!IsLeafNode(tempNode))
            {
                tempNode = FindNewDirectionOnTreeWithKey(tempNode, queryKey);
            }
            return tempNode;
        }

        private DataNode<TKey, TData> DeleteKeyOnTreeAndOrganizeStructure(TKey keyToDelete, Node<TKey> tree)
        {
            Node<TKey> tempNode = null, upperNode = null, otherNode = null;
            tempNode = tree;
            while (!IsLeafNode(tempNode))
            {
                upperNode = tempNode;
                if (CompareKeys(keyToDelete, tempNode.Key) < 0)
                {
                    tempNode = upperNode.Left;
                    otherNode = upperNode.Right;
                }
                else
                {
                    tempNode = upperNode.Right;
                    otherNode = upperNode.Left;
                }
            }

            if (!AreKeysEqual(tempNode.Key, keyToDelete))
                return null;

            upperNode.Key = otherNode.Key;
            upperNode.Left = otherNode.Left;
            upperNode.Right = otherNode.Right;
            // TODO: Implement stack of free nodes to be reused after deleting one
            //ReturnNode(tempNode);
            //ReturnNode(otherNode);
            return tempNode.Left as DataNode<TKey, TData>;
        }

        private Node<TKey> FindNewDirectionOnTreeWithKey(Node<TKey> node, TKey queryKey)
        {
            if (CompareKeys(queryKey, node.Key) < 0)
                node = node.Left;
            else
                node = node.Right;
            return node;
        }

        private Node<TKey> CreateOldLeafFromNode(Node<TKey> node)
        {
            Node<TKey> oldLeaf = CreateKeyNodeNode();
            oldLeaf.Left = node.Left;
            oldLeaf.Key = node.Key;
            oldLeaf.Right = null;
            return oldLeaf;
        }

        private Node<TKey> CreateNewLeafWithKeyAndData(TKey newKey, TData newData)
        {
            Node<TKey> newLeaf = CreateKeyNodeNode();
            newLeaf.Left = CreateDataNode(newData);
            newLeaf.Key = newKey;
            newLeaf.Right = null;
            return newLeaf;
        }

        private void SwitchLeavesOnNodeAccordingToNewKey(Node<TKey> oldLeaf, Node<TKey> newLeaf, Node<TKey> node, TKey newKey)
        {
            int order = CompareKeys(node.Key, newKey);
            if (order < 0)
            {
                node.Left = oldLeaf;
                node.Right = newLeaf;
                node.Key = newKey;
            }
            else
            {
                node.Left = newLeaf;
                node.Right = oldLeaf;
            }
        }

        public bool IsEmpty()
        {
            return IsTreeEmpty(root);
        }

        private bool IsTreeEmpty(Node<TKey> tree)
        {
            return tree.Left == null;
        }

        private bool IsLeafNode(Node<TKey> tempNode)
        {
            return tempNode.Right == null;
        }

        private bool AreKeysEqual(TKey firstKey, TKey secondKey)
        {
            return CompareKeys(firstKey, secondKey) == 0;
        }

        private int CompareKeys(TKey firstKey, TKey secondKey)
        {
            return comparer.Compare(firstKey, secondKey);
        }
    }
}