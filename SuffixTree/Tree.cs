using System;
using System.Collections.Generic;
using System.Text;

namespace SuffixTree
{

    public class Tree
    {
        Trie<char> trie = new Trie<char>();

        public void Build(ReadOnlySpan<char> line, int lineIndex)
        {           
            for (int i = 1; i <= line.Length; i++)
            {
                for (int j = 0; j <= line.Length - i; j++)
                {
                    var suffix = line.Slice(j, i);
                    trie.Insert(suffix, lineIndex);
                }
            }
        }

        public bool Search(ReadOnlySpan<char> input, out HashSet<int> linesIndexes)
        {
            return trie.Search(input, out linesIndexes);
        }

        public bool Remove(ReadOnlySpan<char> input)
        {
            return trie.Remove(input);
        }
    }
}
