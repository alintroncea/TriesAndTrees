using System;
using System.Collections.Generic;
using System.Text;

namespace SuffixTree
{

    public class Tree
    {
        Trie<char> trie = new Trie<char>();

        public void Build(string line, int lineIndex)
        {           
            for (int i = 1; i <= line.Length; i++)
            {
                for (int j = 0; j <= line.Length - i; j++)
                {
                    string suffix = line.Substring(j, i);
                    trie.Insert(suffix, lineIndex);
                }
            }
        }

        public bool Search(string input, out List<int> linesIndexes)
        {
            return trie.Search(input, out linesIndexes);
        }
    }
}
