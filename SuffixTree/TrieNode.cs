using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuffixTree
{
    class TrieNode<T>
    {
        public HashSet<int[]> indexes;
        public HashSet<TrieNode<T>> children;

        public TrieNode(T value)
        {
            Value = value;
            children = new HashSet<TrieNode<T>>(new TrieNodeEqualityComparer<T>());
            indexes = new HashSet<int[]>();
        }


        public T Value { get; set; }
        public bool IsEndOfWord { get; set; }


        public void Insert(ReadOnlySpan<T> input, int line, int startingIndex, int endingIndex)
        {
            if (input.Length == 0)
            {
                indexes.Add(new int[] { line, startingIndex, endingIndex });
                IsEndOfWord = true;
                return;
            }


            TrieNode<T> newNode = new TrieNode<T>(input[0]);

            if (!children.TryGetValue(newNode, out TrieNode<T> currentNode))
            {
                children.Add(newNode);
                newNode.Insert(input.Slice(1), line, startingIndex, endingIndex);
            }
            else
            {
                currentNode.Insert(input.Slice(1), line, startingIndex, endingIndex);
            }
        }

        public bool Search(ReadOnlySpan<T> input, out HashSet<int[]> whereIsFound)
        {
            whereIsFound = indexes;

            if (input.Length == 0)
            {
                return IsEndOfWord;
            }

            if (!children.TryGetValue(new TrieNode<T>(input[0]), out TrieNode<T> currentNode))
            {
                return false;
            }

            return currentNode.Search(input.Slice(1), out whereIsFound);
        }

        public bool Remove(ReadOnlySpan<T> input)
        {
            if (input.Length == 0)
            {
                if (!IsEndOfWord)
                {
                    indexes.Clear();
                    return false;
                }

                IsEndOfWord = false;
                return true;
            }

            if (!children.TryGetValue(new TrieNode<T>(input[0]), out TrieNode<T> currentNode))
            {
                return false;
            }
            bool result = currentNode.Remove(input.Slice(1));

            if (!result)
            {
                return false;
            }

            if (currentNode.children.Count == 0 && !currentNode.IsEndOfWord)
            {
                currentNode.children.Remove(currentNode);

            }

            return true;
        }
    }
}
