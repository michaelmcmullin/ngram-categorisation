using System;
using System.Collections.Generic;
using System.Text;

namespace NGramCategorisation.NGramSets
{
    /// <summary>
    /// Represents a set of string N-Grams, including methods for parsing a
    /// source object into multiple N-Grams, and comparing this set with another
    /// set to determine similarity.
    /// </summary>
    public class StringSet : INGramSet<string>
    {
        protected List<NGram<string>> ngrams = new List<NGram<string>>();

        public double GetDistance(string ngram, INGramSet<string> otherSet)
        {
            throw new NotImplementedException();
        }

        public double GetDistance(INGramSet<string> otherSet)
        {
            throw new NotImplementedException();
        }

        public void Parse(string source)
        {
            throw new NotImplementedException();
        }
    }
}
