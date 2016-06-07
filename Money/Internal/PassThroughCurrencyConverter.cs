namespace Money.Internal
{
    internal sealed class PassThroughCurrencyConverter<T> : ICurrencyConverter<T>
    {
        public T Convert(T fromAmount, Currency fromCurrency, Currency toCurrency)
        {
            return fromAmount;
        }
    }
}