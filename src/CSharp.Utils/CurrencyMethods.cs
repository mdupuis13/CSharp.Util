using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.Util.Currency
{
    public partial struct Currency : IEquatable<Currency>
    {
        /// <summary>
        /// Gets the list of available currencies. The returned List&lt;Currency&gt; of currencies contains all of the available currencies, which may include currencies that represent obsolete ISO 4217 codes. The returned list can be modified without affecting the available currencies in the runtime.
        /// </summary>
        /// <returns>List&lt;Currency&gt;</returns>
        public static List<Currency> GetAvailableCurrencies()
        {
            return AllCurrencies.ToList();
        }

        /// <summary>The 3 letters ISO code of the currency</summary>
        /// <returns>string</returns>
        public string GetCurrencyCode()
        {
            return CurrencyCode;
        }

        /// <summary>The ISO minor units of the currency</summary>
        /// <returns>int</returns>
        public int GetDefaultFractionDigits()
        {
            return (int)this.DefaultFractionDigits;
        }

        /// <summary>The ISO name of the currency</summary>
        /// <returns>string</returns>
        public string GetDisplayName()
        {
            return DisplayName;
        }

        /// <summary>Gets a currency by its letter code.</summary>
        /// <param name="currencyCode">The letter code of the desired currency.</param>
        /// <exception cref="System.ArgumentException">
        ///     Thrown when no currency is found with the specified letter code.
        /// </exception>
        public static Currency GetInstance(string currencyCode)
        {
            var filteredCurrencies = Currency.AllCurrencies.Where(currency => currency.CurrencyCode == currencyCode);

            if (filteredCurrencies.Count() > 0)
            {
                return filteredCurrencies.First();
            }

            throw new ArgumentException($"There is no registered currency with the letter code {currencyCode}.");
        }

        /// <summary>The numeric ISO code of the currency</summary>
        /// <returns></returns>
        public int GetNumericCode()
        {
            return int.Parse(NumericCode);
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