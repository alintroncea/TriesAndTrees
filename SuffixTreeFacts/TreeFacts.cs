using SuffixTree;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SuffixTree
{
   public class TreeFacts
    {
        [Fact]
        public void CheckBuildTree()
        {
            SuffixTree tree = new SuffixTree();
            tree.Build("CAGTCAGG");
        }
    }
}
