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
            var list = new List<int>();
            var trie = new Trie<char>();
            trie.Insert("cat", 0);
            trie.Insert("dog", 0);
            trie.Insert("hongkong", 0);
            trie.Insert("156789", 0);

            Assert.True(trie.Search("cat", out list));
            Assert.False(trie.Search("cats", out list));

            Assert.True(trie.Search("dog", out list));
            Assert.False(trie.Search("do", out list));

            Assert.True(trie.Search("hongkong", out list));
            Assert.False(trie.Search("hongkong ", out list));

            Assert.True(trie.Search("156789", out list));
            Assert.False(trie.Search("15678", out list));
        }

        [Fact]
        public void CheckRemove()
        {
            var list = new List<int>();
            var trie = new Trie<char>();
            trie.Insert("c", 0);
            trie.Insert("cat", 0);

            Assert.True(trie.Remove("cat"));
            Assert.False(trie.Search("cat", out list));
            Assert.True(trie.Search("c", out list));


        }

        [Fact]
        public void CheckRemove2()
        {

            var list = new List<int>();
            var trie = new Trie<char>();
            trie.Insert("cat",0);
            trie.Insert("cats",0);
            trie.Insert("cato",0);

            Assert.True(trie.Remove("cat"));
            Assert.False(trie.Search("cat", out list));
            Assert.True(trie.Search("cats", out list));
            Assert.True(trie.Search("cato", out list));
            Assert.True(trie.Remove("cato"));
            Assert.False(trie.Search("cato", out list));
            Assert.True(trie.Search("cats", out list));
        }

        [Fact]
        public void CheckRemove3()
        {

            var list = new List<int>();
            var trie = new Trie<char>();
            trie.Insert("a",0);
            trie.Insert("abc", 0);
            trie.Insert("abcd", 0);
            trie.Insert("abcde", 0);
            trie.Insert("abcdx", 0);
            trie.Insert("abcdxy", 0);
            trie.Insert("abcdxz", 0);

            trie.Remove("a");
            Assert.False(trie.Search("a", out list));
            Assert.True(trie.Search("abc", out list));
            Assert.True(trie.Search("abcdx", out list));
            Assert.True(trie.Search("abcde", out list));

            trie.Remove("abcdxz");
            Assert.False(trie.Search("abcdxz", out list));
            Assert.True(trie.Search("abc", out list));
            Assert.True(trie.Search("abcdx", out list));
            Assert.True(trie.Search("abcdxy", out list));

            trie.Remove("abc");
            Assert.False(trie.Search("abc", out list));
            Assert.True(trie.Search("abcd", out list));
            Assert.True(trie.Search("abcdx", out list));
            Assert.True(trie.Search("abcde", out list));

        }

        [Fact]
        public void CheckRemove4()
        {

            var list = new List<int>();
            var trie = new Trie<char>();
            trie.Insert("abcd",0);
            Assert.False(trie.Remove("abc"));
            Assert.True(trie.Remove("abcd"));
        }
    }
}

