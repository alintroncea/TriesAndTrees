using System;
using System.Collections.Generic;
using System.Text;

namespace SuffixTree
{
    interface ITrie<T>
    {
        void Insert(ReadOnlySpan<T> input, int lineIndex, int startingIndex, int endingIndex);
        bool Remove(ReadOnlySpan<T> input);
        bool Search(ReadOnlySpan<T> input, out List<Results> whereIsFound);
    }
}
