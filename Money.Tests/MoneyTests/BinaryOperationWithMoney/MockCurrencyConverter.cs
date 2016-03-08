using System;
using System.Collections.Generic;

namespace Money.Tests.MoneyTests.BinaryOperationWithMoney
{
    public class MockCurrencyConverter : ICurrencyConverter<decimal>
    {
        private readonly IDictionary<string, decimal> conversionRates;

        public MockCurrencyConverter()
        {
            this.conversionRates = new Dictionary<string, decimal>();
        }

        public void RegisterConversionRate(string fromCurrency, string toCurrency, decimal rate)
        {
            var key = string.Format("{0}-{1}", fromCurrency.ToUpperInvariant(), toCurrency.ToUpperInvariant());
            this.conversionRates[key] = rate;
            key = string.Format("{0}-{1}", toCurrency.ToUpperInvariant(), fromCurrency.ToUpperInvariant());
            this.conversionRates[key] = 1m/rate;
        }

        public decimal Convert(decimal fromAmount, string fromCurrency, string toCurrency)
        {
            if(string.Equals(fromCurrency, toCurrency, StringComparison.InvariantCultureIgnoreCase))
                return fromAmount;

            var key = string.Format("{0}-{1}", fromCurrency.ToUpperInvariant(), toCurrency.ToUpperInvariant());

            if(!this.conversionRates.ContainsKey(key))
                throw new KeyNotFoundException("Cannot find the conversion rate " + key);

            return this.conversionRates[key]*fromAmount;
        }
    }
}