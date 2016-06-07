using System;
using Money.WalletComposer.Operation;

namespace Money.WalletComposer
{
    internal class MultiItemWallet<T> : Wallet<T> 
        where T : struct, IComparable, IComparable<T>
    {
        public Wallet<T> Left { get; private set; }
        public Wallet<T> Right { get; private set; }
        public IBinaryOperation BinaryOperation { get; private set; }

        internal MultiItemWallet(Wallet<T> left, Wallet<T> right, IBinaryOperation binaryOperation)
        {
            this.Left = left;
            this.Right = right;
            this.BinaryOperation = binaryOperation;
        }

        protected internal override Currency Currency
        {
            get
            {
                var leftCurrency = this.Left.Currency;
                if (leftCurrency == Currency.Invalid)
                    return leftCurrency;

                var rightCurrency = this.Right.Currency;

                return leftCurrency == rightCurrency ? leftCurrency : Currency.Invalid;
            }
        }

        protected override Money<T> EvaluateInner(ICurrencyConverter<T> currencyConverter, Currency toCurrency)
        {
            var leftEquivalent = this.Left.Evaluate(currencyConverter, toCurrency);
            var rightEquivalent = this.Right.Evaluate(currencyConverter, toCurrency);
            return this.BinaryOperation.Operate(leftEquivalent, rightEquivalent);
        }
    }
}