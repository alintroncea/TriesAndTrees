using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
namespace SuffixTree
{
    public class Program
    {
        static void Main(string[] args)
        {


            if (args.Length <= 1)
            {
                Console.WriteLine("No arguments found");
                return;
            }

            var tree = new Tree();
            var content = File.ReadAllLines(args[0]);
            var stopwatch = new Stopwatch();
            Console.WriteLine("Building ......");
            stopwatch.Start();

            for (int i = 0; i < content.Length; i++)
            {              
                tree.Build(content[i], i);
            }
            stopwatch.Stop();
            Console.WriteLine($"Build took {stopwatch.Elapsed}");

            for (int i = 1; i < args.Length; i++)
            {
                var wordToSearch = args[i];

                List<int> linesIndexes;

                stopwatch.Restart();

                var found = tree.Search(wordToSearch, out linesIndexes);
                stopwatch.Stop();
                Console.WriteLine($"Search of {wordToSearch} took {stopwatch.Elapsed}");

                if (found)
                {
                    foreach (var current in linesIndexes)
                    {
                        Console.WriteLine(content[current]);
                    }
                }
                else
                {
                    Console.WriteLine("Pattern: " + wordToSearch + ", not found");
                }
                Console.WriteLine("=====================");
            }

            //Console.WriteLine("Searching with for loop......");

            //stopwatch.Reset();
            //stopwatch.Start();

            //for (int i = 0; i < content.Length; i++)
            //{
            //    if (content[i].Contains(args[1]))
            //    {
            //        Console.WriteLine(content[i]);
            //    }
            //}
            //stopwatch.Stop();
            //Console.WriteLine($"Search took {stopwatch.Elapsed}");
        }
    }
}