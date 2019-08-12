using System;
using Xunit;

namespace SuffixTree
{
    public class TrieFacts
    {
        [Fact]
        public void CheckSearch()
        {
            Trie trie = new Trie();
            trie.Insert("cat");
            Assert.True(trie.Search("cat"));
            Assert.False(trie.Search("cats"));
        }
    }
}
