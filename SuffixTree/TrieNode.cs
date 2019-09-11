using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuffixTree
{
    class TrieNode<T>
    {
        List<Results> results;
        public HashSet<TrieNode<T>> children;

        public TrieNode(T value)
        {
            Value = value;
            children = new HashSet<TrieNode<T>>(new TrieNodeEqualityComparer<T>());
            results = new List<Results>();
        }


        public T Value { get; set; }
        public bool IsEndOfWord { get; set; }


        public void Insert(ReadOnlySpan<T> input, int line, int startingIndex, int endingIndex)
        {

            if (input.Length == 0)
            {
                bool foundLine = false;

                var newResult = new Results();
                newResult.Line = line;
                newResult.Indexes = new List<int[]>();
                newResult.Indexes.Add(new int[] { startingIndex, endingIndex });


                foreach (var current in results)
                {
                    if(current.Line == newResult.Line)
                    {
                        current.Indexes.Add(new int[] { startingIndex, endingIndex });
                        foundLine = true;
                    }
                }

                if (!foundLine)
                {
                    results.Add(newResult);
                }

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

        public bool Search(ReadOnlySpan<T> input, out List<Results> whereIsFound)
        {
            whereIsFound = results;

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
                    results.Clear();
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
