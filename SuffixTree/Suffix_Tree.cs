using System;
using System.Collections.Generic;
using System.Text;

namespace SuffixTree
{
    public class SuffixTree
    {
        SuffixNode root = new SuffixNode();

        // Constructor (Builds a trie of suffies of the 
        // given text) 
        public SuffixTree(string txt)
        {

            // Consider all suffixes of given string and 
            // insert them into the Suffix Trie using  
            // recursive function insertSuffix() in  
            // SuffixTrieNode class 
            for (int i = 0; i < txt.Length; i++)
            {
                Console.WriteLine("Value inserted " + txt.Substring(i) + " at index: " + i);
                root.insertSuffix(txt.Substring(i), i);
            }
        }

        /* Prints all occurrences of pat in the Suffix Trie S 
        (built for text) */
        public void search_tree(String pat)
        {

            // Let us call recursive search function for  
            // root of Trie. 
            // We get a list of all indexes (where pat is  
            // present in text) in variable 'result' 
            List<int> result = root.search(pat);

            // Check if the list of indexes is empty or not 
            if (result == null)
                Console.WriteLine("Pattern not found");
            else
            {

                int patLen = pat.Length;

                foreach (int i in result)
                    Console.WriteLine("Pattern found at position " + (i - patLen));
            }
        }
    }
}

