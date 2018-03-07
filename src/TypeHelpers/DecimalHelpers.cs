using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Util.TypeHelpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class DecimalHelpers
    {
        /// <summary>
        /// Returns the total number of digits excluding the decimal separator.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetPrecision(decimal value)
        {
            return GetLeftNumberOfDigits(value) + GetRightNumberOfDigits(value);
        }

        /// <summary>
        /// Number of digits to the right of the decimal separator without ending zeros.
        /// <para>Ideally, this function returns the scale per the mathematic notation. 
        /// This involves bitwise operations I am not inclined to do at this moment (2017-10-09).
        /// </para>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetScale(decimal value)
        {
            return GetRightNumberOfDigits(value);
        }

        /// <summary>
        /// Number of digits to the right of the decimal separator without ending zeros.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the number of digits to the right of the decimal separator</returns>
        public static int GetRightNumberOfDigits(decimal value)
        {
            var text = GetAbsoluteText(value);
            var decpoint = GetDecimalSeparatorPosition(value);

            if (decpoint < 0)
                return 0;

            return text.Length - decpoint - 1;
        }

        /// <summary>
        /// Number of digits to the left of the decimal separator without starting zeros
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the number of digits to the left of the decimal separator</returns>
        public static int GetLeftNumberOfDigits(decimal value)
        {
            var text = GetAbsoluteText(value);
            var decpoint = GetDecimalSeparatorPosition(value);

            if (decpoint == -1)
                return text.Length;

            return decpoint;
        }

        private static string GetAbsoluteText(decimal value)
        {
            return Math.Abs(value).ToString(System.Globalization.CultureInfo.InvariantCulture).TrimStart('0');
        }

        private static int GetDecimalSeparatorPosition(decimal value)
        {
            return GetAbsoluteText(value).IndexOf(System.Globalization.CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
        }
    }
}
