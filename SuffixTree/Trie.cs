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
        public void Insert(IEnumerable<T> input)
        {
            var currentNode = root;

            foreach (var current in input)
            {
                var nodeIndex = currentNode.IndexOf(current);

                if (nodeIndex == -1)
                {
                    var newNode = new TrieNode<T>(current);
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
            bool isAtTheEnd = true;
            bool canBeDeleted = true;
            root.Remove(input, ref isAtTheEnd, ref canBeDeleted);
        }

        public bool Search(IEnumerable<T> input)
        {
            return root.Search(input);
        }
    }
}
