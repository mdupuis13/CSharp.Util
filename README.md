# CSharp.Util.Currency
[![license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/mdupuis13/currency/blob/master/LICENSE)
[![Pull Requests](https://img.shields.io/badge/Pull%20Requests-Welcome-brightgreen.svg)](https://github.com/mdupuis13/currency/blob/master/CONTRIBUTING.md)

A simple cross platform currency class library for .Net.

This is a fork of the project [AndreMarcondesTeixeira.Currency](https://github.com/andremarcondesteixeira/currency) by André Marcondes Teixeira. I needed a library that corresponds better to the java.util.Currency library for my [Time and Money](https://github.com/mdupuis13/TimeAndMoneyCSharp) project.

The implementation of this library is compatible with .Net Standard 2.0 (see [https://docs.microsoft.com/en-us/dotnet/standard/net-standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) for details). It uses the `Cultures` from `System.Globalization` namespace.

CSharp.Util.Currency is a value type, i.e, a struct, and has no public constructor, but simple, factory methods that return you the currency instance you want instead.

<!-- ### Installation

Install through NuGet Package Manager:
```
Install-Package currency
``` -->

## Usage
First of all, import the namespace, for convenience:
``` c#
using CSharp.Util.Currency;
```

Then, you can get a currency instance by using one of these methods:

* Calling a factory property, where XXX is the three letters ISO code of the currency:
``` c#
var currency = Currency.XXX;
```

* Using the method GetByLetterCode, where, again, XXX is the three letters ISO code of the currency:
``` c#
var currency = Currency.GetByLetterCode("XXX");
``````

The Currency class have those functions (other than the standard ones):
``` c#
public struct Currency : IEquatable<Currency>
{
    // The 3 letters ISO code of the currency
    public string GetCurrencyCode();

    // The 3 numbers ISO code of the currency
    public string GetNumericCode();

    // The number of decimals of the currency
    public int GetDefaultFractionDigits();

    // The ISO name of the currency
    public string GetDisplayName();

    // The display culture of the currency
    public string GetDisplayCulture();

    // The display symbol ($, £, etc.) of the currency
    public string GetSymbol();
    // The display symbol ($, £, etc.) of the currency in the given CultureInfo
    public string GetSymbol(CultureInfo cultureInfo)
}
```

You can compare currencies using the operators == and !=
``` c#
// returns true
var areCurrenciesEquivalent = (Currency.XXX == Currency.XXX);

// returns false
var areCurrenciesEquivalent = (Currency.XXX != Currency.XXX);
```

You can get a list of all currencies:
``` c#
var allCurrencies = Currency.GetAvailableCurrencies();

foreach (var currency in allCurrencies)
{
    var currencyISOLetterCode = currency.GetCurrencyCode();
    var currencyISONumericCode = currency.GetNumericCode();
    var currencyName = currency.GetDisplayName();
    var currencySymbol = currency.GetSymbol();
    var currencyMinorUnits = currency.GetDefaultFractionDigits();
}
```

## Contributing
You can contribute by doing unit tests, documentation, making pull requests or sharing the project.

See the file [CONTRIBUTING.md](https://github.com/andremarcondesteixeira/currency/blob/master/CONTRIBUTING.md) for more details.
