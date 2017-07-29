using System;
using System.Collections.Generic;

namespace NGramCategorisation
{
    /// <summary>
    /// An N-Gram is an N-length slice of a longer item. Typically, this will be
    /// a contiguous set of characters in a string (e.g. the word 'hello' would
    /// contain the bigrams 'he', 'el', 'll' and 'lo'). However, this class has
    /// been made generic to open up other possibilities, such as categorising
    /// sequences of RGB values in a larger image.
    /// </summary>
    /// <typeparam name="T">The type of element in the NGram.</typeparam>
    public class NGram<T> : IComparable<NGram<T>>, IEquatable<NGram<T>> where T : IEquatable<T>
    {
        #region Constructors
        /// <summary>
        /// Constructor initialises the Content property, and sets the Count
        /// property to 1.
        /// </summary>
        /// <param name="content">The Content of this N-Gram.</param>
        public NGram(T content)
        {
            Content = content;
            Count = 1;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The content of this N-Gram
        /// </summary>
        public T Content { get; set; }

        /// <summary>
        /// The number of occurrences of this N-Gram
        /// </summary>
        public int Count { get; private set; }
        #endregion

        #region Operator Overrides
        #endregion

        #region Implement Interfaces
        /// <summary>
        /// Compares the current instance with another NGram&lt;T&gt;, returning
        /// an integer that indicates whether the current instance precedes,
        /// follows, or occurs in the same position in the sort order as the
        /// other object.
        /// </summary>
        /// <param name="other">An NGram&lt;T&gt; to compare with this instance.
        /// </param>
        /// <returns>A value indicating the relative order of the NGram&lt;T&gt;
        /// objects being compared. If the current instance precedes other, the
        /// return value will be less that zero. A value greater than zero
        /// indicates that the current instance follows other. Zero means they
        /// both have the same sort order.</returns>
        /// <remarks>For N-Gram analysis, sorting should place higher
        /// frequencies first. Therefore, the calculations in this method sort
        /// by the Count property, but descending.</remarks>
        public int CompareTo(NGram<T> other)
        {
            if (other == null) return 1; // Normally, CompareTo would return -1
                                         // in this instance. However, this
                                         // application puts null values at the
                                         // end.
            return this.Count.CompareTo(other.Count) * (-1);	// Gives reverse order.
        }

        /// <summary>
        /// Determines if the Content property of this NGram instance is equal
        /// to another value.
        /// </summary>
        /// <param name="other">A value to compare for equality to the content
        /// of this NGram.</param>
        /// <returns>true if other matches the content of this NGram. Otherwise,
        /// false.</returns>
        public bool Equals(NGram<T> other)
        {
            return EqualityComparer<T>.Default.Equals(this.Content, other.Content);
        }
        #endregion
    }
}
