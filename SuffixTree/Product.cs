using System;
using System.Collections.Generic;
using System.Text;

namespace SuffixTree
{
    public class Product
    {
        Tree tree;

        public Product(string input, Tree tree, int index)
        {
            this.tree = tree;
            Input = input;
            Index = index;

            Build();
        }

        public string Input { get; set; }
        public int Index { get; set; }

        private void Build()
        {
            tree.Build(Input, Index);
        }

        public void Search(string wordToSearch, string[] content)
        {
         
        }

        public void CustomizeProduct(string searchedProduct)
        {
           
        }
    }
}
