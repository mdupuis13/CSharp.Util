using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CSharp.Util.TypeExtensions.Tests
{
    public class DecimalExtensionTests
    {
        [Theory]
        [InlineData(4,   1123)]
        [InlineData(5,    123.45)]
        [InlineData(5,    223.4500)]
        [InlineData(5, 000323.4500)]
        public void TestGetPrecision(int expected, decimal value)
        {
            Assert.Equal(expected, value.GetPrecision());
        }

        [Theory]
        [InlineData(0,   1123)]
        [InlineData(2,    123.45)]
        [InlineData(2,    223.4500)]
        [InlineData(4, 000323.4501)]
        public void TestGetScale(int expected, decimal value)
        {
            Assert.Equal(expected, value.GetScale());
        }

        [Theory]
        [InlineData(0,   1123)]
        [InlineData(2,    123.45)]
        [InlineData(2,    223.4500)]
        [InlineData(4, 000323.4501)]
        public void TestGetRightNumberOfDigits(int expected, decimal value)
        {
            Assert.Equal(expected, value.GetRightNumberOfDigits());
        }

        [Theory]
        [InlineData(4,   1123)]
        [InlineData(3,    123.45)]
        [InlineData(3,    223.4500)]
        [InlineData(3, 000323.4500)]
        public void TestGetLeftNumberOfDigits(int expected, decimal value)
        {
            Assert.Equal(expected, value.GetLeftNumberOfDigits());
        }
    }
}
