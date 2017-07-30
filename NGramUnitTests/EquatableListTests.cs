using Microsoft.VisualStudio.TestTools.UnitTesting;
using NGramCategorisation;
using System;
using System.Collections.Generic;

namespace NGramUnitTests
{
    [TestClass]
    public class EquatableListTests
    {
        [TestMethod, TestCategory("EquatableList Class")]
        public void EquatableListConstructor_String()
        {
            EquatableList<string> ListOfStrings = new EquatableList<string>();
            Assert.AreEqual(0, ListOfStrings.Count);
        }

        [TestMethod, TestCategory("EquatableList Class")]
        public void EquatableList_CompareEqualLists()
        {
            EquatableList<int> ListOfIntsA = new EquatableList<int>();
            EquatableList<int> ListOfIntsB = new EquatableList<int>();

            ListOfIntsA.AddRange(new List<int> { 1, 2, 3, 4, 5 });
            ListOfIntsB.AddRange(new List<int> { 1, 2, 3, 4, 5 });

            Assert.AreEqual(ListOfIntsA, ListOfIntsB);
        }
    }
}
