using System;
using System.Collections.Generic;
using Money.Internal.Helpers;

namespace Money
{
    public class CachedCurrencyConverter<T> : ICurrencyConverter<T> where T : struct 
    {
        public ICurrencyConverter<T> CurrencyConverter { get; private set; }
        private readonly Dictionary<string, T> rateCache;
        private readonly Lazy<T> one; 

        public CachedCurrencyConverter(ICurrencyConverter<T> currencyConverter)
        {
            if(currencyConverter == null)
                throw new ArgumentNullException("currencyConverter");

            this.CurrencyConverter = currencyConverter;
            this.rateCache = new Dictionary<string, T>();
            this.one = new Lazy<T>(() => NumericTypeHelper.ConvertTo<T>(1));
        }

        public T Convert(T fromAmount, string fromCurrency, string toCurrency)
        {
            if (string.IsNullOrWhiteSpace(fromCurrency))
                throw new ArgumentNullException("fromCurrency");

            if(string.IsNullOrWhiteSpace(toCurrency))
                throw new ArgumentNullException("toCurrency");

            var key = GenerateKey(fromCurrency, toCurrency);

            if (!this.rateCache.ContainsKey(key))
                this.PopulateRate(fromCurrency, toCurrency);

            return BinaryOperationHelper.MultiplyChecked(fromAmount, this.rateCache[key]);
        }

        private void PopulateRate(string fromCurrency, string toCurrency)
        {
            var rate = this.CurrencyConverter.Convert(this.one.Value, fromCurrency, toCurrency);
            var key = GenerateKey(fromCurrency, toCurrency);
            this.rateCache[key] = rate;
        }

        private static string GenerateKey(string fromCurrency, string toCurrency)
        {
            return string.Format("{0}-{1}", fromCurrency.ToUpperInvariant(), toCurrency.ToUpperInvariant());
        }
    }
}