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

            var content = File.ReadAllLines(args[0]);
            Products products = new Products();

            Console.WriteLine("Building ......");

            for (int i = 0; i < content.Length; i++)
            {
                string[] contents = content[i].Split(',');

                Product product = new Product(i, contents[0], contents[1], contents[2], contents[3], contents[4]);
                products.AddProduct(product);
            }

            products.Search("AMD");
        }
    }
}