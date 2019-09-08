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
            string[] text;

            if (args.Length > 0)
            {
                foreach (var obj in args)
                {
                    text = File.ReadAllLines(obj.ToString());

                    for(int i = 0; i < text.Length; i++)
                    {                                       
                           tree.Build(text[i], i);                                  
                    }
                }
            }
            else
            {
                Console.WriteLine("No arguments found");
            }

            tree.Remove("eBook");

            List<int> linesIndexes;

            if(tree.Search("eBook", out linesIndexes))
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