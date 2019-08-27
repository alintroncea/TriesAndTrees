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
            var trie = new Trie<char>();
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

        [Fact]
        public void CheckRemove()
        {
            var trie = new Trie<char>();
            trie.Insert("c");
            trie.Insert("cat");

            Assert.True(trie.Remove("cat"));
            Assert.False(trie.Search("cat"));
            Assert.True(trie.Search("c"));
          

        }

        [Fact]
        public void CheckRemove2()
        {
            var trie = new Trie<char>();
            trie.Insert("cat");
            trie.Insert("cats");
            trie.Insert("cato");

            Assert.True(trie.Remove("cat"));
            Assert.False(trie.Search("cat"));
            Assert.True(trie.Search("cats"));
            Assert.True(trie.Search("cato"));
            Assert.True(trie.Remove("cato"));
            Assert.False(trie.Search("cato"));
            Assert.True(trie.Search("cats"));
        }

        [Fact]
        public void CheckRemove3()
        {
            var trie = new Trie<char>();
            trie.Insert("a");
            trie.Insert("abc");
            trie.Insert("abcd");
            trie.Insert("abcde");
            trie.Insert("abcdx");
            trie.Insert("abcdxy");
            trie.Insert("abcdxz");

            trie.Remove("a");
            Assert.False(trie.Search("a"));
            Assert.True(trie.Search("abc"));
            Assert.True(trie.Search("abcdx"));
            Assert.True(trie.Search("abcde"));

            trie.Remove("abcdxz");
            Assert.False(trie.Search("abcdxz"));
            Assert.True(trie.Search("abc"));
            Assert.True(trie.Search("abcdx"));
            Assert.True(trie.Search("abcdxy"));

            trie.Remove("abc");
            Assert.False(trie.Search("abc"));
            Assert.True(trie.Search("abcd"));
            Assert.True(trie.Search("abcdx"));
            Assert.True(trie.Search("abcde"));

        }

        [Fact]
        public void CheckRemove4()
        {
            var trie = new Trie<char>();
            trie.Insert("abcd");
            Assert.False(trie.Remove("abc"));
            Assert.True(trie.Remove("abcd"));
        }
    }
}
  
