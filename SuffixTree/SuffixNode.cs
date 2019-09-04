using System;
using System.Collections.Generic;
using System.Text;

namespace SuffixTree
{
    public class SuffixNode
    {

        static int MAX_CHAR = 256;

        public SuffixNode[] children;
        List<int> indexes;

        public SuffixNode() // Constructor 
        {
            // Create an empty linked list for indexes of 
            // suffixes starting from this node 
            indexes = new List<int>();

            // Initialize all child pointers as NULL 
            children = new SuffixNode[MAX_CHAR];
            for (int i = 0; i < MAX_CHAR; i++)
                children[i] = null;

        }
        public char Value { get; set; }

        // A recursive function to insert a suffix of  
        // the text in subtree rooted with this node 
        public void insertSuffix(string input, int index)
        {
            Console.WriteLine("input: " + input);
            Console.WriteLine("index: " + index);
            // Store index in linked list 
            indexes.Add(index);

            // If string has more characters 
            if (input.Length > 0)
            {

                // Find the first character 
                char cIndex = input[0];

                // If there is no edge for this character, 
                // add a new edge 
                if (children[cIndex] == null)
                    children[cIndex] = new SuffixNode();

                // Recur for next suffix 
                children[cIndex].insertSuffix(input.Substring(1),
                                                  index + 1);
            }
        }

        // A function to search a pattern in subtree rooted 
        // with this node.The function returns pointer to a  
        // linked list containing all indexes where pattern   
        // is present. The returned indexes are indexes of   
        // last characters of matched text. 
        public List<int> search(String s)
        {

            // If all characters of pattern have been  
            // processed, 
            if (s.Length == 0)
                return indexes;

            // if there is an edge from the current node of 
            // suffix tree, follow the edge. 
            if (children[s[0]] != null)
                return (children[s[0]]).search(s.Substring(1));

            // If there is no edge, pattern doesnt exist in  
            // text 
            else
                return null;
        }

       
    }
}
