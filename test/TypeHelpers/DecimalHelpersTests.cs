using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CSharp.Util.TypeHelpers.Tests
{
    public class DecimalTests
    {
        [Theory]
        [InlineData(4,   1123)]
        [InlineData(5,    123.45)]
        [InlineData(5,    223.4500)]
        [InlineData(5, 000323.4500)]
        public void TestGetPrecision(int expected, decimal value)
        {
            Assert.Equal(expected, DecimalHelpers.GetPrecision(value));
        }

        [Theory]
        [InlineData(0,   1123)]
        [InlineData(2,    123.45)]
        [InlineData(2,    223.4500)]
        [InlineData(4, 000323.4501)]
        public void TestGetScale(int expected, decimal value)
        {
            Assert.Equal(expected, DecimalHelpers.GetScale(value));
        }

        [Theory]
        [InlineData(0,   1123)]
        [InlineData(2,    123.45)]
        [InlineData(2,    223.4500)]
        [InlineData(4, 000323.4501)]
        public void TestGetRightNumberOfDigits(int expected, decimal value)
        {
            Assert.Equal(expected, DecimalHelpers.GetRightNumberOfDigits(value));
        }

        [Theory]
        [InlineData(4,   1123)]
        [InlineData(3,    123.45)]
        [InlineData(3,    223.4500)]
        [InlineData(3, 000323.4500)]
        public void TestGetLeftNumberOfDigits(int expected, decimal value)
        {
            Assert.Equal(expected, DecimalHelpers.GetLeftNumberOfDigits(value));
        }
    }
}
