using System;
using System.Collections.Generic;
using Xunit;

namespace CSharp.Util.Currency.Tests
{
    public class CurrencyTest
    {
        [Fact]
        public void Currency_Is_A_Value_Type_And_All_Factory_Methods_Return_New_Instances()
        {
            Assert.False(Object.ReferenceEquals(Currency.XXX, Currency.XXX));
            Assert.False(Object.ReferenceEquals(Currency.GetByLetterCode("XXX"), Currency.GetByLetterCode("XXX")));
        }

        [Fact]
        public void Currency_Instances_Can_Be_Created_By_Two_Ways()
        {
            Assert.IsType<Currency>(Currency.XXX);
            Assert.IsType<Currency>(Currency.GetByLetterCode("XXX"));
        }

        [Fact]
        public void Currency_Getter_Methods_Throws_Exception_For_Nonexistent_Currencies()
        {
            Assert.Throws<ArgumentException>(() => Currency.GetByLetterCode("Nonexistent"));
        }

        [Fact]
        public void Currency_Instances_Are_Compared_Through_Their_Whole_Set_Of_Properties()
        {
            Assert.False(Currency.XXX == Currency.XTS);
            Assert.True(Currency.XTS != Currency.XXX);
        }

        [Fact]
        public void There_Is_A_Publicly_Visible_Readonly_List_Of_All_Currencies()
        {
            var result = Currency.GetAvailableCurrencies();
            Assert.IsType<List<Currency>>(result);
            Assert.Equal(178, result.Count);
        }

        [Fact]
        public void Can_Get_All_Properties_Of_A_Currency()
        {
            Currency usd = Currency.USD;

            Assert.Equal("USD", usd.GetCurrencyCode());
            Assert.Equal(840, usd.GetNumericCode());
            Assert.Equal("US Dollar", usd.GetDisplayName());
            Assert.Equal(2, usd.GetDefaultFractionDigits());

        }

        [Fact]
        public void Can_Compare_Two_Currencies()
        {
            Currency cad1 = Currency.CAD;
            Currency cad2 = Currency.CAD;
            Assert.True(cad1.Equals(cad2));
        }
    }
}