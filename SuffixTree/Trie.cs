using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuffixTree
{
    public class Trie<T> : ITrie<T>
    {
        private TreeNode<T> root;
        
        public Trie()
        {
            root = new TreeNode<T>(default);
        }

        public void Insert(ReadOnlySpan<T> input, int suffixStart)
        {
            root.Insert(input, suffixStart);          
        }

        public bool Search(ReadOnlySpan<T> input, out List<int> lineIndexes)
        {
            return root.Search(input, out lineIndexes);
        }

        public bool Remove(ReadOnlySpan<T> input)
        {
            return root.Remove(input);
        }

        public bool RemoveFromTree(ReadOnlySpan<T> input)
        {
            return root.RemoveFromTree(input);
        }
    }
}
