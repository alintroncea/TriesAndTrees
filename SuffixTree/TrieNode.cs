using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuffixTree
{
    class TreeNode<T>
    {
        public List<TreeNode<T>> children;
        public List<int> linesWhereIsFound;

        public TreeNode(T value)
        {
            Value = value;
            children = new List<TreeNode<T>>();
            linesWhereIsFound = new List<int>();
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

            var index = IndexOf(input[0]);

            if (index == -1)
            {
                var newNode = new TreeNode<T>(input[0]);
                children.Add(newNode);
                newNode.Insert(input.Slice(1), line);
            }
            else
            {
                children[index].Insert(input.Slice(1), line);
            }
        }

        public bool Search(ReadOnlySpan<T> input, out List<int> list)
        {
            list = linesWhereIsFound;

            if (input.Length == 0)
            {
                return IsEndOfWord;
            }

            var index = IndexOf(input[0]);

            if (index == -1)
            {
                return false;
            }

            var currentNode = children[index];
            return currentNode.Search(input.Slice(1), out list);
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < children.Count; i++)
            {
                if (children[i].Value.Equals(value))
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

            var currentNode = children[index];
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

        public bool RemoveFromTree(ReadOnlySpan<T> input)
        {
            List<int> list;

            while (Search(input, out list))
            {
                Remove(input);
            }
            return true;
        }
    }
}
