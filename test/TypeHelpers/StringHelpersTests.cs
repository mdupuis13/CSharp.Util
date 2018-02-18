using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CSharp.Util.TypeHelpers.Tests
{
    public class StringTests
    {
        [Fact]
        public void Cannot_truncate_negative_length()
        {
            string testValue = "abc123";

            Assert.Throws<ArgumentOutOfRangeException>(() => StringHelpers.Truncate(testValue, -2));
        }

        [Fact]
        public void Returns_string_if_string_is_lt_maxLength()
        {
            string testValue = "abc123";
            string expected = testValue;

            Assert.Equal(expected, StringHelpers.Truncate(testValue, 10));
        }

        [Fact]
        public void Returns_truncated_string()
        {
            string testValue = "abc123";
            string expected = "abc";

            Assert.Equal(expected, StringHelpers.Truncate(testValue, 3));
        }

    }
}
