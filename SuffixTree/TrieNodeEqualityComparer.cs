using System.Collections.Generic;

namespace SuffixTree
{
    internal class TrieNodeEqualityComparer<T> : IEqualityComparer<TrieNode<T>>
    {
        public TrieNodeEqualityComparer()
        {
        }

        public bool Equals(TrieNode<T> x, TrieNode<T> y)
        {
            return x.Value.Equals(y.Value);
        }

        public int GetHashCode(TrieNode<T> obj)
        {
            return obj.Value.GetHashCode();
        }
    }
}