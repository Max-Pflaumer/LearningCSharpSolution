using System;
using Xunit;

namespace LearningCSharp
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(4, 2 + 2);
        }

        [Theory]
        [InlineData(2,3,5)]
        [InlineData(10, 5, 15)]
        [InlineData(9, 3, 12)]
        public void CanAdd(int a, int b, int expected)
        {
            int answer = a + b;
            Assert.Equal(expected, answer);
        }
    }
}
