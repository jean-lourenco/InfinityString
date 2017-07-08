using System;
using System.Linq;
using System.Text;
using InfinityStringLib;
using Xunit;

namespace InfinityStringTest
{
    public class Test
    {
        [Theory]
        [InlineData("")]
        [InlineData("o")]
        [InlineData("ol")]
        [InlineData("olá")]
        [InlineData("inconstitucionalmente")]
        public void InfinityString_Should_Word_Normally_With_Valid_Indexes(string baseWord)
        {
            var infinity = new InfinityString(baseWord);

            for (var i = 0; i < baseWord.Length; i++)
            {
                Assert.Equal(infinity[i], baseWord[i]);
            }
        }

        [Theory]
        [InlineData("")]
        [InlineData("o")]
        [InlineData("ol")]
        [InlineData("olá")]
        [InlineData("inconstitucionalmente")]
        public void InfinityString_Should_Run_Forever_With_Enumerator(string baseWord)
        {
            var infinity = new InfinityString(baseWord);
            var expected = $"{baseWord}{baseWord}{baseWord}";
            var index = 0;

            foreach (var wordPair in expected.Zip(infinity, (v1, v2) => new { Expected = v1, Infinity = v2}))
            {
                Assert.Equal(wordPair.Expected, wordPair.Infinity);
                                
                if (++index == expected.Length)
                    break;
            }
        }

        [Theory]
        [InlineData("")]
        [InlineData("o")]
        [InlineData("ol")]
        [InlineData("olá")]
        [InlineData("inconstitucionalmente")]
        public void InfinityString_Should_Run_Forever_With_Indexes_Longer_Than_BaseWord(string baseWord)
        {
            var infinity = new InfinityString(baseWord);
            var expected = $"{baseWord}{baseWord}{baseWord}";

            for (var i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], infinity[i]);
            }
        }

        [Fact]
        public void InfinityString_Should_Not_Accept_Null_Values()
        {
            Assert.Throws<ArgumentNullException>(() => new InfinityString(null));
        }
    }
}
