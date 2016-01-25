using System;

namespace Money.Generic
{
    public class Money<T>
    {
        public T Amount { get; private set; }
        public string Currency { get; private set; }

        public Money(T amount, string currency)
        {
            if (IsNullable<T>() && amount == null)
                throw new ArgumentNullException("amount");

            if(string.IsNullOrWhiteSpace(currency))
                throw new ArgumentNullException("currency");

            this.Amount = amount;
            this.Currency = currency.ToUpperInvariant();
        }

        public Money(T amount)
            : this(
                amount,
                new System.Globalization.RegionInfo(System.Globalization.CultureInfo.CurrentUICulture.LCID).ISOCurrencySymbol)
        {
        }

        #region Equality comparison

        public static bool operator ==(Money<T> money1, Money<T> money2)
        {
            if (((object)money1 == null) || ((object)money2 == null))
                return false;

            if (money1.Currency != money2.Currency)
                return false;

            return money1.Amount.Equals(money2.Amount);
        }

        public static bool operator !=(Money<T> money1, Money<T> money2)
        {
            return !(money1 == money2);
        }

        #endregion

        private static bool IsNullable<TAmount>()
        {
            var type = typeof(TAmount);
            
            if (!type.IsValueType) 
                return true; // reference type, definately nullable
            
            if (Nullable.GetUnderlyingType(type) != null) 
                return true; // Nullable<T>
            
            return false; // value-type
        }
    }
}