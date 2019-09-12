using System;
using System.Collections.Generic;
using System.Text;

namespace SuffixTree
{
    public class Product
    {     
        public Product(int productIndex, string name, string processor, string ram, string graphics, string price)
        {
            Name = name;
            Processor = processor;
            RAM = ram;
            Graphics = graphics;
            Price = price;
            ProductIndex = productIndex;
        }

        public int ProductIndex { get; set; }
        public string Name { get; set; }
        public string Processor { get; set; }
        public string RAM { get; set; }
        public string Graphics { get; set; }
        public string Price { get; set; }
    }
}
