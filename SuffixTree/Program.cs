using System;
using System.Collections.Generic;
namespace SuffixTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new SuffixTree();
            tree.Build("CAGTCAGG");
        }
    }
}
