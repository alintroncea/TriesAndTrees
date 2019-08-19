using System;
using System.Collections.Generic;
namespace SuffixTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie<char> trie = new Trie<char>();
            trie.Insert("cat");

           Console.WriteLine(trie.Search("ca"));
        }
    }
}
