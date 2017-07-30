using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NGramCategorisation
{
    /// <summary>
    /// Represents a strongly typed list that can be accessed by index. It also
    /// implements IEquatable, making it suitable for use in NGrams.
    /// </summary>
    /// <typeparam name="T">The type of element in the EquatableList&lt;T&gt;.
    /// </typeparam>
    public class EquatableList<T> : IList<T>, IEquatable<EquatableList<T>> where T: IEquatable<T>
    {
        private List<T> collection = new List<T>();

        #region IList Implementation
        /// <summary>
        /// Gets or sets the element at the specified index
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or
        /// set.</param>
        /// <returns>The element at the given index.</returns>
        /// <exception cref="ArgumentOutOfRangeException">index is less than
        /// zero or index is greater than count.</exception>
        public T this[int index]
        {
            get { return collection[index]; }
            set { collection[index] = value; }
        }

        /// <summary>
        /// Gets the number of elements in this collection.
        /// </summary>
        public int Count => collection.Count;

        /// <summary>
        /// Gets a value indicating whether this collection is read only.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds an object to the end of the EquatableList&lt;T&gt;.
        /// </summary>
        /// <param name="item">The object to be added to the end of the
        /// EquatableList&lt;T&gt;.</param>
        public void Add(T item)
        {
            collection.Add(item);
        }

        /// <summary>
        /// Removes all elements from the EquatableList&lt;T&gt;.
        /// </summary>
        public void Clear()
        {
            collection.Clear();
        }

        /// <summary>
        /// Determines whether an element is in the EquatableList&lt;T&gt;.
        /// </summary>
        /// <param name="item">The object to locate in the
        /// EquatableList&lt;T&gt;.</param>
        /// <returns>true if item is found in the EquatableList&lt;T&gt;.
        /// Otherwise, false.</returns>
        public bool Contains(T item)
        {
            return collection.Contains(item);
        }

        /// <summary>
        /// Copies the entire EquatableList&lt;T&gt; to a compatible
        /// one-dimensional array, starting at the specified index of the target
        /// array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the
        /// destination of the elements copied from EquatableList&lt;T&gt;. The
        /// Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which
        /// copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            collection.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the
        /// EquatableList&lt;T&gt;.
        /// </summary>
        /// <returns>An EquatableList&lt;T&gt;.Enumerator for the
        /// EquatableList&lt;T&gt;.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index
        /// of the first occurrence within the entire EquatableList&lt;T&gt;.
        /// </summary>
        /// <param name="item">The object to locate in the
        /// EquatableList&lt;T&gt;.</param>
        /// <returns>The zero-based index of the first occurrence of item within
        /// the entire EquatableList&lt;T&gt;, if found; otherwise, –1.
        /// </returns>
        public int IndexOf(T item)
        {
            return collection.IndexOf(item);
        }

        /// <summary>
        /// Inserts an element into the EquatableList&lt;T&gt; at the specified
        /// index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be
        /// inserted.</param>
        /// <param name="item">The object to insert.</param>
        public void Insert(int index, T item)
        {
            collection.Insert(index, item);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the
        /// EquatableList&lt;T&gt;.
        /// </summary>
        /// <param name="item">The object to remove from the
        /// EquatableList&lt;T&gt;.</param>
        /// <returns>true if item is successfully removed; otherwise, false.
        /// This method also returns false if item was not found in the
        /// EquatableList&lt;T&gt;.</returns>
        public bool Remove(T item)
        {
            return collection.Remove(item);
        }

        /// <summary>
        /// Removes the element at the specified index of the
        /// EquatableList&lt;T&gt;.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.
        /// </param>
        public void RemoveAt(int index)
        {
            collection.RemoveAt(index);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the
        /// EquatableList&lt;T&gt;.
        /// </summary>
        /// <returns>An EquatableList&lt;T&gt;.Enumerator for the
        /// EquatableList&lt;T&gt;.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Indicates whether the current object is equal to another object of
        /// the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter,
        /// or if each item in the other EquatableList&lt;T&gt; matches each
        /// item in this one; otherwise, false.</returns>
        public bool Equals(EquatableList<T> other)
        {
            if (other == null) return false;
            if (this.Count != other.Count) return false;
            if (ReferenceEquals(this, other)) return true;

            for (int i=0; i<this.Count; i++)
            {
                if (!this[i].Equals(other[i]))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Determines whether the specified object is equal to the current
        /// object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.
        /// </param>
        /// <returns>true if the specified object is equal to the current
        /// object; otherwise, false.</returns>
        public override bool Equals(object other)
        {
            if ((other == null) || !this.GetType().Equals(other.GetType()))
            {
                return false;
            }
            else
            {
                EquatableList<T> otherEquatableList = (EquatableList<T>) other;
                return this.Equals(otherEquatableList);
            }
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return collection.GetHashCode();
        }
        #endregion

        #region Miscellaneous Methods
        /// <summary>
        /// Adds the elements of the specified collection to the end of the
        /// EquatableList&lt;T&gt;.
        /// </summary>
        /// <param name="items">The collection whose elements should be added to
        /// the end of the EquatableList&lt;T&gt;.</param>
        public void AddRange(IEnumerable<T> items)
        {
            collection.AddRange(items);
        }
        #endregion
    }
}
