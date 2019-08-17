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

        public TrieNode<T> RecursionSearch(T currentElement, int counter)
        {
            if (counter < children.Count)
            {               
                var currentNode = children[counter++];
                return currentNode.Value.Equals(currentElement) ? currentNode : RecursionSearch(currentElement, counter);     
            }
            return null;
        }
        public int IndexOf(T value)
        {
            for (int i = 0; i < children.Count; i++)
            {
                if (children[i].Value.Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
