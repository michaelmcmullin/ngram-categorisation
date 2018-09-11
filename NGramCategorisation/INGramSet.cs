using System;
using System.Collections.Generic;
using System.Text;

namespace NGrammer
{
    /// <summary>
    /// Represents a set of N-Grams, including methods for parsing a source
    /// object into multiple N-Grams, and comparing this set with another set
    /// to determine similarity.
    /// </summary>
    /// <typeparam name="T">The type of element in the NGramSet.</typeparam>
    public interface INGramSet<T> where T : IEquatable<T>
    {
        /// <summary>
        /// An internal list of parsed N-Grams.
        /// </summary>
        List<NGram<T>> NGrams { get; }

        /// <summary>
        /// Converts a source item into a set of NGram&lt;T&gt; objects.
        /// </summary>
        /// <param name="source">The source item to convert to N-Grams.</param>
        void Parse(T source);

        /// <summary>
        /// Calculate the distance of a specific NGram&lt;T&gt; object from its
        /// occurance in this set with its occurance in another set. Lower
        /// values suggest greater similarity.
        /// </summary>
        /// <param name="ngram">The NGram&lt;T&gt; object to compare.</param>
        /// <param name="otherSet">The INGramSet&lt;T&gt; to compare the
        /// position with.</param>
        /// <returns>A value indicating ngram's relative position between this
        /// set and otherSet. Lower values suggest greater similarity, and
        /// results are always positive.</returns>
        double GetDistance(T ngram, INGramSet<T> otherSet);

        /// <summary>
        /// Calculate the overall distance between this set and otherSet. Lower
        /// values indicate a greater similarity between both sets.
        /// </summary>
        /// <param name="otherSet">The INGramSet&lt;T&gt; to compare with this
        /// instance.</param>
        /// <returns>A positive value representing the distance between the two
        /// sets. Lower values mean greater similarity.</returns>
        double GetDistance(INGramSet<T> otherSet);
    }
}
