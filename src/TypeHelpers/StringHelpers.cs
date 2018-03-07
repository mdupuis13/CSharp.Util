using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Util.TypeHelpers
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static class StringHelpers
    {
        /// <summary>
        /// Truncates a string to the given length or returns entire string if `maxLength` is greater than value.Length()."/>
        /// </summary>
        /// <param name="value">String to truncate</param>
        /// <param name="maxLength">Maximum lenght of truncated string. Must be positive and greater than 0.</param>
        /// <returns>Truncated string</returns>
        public static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            if (maxLength <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxLength), "must be positive.");

            return value.Substring(0, Math.Min(value.Length, maxLength));
        }
    }
}
