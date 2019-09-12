using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuffixTree
{
    class TrieNode<T>
    {
        public HashSet<TrieNode<T>> children;
        public HashSet<int> linesWhereIsFound;

        public TrieNode(T value)
        {
            Value = value;
            children = new HashSet<TrieNode<T>>(new TrieNodeEqualityComparer<T>());
            linesWhereIsFound = new HashSet<int>();
        }


        public T Value { get; set; }
        public bool IsEndOfWord { get; set; }


        public void Insert(ReadOnlySpan<T> input, int line)
        {
            if (input.Length == 0)
            {
                linesWhereIsFound.Add(line);
                IsEndOfWord = true;
                return;
            }


            TrieNode<T> newNode = new TrieNode<T>(input[0]);

            if (!children.TryGetValue(newNode, out TrieNode<T> currentNode))
            {
                children.Add(newNode);
                newNode.Insert(input.Slice(1), line);
            }
            else
            {
                currentNode.Insert(input.Slice(1), line);
            }
        }

        public bool Search(ReadOnlySpan<T> input, out HashSet<int> list)
        {
            list = linesWhereIsFound;

            if (input.Length == 0)
            {
                return IsEndOfWord;
            }

            if (!children.TryGetValue(new TrieNode<T>(input[0]), out TrieNode<T> currentNode))
            {
                return false;
            }

            return currentNode.Search(input.Slice(1), out list);
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < children.Count; i++)
            {
                if (children.ElementAt(i).Value.Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(ReadOnlySpan<T> input)
        {
            if (input.Length == 0)
            {
                if (!IsEndOfWord)
                {
                    linesWhereIsFound.Clear();
                    return false;
                }

                IsEndOfWord = false;
                return true;
            }

            var index = IndexOf(input[0]);
            if (index == -1)
            {
                return false;
            }

            var currentNode = children.ElementAt(index);
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
