using System;
using System.Linq;

namespace CSharp.Util.Currency
{
    public partial struct Currency : IEquatable<Currency>
    {
        /// <summary>The 3 letters ISO code of the currency</summary>
        /// <returns>string</returns>
        public string GetCurrencyCode()
        {
            return LetterCode;
        }

        /// <summary>The ISO minor units of the currency</summary>
        /// <returns>int</returns>
        public int GetDefaultFractionDigits()
        {
            return (int)this.MinorUnits;
        }

        /// <summary>The ISO name of the currency</summary>
        /// <returns>string</returns>
        public string GetDisplayName()
        {
            return Name;
        }

        /// <summary>The numeric ISO code of the currency</summary>
        /// <returns></returns>
        public int GetNumericCode()
        {
            return int.Parse(NumericCode);
        }

        /// <summary>Gets a currency by its letter code.</summary>
        /// <param name="letterCode">The letter code of the desired currency.</param>
        /// <exception cref="System.ArgumentException">
        ///     Thrown when no currency is found with the specified letter code.
        /// </exception>
        public static Currency GetInstance(string letterCode)
        {
            var filteredCurrencies = Currency.AllCurrencies.Where(currency => currency.LetterCode == letterCode);

            if (filteredCurrencies.Count() > 0)
            {
                return filteredCurrencies.First();
            }

            throw new ArgumentException($"There is no registered currency with the letter code {letterCode}.");
        }

        /// <summary>
        /// The 3 letters ISO code of the currency
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return GetCurrencyCode();
        }
    }
}