using System;
using Money.Internal;
using Money.WalletComposer;
using Money.WalletComposer.Operation;

namespace Money
{
    public abstract class Wallet<T> 
        where T : struct, IComparable, IComparable<T>
    {
        protected internal abstract Currency Currency { get; }

        protected abstract Money<T> EvaluateInner(ICurrencyConverter<T> currencyConverter, Currency toCurrency);

        public Money<T> Evaluate(ICurrencyConverter<T> currencyConverter, Currency toCurrency)
        {
            if(currencyConverter == null)
                throw new ArgumentNullException("currencyConverter");

            return this.EvaluateInner(currencyConverter, toCurrency);
        }

        [Obsolete("Use Evaluate(ICurrencyConverter<T>, Currency) instead of this.")]
        public Money<T> Evaluate(ICurrencyConverter<T> currencyConverter, string toCurrency)
        {
            if (string.IsNullOrWhiteSpace(toCurrency))
                throw new ArgumentNullException("toCurrency");

            return this.Evaluate(currencyConverter, (Currency) Enum.Parse(typeof (Currency), toCurrency.ToUpperInvariant()));
        } 

        public Money<T> EvaluateWithoutConversion()
        {
            var commonCurrency = this.Currency;
            if (commonCurrency == Currency.Invalid)
                throw new InvalidOperationException(
                    "Cannot evaluate the amount without any currency converter, as there are items with different currencies.");

            return this.Evaluate(new PassThroughCurrencyConverter<T>(), commonCurrency);
        } 

        public static implicit operator Wallet<T>(Money<T> money)
        {
            return new SingleItemWallet<T>(money);
        }

        public static Wallet<T> operator +(Wallet<T> left, Wallet<T> right)
        {
            return new MultiItemWallet<T>(left, right, new AdditionOperation());
        }

        public static Wallet<T> operator -(Wallet<T> left, Wallet<T> right)
        {
            return new MultiItemWallet<T>(left, right, new SubtractionOperation());
        }

        public static Wallet<T> operator *(Wallet<T> left, Wallet<T> right)
        {
            return new MultiItemWallet<T>(left, right, new MultiplicationOperation());
        }

        public static Wallet<T> operator /(Wallet<T> left, Wallet<T> right)
        {
            return new MultiItemWallet<T>(left, right, new DivisionOperation());
        }

        public static Wallet<T> operator %(Wallet<T> left, Wallet<T> right)
        {
            return new MultiItemWallet<T>(left, right, new ModuloOperation());
        }
    }
}