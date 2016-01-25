using System;
using System.Globalization;

namespace Money.Generic
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
    }
}