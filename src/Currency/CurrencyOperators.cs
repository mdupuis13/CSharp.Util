using System;

namespace CSharp.Util.Currency
{
    public partial struct Currency : IEquatable<Currency>
    {
        /// <summary>
        /// Compares the equality of two currencies.
        /// </summary>
        /// <remarks>
        ///     The instances of <see cref="Currency" /> class are compared through their
        ///     whole set of properties.
        /// </remarks>
        public static bool operator == (Currency a, Currency b)
        {
            return AreEquivalent(a, b);
        }

        /// <summary>
        /// Compares the inequality of two currencies.
        /// </summary>
        /// <remarks>
        ///     The instances of <see cref="Currency" /> class are compared through their
        ///     whole set of properties.
        /// </remarks>
        public static bool operator != (Currency a, Currency b)
        {
            return !AreEquivalent(a, b);
        }

        /// <summary>
        /// Compares the equality of two currencies.
        /// </summary>
        /// <remarks>
        ///     The instances of <see cref="Currency" /> class are compared through their
        ///     whole set of properties.
        /// </remarks>
        /// <param name="currency">An instance of <see cref="Currency" /></param>
        public override bool Equals(object currency)
        {
            return AreEquivalent(this, (Currency) currency);
        }

        /// <summary>
        /// Compares the equality of two currencies.
        /// </summary>
        /// <remarks>
        ///     The instances of <see cref="Currency" /> class are compared through their
        ///     whole set of properties.
        /// </remarks>
        /// <param name="currency">An instance of <see cref="Currency" /></param>
        public bool Equals(Currency currency)
        {
            return AreEquivalent(this, currency);
        }

        


        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The hash code is taken from the base class Object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private static bool AreEquivalent(Currency a, Currency b)
        {
            return
                a._numericCode == b._numericCode
                && a._currencyCode == b._currencyCode
                && a._defaultFractionDigits == b._defaultFractionDigits
                && a._displayName == b._displayName;
        }
    }
}