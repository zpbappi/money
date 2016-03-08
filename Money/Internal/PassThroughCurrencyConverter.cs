namespace Money.Internal
{
    internal sealed class PassThroughCurrencyConverter<T> : ICurrencyConverter<T>
    {
        public T Convert(T fromAmount, string fromCurrency, string toCurrency)
        {
            return fromAmount;
        }
    }
}