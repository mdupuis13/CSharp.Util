using System;

namespace CSharp.Util.Currency
{
    public partial struct Currency : IEquatable<Currency>
    {
        /// <summary>Compares the equality of two currencies.</summary>
        /// <remarks>
        ///     The instances of <see cref="Currency" /> class are compared through their
        ///     whole set of properties.
        /// </remarks>
        public static bool operator == (Currency a, Currency b)
        {
            return AreEquivalent(a, b);
        }

        /// <summary>Compares the inequality of two currencies.</summary>
        /// <remarks>
        ///     The instances of <see cref="Currency" /> class are compared through their
        ///     whole set of properties.
        /// </remarks>
        public static bool operator != (Currency a, Currency b)
        {
            return !AreEquivalent(a, b);
        }

        /// <summary>Compares the equality of two currencies.</summary>
        /// <remarks>
        ///     The instances of <see cref="Currency" /> class are compared through their
        ///     whole set of properties.
        /// </remarks>
        /// <param name="currency">An instance of <see cref="Currency" /></param>
        public override bool Equals(object currency)
        {
            return AreEquivalent(this, (Currency) currency);
        }

        /// <summary>Compares the equality of two currencies.</summary>
        /// <remarks>
        ///     The instances of <see cref="Currency" /> class are compared through their
        ///     whole set of properties.
        /// </remarks>
        /// <param name="currency">An instance of <see cref="Currency" /></param>
        public bool Equals(Currency currency)
        {
            return AreEquivalent(this, currency);
        }

        /// <remarks>The hash code is taken from the base class Object.</remarks>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private static bool AreEquivalent(Currency a, Currency b)
        {
            return
                a.NumericCode == b.NumericCode
                && a.CurrencyCode == b.CurrencyCode
                && a.DefaultFractionDigits == b.DefaultFractionDigits
                && a.DisplayName == b.DisplayName;
        }
    }
}