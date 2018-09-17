using System;
using System.Collections.Generic;
using System.Text;

namespace NGrammer
{
    /// <summary>
    /// A class that manages the training and measuring of data sets.
    /// </summary>
    /// <typeparam name="T">The type of data being measured.</typeparam>
    /// <typeparam name="S">An INGramSet implementation that can parse and
    /// measure data of type T.</typeparam>
    public class NGrammer<T, S> where T : IEquatable<T> where S : INGramSet<T>, new()
    {
        /// <summary>
        /// Default constructor, does some initialisation.
        /// </summary>
        public NGrammer()
        {
            trainingSets = new Dictionary<string, S>();
        }

        /// <summary>
        /// A dictionary of named training sets to compare new data to. The
        /// name is used to identify which set is closest
        /// </summary>
        private Dictionary<string, S> trainingSets;

        /// <summary>
        /// Adds a new training set to the collection.
        /// </summary>
        /// <param name="name">The name of the new training set.</param>
        /// <param name="input">The input data of this training set. This will be
        /// parsed by this method.</param>
        public void AddTrainingSet(string name, T input)
        {
            if (trainingSets.ContainsKey(name))
            {
                throw new ArgumentException($"The trainging set name '{name}' already exists.");
            }
            S set = new S();
            set.Parse(input);
            trainingSets.Add(name, set);
        }

        /// <summary>
        /// Find the training set that most closely resembles the supplied
        /// <c>data</c> parameter.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Predict(T data)
        {
            if (trainingSets == null || trainingSets.Count == 0)
            {
                throw new InvalidOperationException("Cannot predict data as there is no training data to compare it with.");
            }
            string output = String.Empty;
            double smallestDistance = -1;
            S predictionSet = new S();
            predictionSet.Parse(data);

            foreach(KeyValuePair<string, S> set in trainingSets)
            {
                S thisSet = set.Value;
                double thisDistance = predictionSet.GetDistance(thisSet);
                if (smallestDistance < 0 || thisDistance < smallestDistance)
                {
                    smallestDistance = thisDistance;
                    output = set.Key;
                }
            }

            return output;
        }
    }
}
