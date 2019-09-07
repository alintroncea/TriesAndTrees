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


        public void Insert(IEnumerable<T> input, int line)
        {
            if (!input.Any())
            {
                linesWhereIsFound.Add(line);
                IsEndOfWord = true;
                return;
            }

            var index = IndexOf(input.First());

            if (index == -1)
            {
                var newNode = new TreeNode<T>(input.First());
                children.Add(newNode);
                newNode.Insert(input.Skip(1), line);
            }
            else
            {
                children[index].Insert(input.Skip(1), line);
            }
        }

        public bool Search(IEnumerable<T> input, out List<int> list)
        {
            list = linesWhereIsFound;

            if (!input.Any())
            {
                return IsEndOfWord;
            }

            var index = IndexOf(input.First());

            if (index == -1)
            {
                return false;
            }

            var currentNode = children[index];
            return currentNode.Search(input.Skip(1), out list);
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

        public bool Remove(IEnumerable<T> input)
        {
            if (!input.Any())
            {
                if (!IsEndOfWord)
                {
                    return false;
                }

                IsEndOfWord = false;
                return true;
            }
            var index = IndexOf(input.First());
            if (index == -1)
            {
                return false;
            }

            var currentNode = children[index];
            bool result = currentNode.Remove(input.Skip(1));

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
