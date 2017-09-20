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
            Assert.False(Object.ReferenceEquals(Currency.GetInstance("XXX"), Currency.GetInstance("XXX")));
        }

        [Fact]
        public void Currency_Instances_Can_Be_Created_By_Two_Ways()
        {
            Assert.IsType(typeof(Currency), Currency.XXX);
            Assert.IsType(typeof(Currency), Currency.GetInstance("XXX"));
        }

        [Fact]
        public void Currency_Getter_Methods_Throws_Exception_For_Nonexistent_Currencies()
        {
            Assert.Throws<ArgumentException>(() => Currency.GetInstance("Nonexistent"));
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
            Assert.IsType(typeof(List<Currency>), Currency.GetAvailableCurrencies());
            Assert.Equal(178, Currency.GetAvailableCurrencies().Count);
        }

        [Fact]
        public void Can_Get_All_Properties_Of_A_Currency()
        {
            Currency usd = Currency.USD;

            Assert.Equal(usd.GetCurrencyCode(), "USD");
            Assert.Equal(usd.GetNumericCode(), 840);
            Assert.Equal(usd.GetDisplayName(), "US Dollar");
            Assert.Equal(usd.GetDefaultFractionDigits(), 2);

        }
    }
}