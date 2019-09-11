using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using Xceed.Wpf.Toolkit;

namespace SuffixTree
{
    public class Program
    {
        static void Main(string[] args)
        {

            var tree = new Tree();
            var content = File.ReadAllLines(args[0]);
            Console.WriteLine("Building ......");

            for (int i = 0; i < content.Length; i++)
            {
                tree.Build(content[i], i);
            }

            for (int i = 1; i < args.Length; i++)
            {
                var wordToSearch = args[i];

                List<int> linesWhereIsFound;
                List<int[]> indexesWhereIsFound;

                if (tree.Search(wordToSearch, out linesWhereIsFound, out indexesWhereIsFound))
                {
                    Console.WriteLine(linesWhereIsFound.Count);
                    Console.WriteLine(indexesWhereIsFound.Count);
                }
                else
                {
                    Console.WriteLine("Pattern: " + wordToSearch + ", not found");
                }
                Console.WriteLine("=====================");
            }

        }
    }
}