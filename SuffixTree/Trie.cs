using System;
using System.Collections;
using System.Collections.Generic;
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
        public void Insert(IEnumerable<T> input)
        {
            var currentNode = root;

            foreach (var current in input)
            {
                var newNode = new TrieNode<T>(current);

                var nodeIndex = GetNodeIndex(currentNode.children, current);

                if (nodeIndex == -1)
                {
                    currentNode.children.Add(newNode);
                    currentNode = newNode;
                }

                else
                {
                    currentNode = currentNode.children[nodeIndex];
                }
            }
            currentNode.IsEndOfWord = true;
        }

        public void Remove(IEnumerable<T> input)
        {
            throw new NotImplementedException();
        }

        public bool Search(IEnumerable<T> input)
        {
            var currentNode = root;
            foreach (var currentElement in GetCurrentItem(input))
            {
                currentNode = SearchInNodes(currentNode, currentElement);
                if (!currentNode.Value.Equals(currentElement))
                {
                    return false;
                }
            }
            return true;
        }

        private TrieNode<T> SearchInNodes(TrieNode<T> currentNode, T currentElement)
        {

            int index = GetNodeIndex(currentNode.children, currentElement);

            if (index == -1)
            {
                return null;
            }
            return currentNode.children[index];
        }

        private IEnumerable<T> GetCurrentItem(IEnumerable<T> input)
        {
            foreach (var current in input)
            {
                yield return current;
            }
        }

        private int GetNodeIndex(List<TrieNode<T>> children, T value)
        {

            foreach (var current in children)
            {

                if (current.Value.Equals(value))
                {
                    return children.IndexOf(current);
                }

            }
            return -1;
        }
    }
}
