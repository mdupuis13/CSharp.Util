using System;

namespace CSharp.Util.Currency
{
    /// <summary>
    ///     The <see cref="Currency" /> class follows ISO 4217:2015, providing an easy way
    ///     to represent ISO currencies.
    ///     <para>
    ///         This class mimics the <code>java.util.Currency</code> package as described in Oracle's javaSE 8 documentation https://docs.oracle.com/javase/8/docs/api/java/util/Currency.html. 
    ///     </para>
    ///     <para>
    ///         Some methods are missing, most notably all methods receiving a Locale in a parameter. I might add them one day... or maybe you can ? Pull requests are welcomed.<br />
    ///         <code>getSymbol()</code> is also missing. This also needs Locale support to work correctly.
    ///     </para>
    /// </summary>
    /// <remarks>
    ///     All currencies are represented, except for "ANTARCTICA", "PALESTINE, STATE OF"
    ///     and "SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS", because ISO describes those
    ///     as "no universal currency", and gives them no identification codes.
    ///     <para>
    ///         The <see cref="Currency" /> class does not provide the list of countries
    ///         that use each currency.
    ///     </para>
    ///     <para>
    ///         For more information:
    ///         <see href="https://www.currency-iso.org/en/home.html">
    ///             https://www.currency-iso.org/en/home.html
    ///         </see> and
    ///         <see href="https://www.iso.org/standard/64758.html">
    ///             https://www.iso.org/standard/64758.html
    ///         </see>
    ///     </para>
    /// </remarks>
    public partial struct Currency : IEquatable<Currency>
    {
        /// <summary>The 3 letters ISO code of the currency</summary>
        private string CurrencyCode;

        /// <summary>The ISO minor units of the currency</summary>
        private byte DefaultFractionDigits;

        /// <summary>The ISO name of the currency</summary>
        private string DisplayName;

        /// <summary>The numeric ISO code of the currency</summary>
        private string NumericCode;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Currency" /> class.
        /// </summary>
        /// <remarks>
        ///     Instead of using the constructor, use the static, lazy loaded properties of
        ///     the <see cref="Currency" /> class.
        /// </remarks>
        /// <example>
        ///     This sample shows you how to get an instance of a currency, where "XXX" is
        ///     the 3 letters ISO code of the currency, and "999" is the 3 digits numeric
        ///     ISO code of the currency:
        ///     <code>
        ///         var currency = Currency.XXX;
        ///         var currency = Currency.GetByLetterCode("XXX");
        ///         var currency = Currency.GetByNumericCode("999");
        ///     </code>
        /// </example>
        /// <param name="currencyCode">The 3 letters ISO code of the Currency.</param>
        /// <param name="numericCode">The 3 digits numeric ISO code of the Currency.</param>
        /// <param name="defaultFractionDigits">The ISO minor units of the Currency.</param>
        /// <param name="displayName">The ISO name of the Currency.</param>
        private Currency(string currencyCode, string numericCode, byte defaultFractionDigits, string displayName)
        {
            this.CurrencyCode = currencyCode;
            this.NumericCode = numericCode;
            this.DefaultFractionDigits = defaultFractionDigits;
            this.DisplayName = displayName;
        }
    }
}