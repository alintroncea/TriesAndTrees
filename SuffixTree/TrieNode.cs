using System;
using System.Collections.Generic;
using System.Text;

namespace SuffixTree
{
    class TrieNode
    {
        public List<TrieNode> children = new List<TrieNode>();

        public TrieNode(char value)
        {
            Value = value;
        }
        public char Value { get; set; }
        public bool IsEndOfWord { get; set; }
    }
}
