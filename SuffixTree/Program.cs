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

            if (args.Length > 0)
            {
                foreach (var obj in args)
                {
                    var text = File.ReadAllLines(obj.ToString());

                    for(int i = 1; i < text.Length; i++)
                    {                      
                           tree.Build(text[i], i);                       
                    }
                }
            }
            else
            {
                Console.WriteLine("No arguments found");
            }

            List<int> linesIndexes;

            if(tree.Search("Agency", out linesIndexes))
            {
                foreach (var current in linesIndexes)
                {
                    Console.WriteLine("Pattern found on line: " + current);
                }
            }
            else
            {
                Console.WriteLine("Pattern not found");
            }
           
        }    
    }
}