using System;
using CSharpDataStructures;

namespace CSharpDataStructures
{
    public class SearchTree<TKey, TData>
    {
        #region Fields
        private Node<TKey> root;
        #endregion

        public SearchTree()
        {
            root = CreateKeyNodeNode();
        }

        public static KeyNode<TKey> CreateKeyNodeNode()
        {
            return new KeyNode<TKey>();
        }

        public static DataNode<TKey, TData> CreateDataNode(TData data)
        {
            return new DataNode<TKey, TData>(data);
        }

        public bool IsEmpty()
        {
            return IsTreeEmpty(root);
        }

        private bool IsTreeEmpty(Node<TKey> tree)
        {
            return tree.Left == null;
        }
    }
}