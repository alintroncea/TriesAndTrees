using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
namespace SuffixTree
{
    public class TrieFacts
    {
        [Fact]
        public void CheckSearch()
        {
            Trie<char> trie = new Trie<char>();
            trie.Insert("cat");
            trie.Insert("dog");
            trie.Insert("hongkong");
            trie.Insert("156789");

            Assert.True(trie.Search("cat"));
            Assert.False(trie.Search("cats"));

            Assert.True(trie.Search("dog"));
            Assert.False(trie.Search("do"));

            Assert.True(trie.Search("hongkong"));
            Assert.False(trie.Search("hongkong "));

            Assert.True(trie.Search("156789"));
            Assert.False(trie.Search("15678"));
        }
    }
}
