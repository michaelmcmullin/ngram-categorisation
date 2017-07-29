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
    }
}
