using System;
using System.Collections.Generic;
using System.Text;

namespace SuffixTree
{
    interface ITrie
    {
        void Insert(string input);
        void Remove();
        bool Search(string input);
    }
}
