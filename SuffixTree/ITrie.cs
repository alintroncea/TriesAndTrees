using System;
using System.Collections.Generic;
using System.Text;

namespace SuffixTree
{
    interface ITrie<T>
    {
        void Insert(IEnumerable<T> input, int lineIndex);
        bool Remove(IEnumerable<T> input);
        bool Search(IEnumerable<T> input, out List<int> lineIndexes);
    }
}
