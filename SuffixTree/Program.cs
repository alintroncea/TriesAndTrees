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
            

            for (int i = 0; i < content.Length; i++)
            {
                tree.Build(content[i], i);
            }

            for (int i = 1; i < args.Length; i++)
            {
                var wordToSearch = args[i];
                Console.WriteLine("Searching for..." + wordToSearch);
                HashSet<int[]> whereIsFound;

                var found = tree.Search(wordToSearch, out whereIsFound);

                var refine = new RefineResults(whereIsFound);

                var results = refine.GetResult();

                foreach(var current in results)
                {
                    Console.WriteLine("Line: " + current.line);

                    foreach(var indexes in current.indexes)
                    {
                        Console.WriteLine("Starting index: " + indexes[0] + " Ending index: " + indexes[1]);
                    }
                }
            }

        }

    
    }
}