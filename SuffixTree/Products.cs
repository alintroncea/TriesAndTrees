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

        public void Search(string input)
        {
            HashSet<int> productIndexes;

            if(tree.Search(input, out productIndexes))
            {
                foreach(var current in productIndexes)
                {
                    
                    Console.WriteLine("Name: " + productsList[current].Name);
                    Console.WriteLine("Processor: " + productsList[current].Processor);
                    Console.WriteLine("RAM: " + productsList[current].RAM);
                    Console.WriteLine("Graphics: " + productsList[current].Graphics);
                    Console.WriteLine("Price: " + productsList[current].Price);

                    Console.WriteLine("=======================");
                }
            }
            else
            {
                Console.WriteLine("Pattern not found");
            }
        }
    }
}
