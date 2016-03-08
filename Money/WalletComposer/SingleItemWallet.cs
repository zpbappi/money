using System;

namespace Money.WalletComposer
{
    internal class SingleItemWallet<T> : Wallet<T> 
        where T : struct, IComparable, IComparable<T>
    {
        public Money<T> Money { get; private set; }

        internal SingleItemWallet(Money<T> money)
        {
            this.Money = money;
        }

        protected internal override string Currency
        {
            get
            {
                return this.Money.Currency;
            }
        }

        protected override Money<T> EvaluateInner(ICurrencyConverter<T> currencyConverter, string toCurrency)
        {
            var convertedAmount = currencyConverter.Convert(this.Money.Amount, this.Money.Currency, toCurrency);
            return new Money<T>(convertedAmount, toCurrency);
        }
    }
}