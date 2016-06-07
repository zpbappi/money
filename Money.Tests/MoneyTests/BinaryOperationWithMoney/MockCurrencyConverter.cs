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

        public void RegisterConversionRate(Currency fromCurrency, Currency toCurrency, decimal rate)
        {
            var key = string.Format("{0}-{1}", fromCurrency, toCurrency);
            this.conversionRates[key] = rate;
            key = string.Format("{0}-{1}", toCurrency, fromCurrency);
            this.conversionRates[key] = 1m/rate;
        }

        public decimal Convert(decimal fromAmount, Currency fromCurrency, Currency toCurrency)
        {
            if(fromCurrency == toCurrency)
                return fromAmount;

            var key = string.Format("{0}-{1}", fromCurrency, toCurrency);

            if(!this.conversionRates.ContainsKey(key))
                throw new KeyNotFoundException("Cannot find the conversion rate " + key);

            return this.conversionRates[key]*fromAmount;
        }
    }
}