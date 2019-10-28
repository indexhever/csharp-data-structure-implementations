using System;

namespace CSharpDataStructures
{
    public class SearchTree
    {
        #region Fields
        private Node root;
        #endregion

        #region Properties
        public Node Tree
        {
            get
            {
                return root;
            }
        }
        #endregion

        public SearchTree()
        {
            root = CreateKeyNodeNode();
        }

        public static KeyNode CreateKeyNodeNode()
        {
            return new KeyNode();
        }

        public static DataNode CreateDataNode(int data)
        {
            return new DataNode(data);
        }

        public int Insert(int newKey, int newData)
        {
            return InsertKeyAndDataIntoTree(newKey, newData, root);
        }

        public DataNode Find(int searchedKey)
        {
            return FindDataWithKeyOnTree(searchedKey, root);
        }

        public DataNode Delete(int queryKey)
        {
            return DeleteKeyOnTree(queryKey, root);
        }

        public int InsertKeyAndDataIntoTree(int newKey, int newData, Node tree)
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

        private int TryInsertKeyAndDataOnBestPositionOfTree(int newKey, int newData, Node tree)
        {
            Node tempNode = FindNodeOfKeyOnTree(newKey, tree);

            // Not allowed to add key which is alread inside tree
            if (tempNode.Key == newKey)
                return -1;

            Node oldLeaf = CreateOldLeafFromNode(tempNode);
            Node newLeaf = CreateNewLeafWithKeyAndData(newKey, newData);
            SwitchLeavesOnNodeAccordingToNewKey(oldLeaf, newLeaf, tempNode, newKey);

            return 0;
        }

        private Node CreateNewLeafWithKeyAndData(int newKey, int newData)
        {
            Node newLeaf = CreateKeyNodeNode();
            newLeaf.Left = CreateDataNode(newData);
            newLeaf.Key = newKey;
            newLeaf.Right = null;
            return newLeaf;
        }

        private Node CreateOldLeafFromNode(Node node)
        {
            Node oldLeaf = CreateKeyNodeNode();
            oldLeaf.Left = node.Left;
            oldLeaf.Key = node.Key;
            oldLeaf.Right = null;
            return oldLeaf;
        }

        private void SwitchLeavesOnNodeAccordingToNewKey(Node oldLeaf, Node newLeaf, Node node, int newKey)
        {
            if (node.Key < newKey)
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

        private DataNode FindDataWithKeyOnTree(int queryKey, Node tree)
        {
            if (IsTreeEmpty(tree))
                return null;

            Node tempNode = FindNodeOfKeyOnTree(queryKey, tree);
            if (tempNode.Key == queryKey)
                return tempNode.Left as DataNode;

            return null;
        }

        private DataNode DeleteKeyOnTree(int keyToDelete, Node tree)
        {
            if (IsTreeEmpty(tree))
                return null;

            DataNode deletedData;
            Node tempNode = null, upperNode = null, otherNode = null;            

            if (IsLeafNode(tree))
            {
                if (tree.Key != keyToDelete)
                    return null;

                deletedData = tree.Left as DataNode;
                tree.Left = null;
                return deletedData;
            }

            tempNode = tree;
            while (!IsLeafNode(tempNode))
            {
                upperNode = tempNode;
                if(keyToDelete < tempNode.Key)
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

            if (tempNode.Key != keyToDelete)
                return null;

            upperNode.Key = otherNode.Key;
            upperNode.Left = otherNode.Left;
            upperNode.Right = otherNode.Right;
            deletedData = tempNode.Left as DataNode;
            // TODO: Implement stack of free nodes to be reused after deleting one
            //ReturnNode(tempNode);
            //ReturnNode(otherNode);
            return deletedData;
        }

        public bool IsEmpty()
        {
            return IsTreeEmpty(root);
        }

        private bool IsTreeEmpty(Node tree)
        {
            return tree.Left == null;
        }

        private bool IsLeafNode(Node tempNode)
        {
            return tempNode.Right == null;
        }

        private Node FindNodeOfKeyOnTree(int queryKey, Node tree)
        {
            Node tempNode = tree;
            while (!IsLeafNode(tempNode))
            {
                tempNode = FindNewDirectionOnTreeWithKey(tempNode, queryKey);
            }
            return tempNode;
        }

        private Node FindNewDirectionOnTreeWithKey(Node node, int searchKey)
        {
            if (searchKey < node.Key)
                node = node.Left;
            else
                node = node.Right;
            return node;
        }
    }
}