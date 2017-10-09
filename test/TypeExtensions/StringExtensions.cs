using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CSharp.Util.TypeExtensions.Tests
{
    public class StringExtensions
    {
        [Fact]
        public void Cannot_truncate_negative_length()
        {
            string testValue = "abc123";

            Assert.Throws<ArgumentOutOfRangeException>(() => testValue.Truncate(-2));
        }

        [Fact]
        public void Returns_string_if_string_is_lt_maxLength()
        {
            string testValue = "abc123";
            string expected = testValue;

            Assert.Equal(expected, testValue.Truncate(10));
        }

        [Fact]
        public void Returns_truncated_string()
        {
            string testValue = "abc123";
            string expected = "abc";

            Assert.Equal(expected, testValue.Truncate(3));
        }

    }
}
