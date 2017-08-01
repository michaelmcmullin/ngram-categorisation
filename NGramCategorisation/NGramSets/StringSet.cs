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
        #region Constructors
        public StringSet(string source)
        {
            Parse(source);
        }
        #endregion

        #region Properties
        /// <summary>
        /// An internal list of parsed N-Grams.
        /// </summary>
        protected List<NGram<string>> ngrams = new List<NGram<string>>();

        /// <summary>
        /// Indicate whether or not processing should be case sensitive
        /// </summary>
        public bool CaseSensitive { get; private set; } = false;

        /// <summary>
        /// The original string used to generate N-Grams.
        /// </summary>
        public string Source { get; private set; }

        /// <summary>
        /// A pre-processed version of the string suitable for conversion to
        /// N-Grams.
        /// </summary>
        protected string CleanedSource { get; private set; }

        /// <summary>
        /// A set of sizes to create N-Grams from. For example, the default of
        /// { 1, 2, 3, 4, 5 } will create unigrams, bigrams, trigrams, 4-grams
        /// and 5-grams from the source string.
        /// </summary>
        public int[] Magnitudes { get; private set; } = { 1, 2, 3, 4, 5 };
        #endregion

        #region Utility Methods
        /// <summary>
        /// Clean up the source string to make it suitable for conversion to
        /// NGrams.
        /// </summary>
        protected void CleanSource()
        {
            CleanedSource = CaseSensitive ? Source : Source.ToLower();

            // Remove unwanted characters
            string[] stringsToRemove = new string[] { " ", "_", "*", ",", ".", "(", ")", "[", "]", "{", "}", "\n", "\t", "\r" };

            foreach (string s in stringsToRemove)
            {
                CleanedSource = CleanedSource.Replace(s, String.Empty);
            }
        }

        /// <summary>
        /// Add N-Grams of a specified magnitude to the internal list of parsed
        /// N-Grams.
        /// </summary>
        /// <param name="magnitude">The size of the N-Grams to create.</param>
        protected void ParseMagnitude(int magnitude)
        {
            Dictionary<string, NGram<string>> tmp = new Dictionary<string, NGram<string>>();

            // Add some padding
            string padding = String.Empty;
            for (int i = 0; i < magnitude; i++)
                padding += "_";

            string source = padding + CleanedSource + padding;

            // Get the N-Grams
            if (source.Length >= magnitude)
            {
                for (int i = 0; i < source.Length - magnitude; i++)
                {
                    string ngramText = (source.Substring(i, magnitude));

                    if (tmp.ContainsKey(ngramText))
                    {
                        tmp[ngramText].Count++;
                    }
                    else
                    {
                        tmp[ngramText] = new NGram<string>(ngramText);
                    }
                }
            }

            // Transfer dictionary values to main N-Grams list
            foreach (NGram<string> item in tmp.Values)
                ngrams.Add(item);
        }
        #endregion

        public double GetDistance(string ngram, INGramSet<string> otherSet)
        {
            throw new NotImplementedException();
        }

        public double GetDistance(INGramSet<string> otherSet)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Convert the source string to a list of N-Grams.
        /// </summary>
        /// <param name="source">The source string to convert to N-Grams.
        /// </param>
        public void Parse(string source)
        {
            Source = source;
            CleanSource();
            for (int i=0; i<Magnitudes.Length; i++)
            {
                ParseMagnitude(Magnitudes[i]);
            }
        }
    }
}
