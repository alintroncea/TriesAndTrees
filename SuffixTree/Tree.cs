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
                    var suffixStartIndex = j;
                    var suffixEndIndex = suffix.Length + j;

                    trie.Insert(suffix, lineIndex, suffixStartIndex, suffixEndIndex);
                }
            }
        }

        public bool Search(ReadOnlySpan<char> input, out HashSet<int[]> whereIsFound)
        {
            return trie.Search(input, out whereIsFound);
        }

        public bool Remove(ReadOnlySpan<char> input)
        {
            return trie.Remove(input);
        }
    }
}
