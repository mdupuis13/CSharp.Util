
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using Xunit;

namespace CSharp.Util.Currency.Tests
{
    public class CurrencyCultureInfoTests
    {

        private CultureInfo _culture;

        public CurrencyCultureInfoTests()
        {
            _culture = Thread.CurrentThread.CurrentCulture;
        }

        ~CurrencyCultureInfoTests()
        {
            // Cleanup statements.
            Thread.CurrentThread.CurrentCulture = _culture;
        }

        [Fact]
        public void Can_create_currency_using_currency_code()
        {
            Currency currency = Currency.NZD;
            Assert.NotNull(currency);
        }


        [Fact]
        public void Currency_creation_creates_meaningful_display_cultures()
        {
            // If I'm from France, and I reference Canadian Dollars,
            // then the default culture for CAD should be fr-CA
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            Currency currency = Currency.CAD;
            Assert.Equal(new CultureInfo("fr-CA"), currency.GetDisplayCulture());

            // If I'm from England, and I reference Canadian Dollars,
            // then the default culture for CAD should be en-CA
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            currency = Currency.CAD;
            Assert.Equal(new CultureInfo("en-CA"), currency.GetDisplayCulture());

            // If I'm from Germany, and I reference Canadian Dollars,
            // then the default culture for CAD should be en-CA
            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
            currency = Currency.CAD;
            Assert.Equal(new CultureInfo("en-CA"), currency.GetDisplayCulture());

            // ... and it should not display as if it were in de currency!
            decimal money = new decimal(1000);
            string displayAsCurrency = money.ToString("c", currency.GetDisplayCulture().NumberFormat);
            Assert.Equal("$1,000.00", displayAsCurrency);


            // ... but if I want it in de format, it should display correctly.
            /* 
             * Fact commented because there might be a bug in .NET's culture info handling.
             * We should be getting en-CA but we have moh-CA instead. 
             * My computer is setup to use en-CA CultureInfo
             */
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            money = new decimal(1000);
            var result = money.ToString("c", new CultureInfo("de-DE").NumberFormat);
            Assert.Equal("1.000,00 €", result);
            //Console.WriteLine(money.DisplayIn(german));  // Output: $1.000,00
        }

        [Fact]
        public void Currency_creation_creates_meaningful_native_regions()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            Currency currency = Currency.EUR;
            Assert.Equal(currency.GetNativeRegion(), new RegionInfo("FR"));

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            currency = Currency.CAD;
            Assert.Equal(currency.GetNativeRegion(), new RegionInfo("CA"));
        }
    }
}
