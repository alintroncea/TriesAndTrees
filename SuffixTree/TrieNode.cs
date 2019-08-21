using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public bool Search(IEnumerable<T> input)
        {
            if (!input.Any())
            {
                return IsEndOfWord;
            }

            var index = IndexOf(input.First());
            return index != -1 && children[index].Search(input.Skip(1));
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

        public bool Remove(IEnumerable<T> input, ref bool isAtTheEnd, ref bool canBeDeleted)
        {
            if (!input.Any())
            {
                return false;
            }

            var index = IndexOf(input.First());

            if (index == -1)
            {
                return false;
            }
            var currentNode = children[index];
            currentNode.Remove(input.Skip(1), ref isAtTheEnd, ref canBeDeleted);

            if (currentNode.IsEndOfWord)
            {
                if(isAtTheEnd)
                {
                    isAtTheEnd = false;
                    currentNode.IsEndOfWord = false;
                }

                canBeDeleted = false;
            }
          
            if (canBeDeleted)
            {
                children.Remove(currentNode);
            }

            return true;
        }
    }
}
