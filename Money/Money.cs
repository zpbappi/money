using System;

namespace Money
{
    public class Money<T>
    {
        public T Amount { get; private set; }
        public string Currency { get; private set; }

        protected Money(T amount, string currency)
        {
            if (IsNullable<T>() && amount == null)
                throw new ArgumentNullException("amount");

            if(string.IsNullOrWhiteSpace(currency))
                throw new ArgumentNullException("currency");

            this.Amount = amount;
            this.Currency = currency.ToUpperInvariant();
        }

        public static Money<T> Create(T amount, string currency)
        {
            return new Money<T>(amount, currency);
        }

        public static Money<T> CreateWithCurrentCulterCurrency(T amount)
        {
            var currencyFromCurrentCulter =
                new System.Globalization.RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID)
                    .ISOCurrencySymbol;
            return Create(amount, currencyFromCurrentCulter);
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

    public abstract class Money : Money<decimal>
    {
        protected Money(decimal amount, string currency) : base(amount, currency)
        {
        }
    }
}