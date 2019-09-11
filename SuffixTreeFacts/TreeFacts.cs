using SuffixTree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace SuffixTree
{
    public class TreeFacts
    {
        [Fact]
        public void TestRemove()
        {
            List<int> line;
            List<int[]> indexes;

            Tree tree = new Tree();           
            tree.Build("banana",0);
            Assert.True(tree.Remove("ana"));
            Assert.False(tree.Search("ana",out line, out indexes));
            Assert.True(tree.Search("banana",out line, out indexes));
            Assert.True(tree.Search("na", out line, out indexes));
            Assert.True(tree.Search("a", out line, out indexes));
        }
    }
}
