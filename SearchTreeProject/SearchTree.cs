using System;

namespace CSharpDataStructures
{
    public class SearchTree
    {
        private Node root;

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

        public bool IsEmpty()
        {
            return root.Left == null;
        }        
    }
}