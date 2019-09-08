using System;
using System.Collections.Generic;
using System.IO;
namespace SuffixTree
{
    public class Program
    {
        static void Main(string[] args)
        {

            Tree tree = new Tree();
            string[] path;
            string wordToSearch;

            if (args.Length > 1)
            {
                path = File.ReadAllLines(args[0]);

                for (int i = 0; i < path.Length; i++)
                {
                    tree.Build(path[i], i);
                }

                for (int i = 1; i < args.Length; i++)
                {
                    wordToSearch = args[i];

                    List<int> linesIndexes;

                    if (tree.Search(wordToSearch, out linesIndexes))
                    {
                        foreach (var current in linesIndexes)
                        {
                            Console.WriteLine("Pattern: " + wordToSearch + ", found on line: " + current);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Pattern: " + wordToSearch + ", not found");
                    }
                    Console.WriteLine("=====================");
                }
            }
            else
            {
                Console.WriteLine("No arguments found");
            }

            //tree.Remove("eBook");

            //List<int> linesIndexes;

            //if(tree.Search("eBook", out linesIndexes))
            //{
            //    foreach (var current in linesIndexes)
            //    {
            //        Console.WriteLine("Pattern found on line: " + current);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Pattern not found");
            //}


        }
    }
}