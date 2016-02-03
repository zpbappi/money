using System;
using System.Globalization;
using Money.Exceptions;
using Money.Internal.Helpers;

namespace Money
{
    public partial class Money<T> : 
        IEquatable<Money<T>>, IComparable, IComparable<Money<T>> 
        where T : struct, IComparable, IComparable<T>
    {
        public T Amount { get; private set; }
        public string Currency { get; private set; }

        public Money(T amount, string currency)
        {
            if(string.IsNullOrWhiteSpace(currency))
                throw new ArgumentNullException("currency");

            this.Amount = amount;
            this.Currency = currency.ToUpperInvariant();
        }

        public Money(T amount)
            : this(
                amount,
                new RegionInfo(CultureInfo.CurrentUICulture.LCID).ISOCurrencySymbol)
        {
        }

        public static Money<T> operator +(Money<T> money, object operand)
        {
            if (operand == null)
                return money;

            if (!NumericTypeHelper.CanCastTo<T>(operand))
                throw new IncompatibleAmountTypeException(
                    typeof (T), 
                    operand.GetType(),
                    "Cannot convert operand type to Money amount type.");
            
            var operandValue = NumericTypeHelper.ConvertTo<T>(operand);
            var newAmount = BinaryOperationHelper.AddChecked(money.Amount, operandValue);
            return new Money<T>(newAmount, money.Currency);
        }

        //public static Money<T> operator +(object operand, Money<T> money)
        //{
        //    return money + operand;
        //}
    }
}