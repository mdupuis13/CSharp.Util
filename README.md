# CSharp.Util
[![license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/mdupuis13/CSharp.Util/blob/master/LICENSE)
[![Pull Requests](https://img.shields.io/badge/Pull%20Requests-Welcome-brightgreen.svg)](https://github.com/mdupuis13/CSharp.Util/blob/master/CONTRIBUTING.md)

Collection of useful classes and functions organized into logical namespaces. Those items are useful to me and I hope they can be useful to others also.

## CSharp.Util.Currency

A simple cross platform currency class library for .Net.

This is a fork of the project [AndreMarcondesTeixeira.Currency](https://github.com/andremarcondesteixeira/currency) by André Marcondes Teixeira. I needed a library that corresponds better to the java.util.Currency library for my [Time and Money](https://github.com/mdupuis13/TimeAndMoneyCSharp) project.

The implementation of this library is compatible with .Net Standard 2.0 (see [https://docs.microsoft.com/en-us/dotnet/standard/net-standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) for details). It uses the `Cultures` from `System.Globalization` namespace.

CSharp.Util.Currency is a value type, i.e, a struct, and has no public constructor, but simple, factory methods that return you the currency instance you want instead.

<!-- ### Installation

Install through NuGet Package Manager:
```
Install-Package currency
``` -->

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
``````

The Currency class have those functions (other than the standard ones):
``` c#
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
```

You can compare currencies using the operators == and !=
``` c#
// returns true
bool areCurrenciesEquivalent = (Currency.XXX == Currency.XXX);

// returns false
bool areCurrenciesEquivalent = (Currency.XXX != Currency.XXX);
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

## CSharp.Util.TypeHelpers
Different helper methods for `C#`'s built-in types.

### Usage
First of all, import the namespace, for convenience:
``` c#
using CSharp.Util.TypeHelpers;
```

Then, you can use one of the type helper methods:

### StringHelpers
#### `string Truncate(int maxLength)`
Truncates a string to `maxLength` if possible.
``` c#
string helloWorld = "Hello World !";
Console.WriteLine(helloWorld.Truncate(5));

// The example displays the following output:
//          Hello
```

### DecimalHelpers
#### `int GetPrecision()`
Returns thee number of digits. Counts only digits, excluding the decimal separator.
``` c#
decimal myDecimal = 123.45;
Console.WriteLine(myDecimal.GetPrecision());

// The example displays the following output:
//          5
```

#### `int GetScale()`
Number of digits to the right of the decimal separator without ending zeros.
``` c#
decimal myDecimal = 123.45;
Console.WriteLine(myDecimal.GetScale());

// The example displays the following output:
//          2
```

#### `int GetRightNumberOfDigits()`
Number of digits to the right of the decimal separator without ending zeros.
``` c#
decimal myDecimal = 123.4500;
Console.WriteLine(myDecimal.GetRightNumberOfDigits());

decimal myDecimal = 123.45;
Console.WriteLine(myDecimal.GetRightNumberOfDigits());

// The example displays the following output:
//          2
//          2
```

#### `int GetLeftNumberOfDigits()`
Number of digits to the left of the decimal separator without starting zeros.
``` c#
decimal myDecimal = 00123.45;
Console.WriteLine(myDecimal.GetLeftNumberOfDigits());

decimal myDecimal = 1,123.45;
Console.WriteLine(myDecimal.GetLeftNumberOfDigits());

// The example displays the following output:
//          3
//          4
```

## Contributing
You can contribute by doing unit tests, documentation, making pull requests or sharing the project.

See the file [CONTRIBUTING.md](https://github.com/mdupuis13/CSharp.Util/blob/master/CONTRIBUTING.md) for more details.
