using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SuffixTree
{
    class TrieNode<T>
    {
        public List<TrieNode<T>> children = new List<TrieNode<T>>();

        public TrieNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public bool IsEndOfWord { get; set; }

    }
}
