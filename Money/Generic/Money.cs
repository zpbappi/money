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
                new System.Globalization.RegionInfo(System.Globalization.CultureInfo.CurrentUICulture.LCID)
                    .ISOCurrencySymbol)
        {
        }

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