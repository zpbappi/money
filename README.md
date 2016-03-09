# money [![Build status](https://ci.appveyor.com/api/projects/status/a2i35stmhe55vy8h?svg=true)](https://ci.appveyor.com/project/zpbappi/money)

Yet another money class written in C#. 

## Features at a glance
- Generic type for the amount of Money (including your custom type)
- Unary arithmetic
- Binary arithmetic with arbitrary numbers
- Operations involving money of same currency
- Operations involving money of different currencies

## Supported operations
- _unary_operator_ `Money`
- `Money` _unary_operator_
- `number` _binary_operator_ `Money`
- `Money` _binary_operator_ `number`
- `Money` _comparison_operator_ `Money`
- `Money` _binary_operator_ `Money`

## Usage

Create:
```csharp
// create money with decimal type of amount in my currency
var localMoney = new Money<decimal>(100m);

// create Australian dollars 
var aud = new Money<decimal>(42m, "AUD"); 
```

Operate:
```csharp
var m1 = Money<decimal>(100m, "AUD");
var m2 = Money<decimal>(-42m, "AUD");
var m3 = Money<decimal>(3.1415m, "USD");
var m4 = Money<decimal>(1m, "EUR");
var m5 = Money<decimal>(8m, "GBP");

var audWallet = m1 + m2;
var audWalletValueAsMoney = audWallet.EvaluateWithoutConversion();

var multinationalWallet = (m1 % m5) + ((m2 * 3.5m) / m4) - (m3 * 9m);
var currencyConverter = new MyCurrencyConverter(); //this is some you supply
var resultingMoneyInAUD = multinationalWallet.Evaluate(currencyConverter, "AUD");
```

For better explanation of features and other examples, visit this 
[blog post](http://zpbappi.com/multi-currency-generic-money-in-csharp/).