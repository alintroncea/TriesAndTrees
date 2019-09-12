using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuffixTree
{
    public class Trie<T> : ITrie<T>
    {
        private TrieNode<T> root;
        
        public Trie()
        {
            root = new TrieNode<T>(default);
        }

        public void Insert(ReadOnlySpan<T> input, int suffixStart)
        {
            root.Insert(input, suffixStart);          
        }

        public bool Search(ReadOnlySpan<T> input, out HashSet<int> lineIndexes)
        {
            return root.Search(input, out lineIndexes);
        }

        public bool Remove(ReadOnlySpan<T> input)
        {
            return root.Remove(input);
        }
    }
}
