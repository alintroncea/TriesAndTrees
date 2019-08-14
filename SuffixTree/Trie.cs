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

                var nodeIndex = GetNodeIndex(currentNode.children, newNode);

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
            List<T> list = new List<T>();
            AddInputToList(list, new List<T>(input));           
            return Find(root, list, 0); ;
        }


        private bool Find(TrieNode<T> node, List<T> list, int currentElementIndex)
        {

            if (currentElementIndex < list.Count)
            {
                var nodeToSearch = new TrieNode<T>(list[currentElementIndex++]);
                int nodeIndex = GetNodeIndex(node.children, nodeToSearch);
                if (nodeIndex == -1)
                {
                    return false;
                }

                var newNode = node.children[nodeIndex];
                return currentElementIndex == list.Count && newNode.IsEndOfWord ? true : Find(newNode, list, currentElementIndex);
            }
            return false;
        }

        public void AddInputToList(List<T> list, IEnumerable<T> input)
        {
            foreach (var current in input)
            {
                list.Add(current);
            }
        }

        private int GetNodeIndex(List<TrieNode<T>> children, TrieNode<T> node)
        {

            foreach (var current in children)
            {

                if (current.Value.Equals(node.Value))
                {
                    return children.IndexOf(current);
                }

            }
            return -1;
        }
    }
}
