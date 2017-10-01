using System;
using System.Globalization;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace CSharp.Util.Currency
{
    /// <summary>
    ///     The <see cref="Currency" /> class follows ISO 4217:2015, providing an easy way to represent ISO currencies.
    ///     <para>
    ///         This class ressembles the <code>java.util.Currency</code> package as described in Oracle's javaSE 8 documentation https://docs.oracle.com/javase/8/docs/api/java/util/Currency.html. 
    ///     </para>
    ///     <para>
    ///     
    ///     </para>
    /// </summary>
    /// <remarks>
    ///     All currencies are represented, except for "ANTARCTICA", "PALESTINE, STATE OF"
    ///     and "SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS", because ISO describes those
    ///     as "no universal currency", and gives them no identification codes.
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
        /// <summary>
        /// The 3 letters ISO code of the currency
        /// </summary>
        private string _currencyCode;

        /// <summary>
        /// The ISO minor units of the currency
        /// </summary>
        private byte _defaultFractionDigits;

        /// <summary>
        /// The ISO name of the currency
        /// </summary>
        private string _displayName;

        /// <summary>
        /// The numeric ISO code of the currency
        /// </summary>
        private string _numericCode;

        /// <summary>
        /// The CultureInfo associated with the currencycode
        /// </summary>
        private CultureInfo _cultureInfo;

        /// <summary>
        /// 
        /// </summary>
        private static readonly IDictionary<string, CultureInfo> _cultures;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Currency" /> class.
        /// </summary>
        /// <remarks>
        ///     Instead of using the constructor, use the static, lazy loaded properties of
        ///     the <see cref="Currency" /> class.
        /// </remarks>
        /// <example>
        ///     This sample shows you how to get an instance of a currency, where "XXX" is
        ///     the 3 letters ISO code of the currency:
        ///     <code>
        ///         var currency = Currency.XXX;
        ///         var currency = Currency.GetByLetterCode("XXX");
        ///     </code>
        /// </example>
        /// <param name="currencyCode">The 3 letters ISO code of the Currency.</param>
        /// <param name="numericCode">The 3 digits numeric ISO code of the Currency.</param>
        /// <param name="defaultFractionDigits">The ISO minor units of the Currency.</param>
        /// <param name="displayName">The ISO name of the Currency.</param>        
        private Currency(string currencyCode, string numericCode, byte defaultFractionDigits, string displayName)
        {
            

            _currencyCode = currencyCode;
            _numericCode = numericCode;
            _defaultFractionDigits = defaultFractionDigits;
            _displayName = displayName;

            _cultureInfo = GetDisplayCultureFromCurrencyCodeAndUserCulture(_currencyCode);
        }

        static Currency()
        {
            _cultures = GetCultures();
        }

        private static RegionInfo GetNativeRegionFromCurrencyCodeAndUserCulture(string currencyCode, out CultureInfo fallbackCulture)
        {
            // Get the current culture and region
            var userCulture = CultureInfo.CurrentCulture;
            var userLanguageName = userCulture.TwoLetterISOLanguageName;
            var userRegionName = new RegionInfo(userCulture.LCID).TwoLetterISORegionName;

            if (currencyCode == "XXX")
            {
                fallbackCulture = userCulture;
                return new RegionInfo(userCulture.LCID);
            }

            // Get all regions with the given currency (pivot on language to avoid losing precision)
            var locales = (from c in CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                           let r = new RegionInfo(c.LCID)
                           where r.ISOCurrencySymbol.Equals(currencyCode)
                           select new { Region = r, Culture = c }).ToList();

            // Resolve the native region to the one the user is in, or the first valid one
            var locale = locales.SingleOrDefault(l => l.Region.TwoLetterISORegionName.Equals(userRegionName) &&
                                                      l.Culture.TwoLetterISOLanguageName.Equals(userLanguageName)
                                                );

            fallbackCulture = null;

            if (locale == null)
            {
                // There was no logical match for this currency in the current culture;
                // choose the most used equivalent for the native country as a fallback
                locale = locales.FirstOrDefault();

                // still no locale, then fallback to the thread's current culture.
                if (locale == null)
                {
                    fallbackCulture = CultureInfo.CurrentCulture;
                    return new RegionInfo(userCulture.LCID);
                }
                else
                {
                    fallbackCulture = locale.Culture;
                }
            }

            return locale?.Region;
        }

        private static CultureInfo GetDisplayCultureFromCurrencyCodeAndUserCulture(string currencyCode)
        {
            var userCulture = CultureInfo.CurrentCulture;
            var languageCode = userCulture.TwoLetterISOLanguageName;

            CultureInfo fallbackCulture;
            var nativeRegion = GetNativeRegionFromCurrencyCodeAndUserCulture(currencyCode, out fallbackCulture);

            var cultureName = string.Format("{0}-{1}", languageCode, nativeRegion);
            var cultureInfo = !CultureInfo.GetCultureInfo(cultureName).DisplayName.Contains("Unknown Locale")
                                  ? new CultureInfo(cultureName)
                                  : fallbackCulture;

            return cultureInfo;
        }

        private static IDictionary<string, CultureInfo> GetCultures()
        {
            var allCultures = CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Where(c => !c.IsNeutralCulture && 
                            !c.ThreeLetterISOLanguageName.Equals("IVL", StringComparison.InvariantCultureIgnoreCase) && 
                            !c.ThreeLetterISOLanguageName.Equals("XXX", StringComparison.InvariantCultureIgnoreCase));

            var cultures = new Dictionary<string, CultureInfo>(0);
            foreach (var culture in allCultures)
            {
                cultures.Add(culture.Name, culture);
            }

            return cultures;
        }
    }
}