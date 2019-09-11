using System;
using System.Collections.Generic;
using System.Text;

namespace SuffixTree
{
    public struct Results
    {
       public int line;
       public List<int[]> indexes;
    }


    public class RefineResults
    {
        List<Results> results;
        HashSet<int> uniqueLines;

        public RefineResults(HashSet<int[]> input)
        {
            results = new List<Results>();
            uniqueLines = new HashSet<int>();
            Input = input;

            foreach(var current in Input)
            {
                uniqueLines.Add(current[0]);
            }
        }

        private HashSet<int[]> Input { get; set; }

        public List<Results> GetResult()
        {
            foreach(var current in uniqueLines)
            {
                var result = new Results();
                
                result.line = current;
                result.indexes = new List<int[]>();
                results.Add(result);
            }

            foreach(var array in Input)
            {
                foreach(var result in results)
                {
                    if(array[0] == result.line)
                    {
                        result.indexes.Add(new int[] { array[1], array[2]});
                    }
                }
            }

            return results;
        }
    }
}
