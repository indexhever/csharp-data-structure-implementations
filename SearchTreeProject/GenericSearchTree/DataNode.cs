namespace CSharpDataStructures
{
    public class DataNode<TKey, TData> : Node<TKey>
    {
        public TData Data;

        public DataNode(TData data)
        {
            Data = data;
        }
    }
}