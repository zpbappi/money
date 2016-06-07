namespace Money
{
    public interface ICurrencyConverter<T>
    {
        T Convert(T fromAmount, Currency fromCurrency, Currency toCurrency);
    }
}