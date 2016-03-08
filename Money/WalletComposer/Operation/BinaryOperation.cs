using System;
using Money.Exceptions;

namespace Money.WalletComposer.Operation
{
    internal abstract class BinaryOperation : IBinaryOperation
    {
        public abstract Money<T> Operate<T>(Money<T> left, Money<T> right) where T : struct, IComparable, IComparable<T>;

        protected Money<T> ApplyBinaryOperation<T>(Money<T> left, Money<T> right, Func<T, T, T> binaryOperation) 
            where T : struct, IComparable, IComparable<T>
        {
            if (left.Currency != right.Currency)
                throw new CurrencyMismatchException(
                    right.Currency,
                    left.Currency,
                    string.Format("Cannot perform binary operation operation between currencies '{0}' and '{1}'.",
                        left.Currency, right.Currency));

            return new Money<T>(binaryOperation(left.Amount, right.Amount), left.Currency);
        } 
    }
}