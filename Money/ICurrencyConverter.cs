namespace Money
{
    public interface ICurrencyConverter<T>
    {
        T Convert(T fromAmount, string fromCurrency, string toCurrency);
    }
}