using Microsoft.VisualStudio.TestTools.UnitTesting;
using NGramCategorisation;
using System;
using System.Collections.Generic;

namespace NGramUnitTests
{
    [TestClass]
    public class NGramTests
    {
        [TestMethod, TestCategory("NGram Class")]
        public void NGramConstructor_String()
        {
            NGram<string> StringNGram = new NGram<string>("abc");
            Assert.AreEqual("abc", StringNGram.Content);
            Assert.AreEqual(1, StringNGram.Count);
        }

        [TestMethod, TestCategory("NGram Class")]
        public void NGramConstructor_Int()
        {
            NGram<int> IntNGram = new NGram<int>(12);
            Assert.AreEqual(12, IntNGram.Content);
            Assert.AreEqual(1, IntNGram.Count);
        }

        [TestMethod, TestCategory("NGram Class")]
        public void NGramConstructor_ListOfFloats()
        {
            EquatableList<float> ListOfFloats = new EquatableList<float>();
            ListOfFloats.AddRange(new List<float>{ 10.3f, 16.1f, 12.1f});

            NGram<EquatableList<float>> FloatListNGram = new NGram<EquatableList<float>>(ListOfFloats);
            Assert.AreEqual(ListOfFloats, FloatListNGram.Content);
            Assert.AreEqual(1, FloatListNGram.Count);
        }
    }
}
