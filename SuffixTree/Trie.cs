using System;
using System.Collections.Generic;
using System.Text;

namespace SuffixTree
{
    public class Trie : ITrie
    {
        private TrieNode root;

        public Trie()
        {
            root = new TrieNode(default);
        }

        public void Insert(string input)
        {
            var currentNode = root;

            for (int i = 0; i < input.Length; i++)
            {
                var newNode = new TrieNode(input[i]);

                var nodeIndex = NodeIsInChildren(currentNode.children, newNode);

                if (nodeIndex == -1)
                {
                    currentNode.children.Add(newNode);
                    currentNode = newNode;
                }

                else
                {
                    currentNode = currentNode.children[nodeIndex];
                    continue;
                }

            }
            currentNode.IsEndOfWord = true;
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public bool Search(string input)
        {
            var currentNode = root;
            char c = root.Value;

            foreach(char current in input)
            {
                c = current;
                foreach (var node in currentNode.children)
                {
                    if (!current.Equals(node.Value))
                    {
                        return false;
                    }

                    if (current.Equals(node.Value))
                    {
                        var newNode = new TrieNode(current);

                        var nodeIndex = NodeIsInChildren(currentNode.children, newNode);
                        currentNode = currentNode.children[nodeIndex];
                    }
                }
            }

            if (currentNode.IsEndOfWord && currentNode.Value.Equals(c))
            {
                return true;
            }    
           
            return false;
        }

        private int NodeIsInChildren(List<TrieNode> children, TrieNode node)
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
