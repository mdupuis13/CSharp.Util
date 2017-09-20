# CSharp.Util.Currency
[![license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/mdupuis13/currency/blob/master/LICENSE)
[![Pull Requests](https://img.shields.io/badge/Pull%20Requests-Welcome-brightgreen.svg)](https://github.com/mdupuis13/currency/blob/master/CONTRIBUTING.md)

A simple cross platform currency class library for .Net, that follows the ISO 4217 standard.

This is a fork of the project [AndreMarcondesTeixeira.Currency](https://github.com/andremarcondesteixeira/currency) by André Marcondes Teixeira. I needed a library that corresponds better to the java.util.Currency library for my [Time and Money](https://github.com/mdupuis13/TimeAndMoneyCSharp) project.

The implementation of this library is compatible with .Net Standard 1.0 (see [https://docs.microsoft.com/en-us/dotnet/standard/net-standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) for details).

CSharp.Util.Currency is a value type, i.e, a struct, and has no public constructor, but simple, quick methods that return you the currency instance you want instead.

### Installation

Install through NuGet Package Manager:
```
Install-Package currency
```

### Usage
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
```

* Using the method GetByNumericCode, where 999 is the three numbers ISO code of the currency:
``` c#
// Note that the numeric code is a string
var currency = Currency.GetByNumericCode("999");
```

The Currency class have four read only properties:
``` c#
public struct Currency : IEquatable<Currency>
{
    // The 3 letters ISO code of the currency
    public string LetterCode { get; }

    // The ISO minor units of the currency
    public byte MinorUnits { get; }

    // The ISO name of the currency
    public string Name { get; }

    // The numeric ISO code of the currency
    public string NumericCode { get; }
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
var allCurrencies = Currency.AllCurrencies;

foreach (var currency in allCurrencies)
{
    var currencyISOLetterCode = currency.LetterCode;
    var currencyISONumericCode = currency.NumericCode;
    var currencyName = currency.Name;
    var currencyMinorUnits = currency.MinorUnits;
}
```

### Contributing
You can contribute by doing unit tests, documentation, making pull requests or sharing the project.
