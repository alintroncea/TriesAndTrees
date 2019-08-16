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
        public TrieNode<T> SearchInNode(T currentElement)
        {
            int index = IndexOf(currentElement);
            return index == -1 ? null : children[index];
        }
        public int IndexOf(T value)
        {
            foreach (var child in children)
            {
                if (child.Value.Equals(value))
                {
                    return children.IndexOf(child);
                }
            }
            return -1;
        }
    }
}
