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

        public void Insert(ReadOnlySpan<T> input, int lineIndex, int startingIndex, int endingIndex)
        {
            root.Insert(input, lineIndex, startingIndex, endingIndex);          
        }

        public bool Search(ReadOnlySpan<T> input, out List<Results> whereIsFound)
        {
            return root.Search(input, out whereIsFound);
        }

        public bool Remove(ReadOnlySpan<T> input)
        {
            return root.Remove(input);
        }
    }
}
