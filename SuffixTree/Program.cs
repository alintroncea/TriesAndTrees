using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using Xceed.Wpf.Toolkit;
using Color = System.Drawing.Color;

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
                List<Results> whereIsFound;

                var found = tree.Search(wordToSearch, out whereIsFound);

                if (found)
                {
                    foreach (var current in whereIsFound)
                    {
                        var counter = 0;
                        var lineWithPattern = content[current.Line];
                        List<int> indexes = new List<int>();

                        foreach (var array in current.Indexes)
                        {
                            indexes.Add(array[0]);
                            indexes.Add(array[1]);

                        }


                        for (int x = 0; x < lineWithPattern.Length; x++)
                        {
                            if (counter < indexes.Count)
                            {
                                bool counterIsEven = counter % 2 == 0;

                                if (x == indexes[counter])
                                {
                                    if (counterIsEven)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Green;
                                    }
                                    else
                                    {
                                        Console.ResetColor();
                                    }

                                    counter++;
                                }
                            }
                            Console.Write(lineWithPattern[x]);
                        }

                        counter = 0;
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Pattern not found");
                }

            }

        }


    }
}