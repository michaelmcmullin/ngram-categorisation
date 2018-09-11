using NGrammer;
using System;
using System.Collections.Generic;
using Xunit;

namespace NGramXunitTests
{
    public class EquatableListTests
    {
        [Fact]
        public void EquatableListConstructor_String()
        {
            EquatableList<string> ListOfStrings = new EquatableList<string>();
            Assert.Empty(ListOfStrings);
        }

        [Fact]
        public void EquatableList_CompareEqualLists()
        {
            EquatableList<int> ListOfIntsA = new EquatableList<int>();
            EquatableList<int> ListOfIntsB = new EquatableList<int>();

            ListOfIntsA.AddRange(new List<int> { 1, 2, 3, 4, 5 });
            ListOfIntsB.AddRange(new List<int> { 1, 2, 3, 4, 5 });

            Assert.Equal(ListOfIntsA, ListOfIntsB);
        }
    }
}
