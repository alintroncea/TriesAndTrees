using System;
using System.Collections.Generic;
using System.Text;

namespace SuffixTree
{

    public class Products
    {
        private Tree tree = new Tree();
        private List<Product> productsList;

        public Products()
        {
            productsList = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            productsList.Add(product);

            tree.Build(product.Name, product.ProductIndex);
            tree.Build(product.Processor, product.ProductIndex);
            tree.Build(product.RAM, product.ProductIndex);
            tree.Build(product.Graphics, product.ProductIndex);
            tree.Build(product.Price.ToString(), product.ProductIndex);
        }

        public void Search(string pattern)
        {
            HashSet<int> productIndexes;

            if (tree.Search(pattern, out productIndexes))
            {
                foreach (var current in productIndexes)
                {
                    CheckForHighlight("Name: ", productsList[current].Name, pattern);
                    CheckForHighlight("Processor: ", productsList[current].Processor, pattern);
                    CheckForHighlight("RAM: ", productsList[current].RAM, pattern);
                    CheckForHighlight("Graphics: ", productsList[current].Graphics, pattern);
                    CheckForHighlight("Price: ", productsList[current].Price, pattern);
                    Console.WriteLine("=======================");
                }
          
            }
            else
            {
                Console.WriteLine("Pattern not found");
            }
        }

        private void CheckForHighlight(string title, string input, string pattern)
        {
            Console.Write(title);

            if (input.Contains(pattern))
            {
                var index = input.IndexOf(pattern[0]);

                for (int i = 0; i < input.Length; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }

                    if (i == (index + pattern.Length))
                    {
                        Console.ResetColor();
                    }

                    Console.Write(input[i]);
                }

            }
            else
            {
                foreach (var current in input)
                {
                    Console.Write(current);
                }
            }
            Console.WriteLine();
        }
    }
}
