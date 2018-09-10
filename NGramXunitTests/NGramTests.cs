using NGramCategorisation;
using System;
using System.Collections.Generic;
using Xunit;

namespace NGramXunitTests
{
    public class NGramTests
    {
        [Fact]
        public void NGramConstructor_String()
        {
            NGram<string> StringNGram = new NGram<string>("abc");
            Assert.Equal("abc", StringNGram.Content);
            Assert.Equal(1, StringNGram.Count);
        }

        [Fact]
        public void NGramConstructor_Int()
        {
            NGram<int> IntNGram = new NGram<int>(12);
            Assert.Equal(12, IntNGram.Content);
            Assert.Equal(1, IntNGram.Count);
        }

        [Fact]
        public void NGramConstructor_ListOfFloats()
        {
            EquatableList<float> ListOfFloats = new EquatableList<float>();
            ListOfFloats.AddRange(new List<float> { 10.3f, 16.1f, 12.1f });

            NGram<EquatableList<float>> FloatListNGram = new NGram<EquatableList<float>>(ListOfFloats);
            Assert.Equal(ListOfFloats, FloatListNGram.Content);
            Assert.Equal(1, FloatListNGram.Count);
        }
    }
}
