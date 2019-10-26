using System;

namespace CSharpDataStructures
{
    public class SearchTree
    {
        private Node root;

        public SearchTree()
        {
            root = CreateNode();
        }

        public static Node CreateNode()
        {
            return new Node();
        }

        public bool IsEmpty()
        {
            return root.Left == null;
        }        
    }
}