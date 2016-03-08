using System;
using System.Globalization;

namespace Money
{
    public abstract class Money
    {
        public string Currency { get; protected set; }
    }

    public sealed partial class Money<T> : Money,
        IEquatable<Money<T>>, IComparable, IComparable<Money<T>> 
        where T : struct, IComparable, IComparable<T>
    {
        public T Amount { get; private set; }

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
    }
}