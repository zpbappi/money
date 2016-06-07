using System;
using System.Globalization;

namespace Money
{
    public partial class Money<T> :
        IEquatable<Money<T>>, IComparable, IComparable<Money<T>> 
        where T : struct, IComparable, IComparable<T>
    {
        public T Amount { get; private set; }

        public Currency Currency { get; private set; }

        public Money(T amount, Currency currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        } 

        [Obsolete("Use Money<T>(T, Currency) instead of string currency code.")]
        public Money(T amount, string currency)
        {
            if(string.IsNullOrWhiteSpace(currency))
                throw new ArgumentNullException("currency");

            this.Amount = amount;
            this.Currency = (Currency)Enum.Parse(typeof(Currency), currency.ToUpperInvariant());
        }

        public Money(T amount)
            : this(
                amount,
                (Currency)
                    Enum.Parse(typeof (Currency), new RegionInfo(CultureInfo.CurrentUICulture.LCID).ISOCurrencySymbol))
        {
        }
    }
}