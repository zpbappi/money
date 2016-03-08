namespace Money
{
    public sealed partial class Money<T>
    {
        public static Wallet<T> operator +(Money<T> left, Money<T> right)
        {
            return (Wallet<T>) left + right;
        }

        public static Wallet<T> operator -(Money<T> left, Money<T> right)
        {
            return (Wallet<T>)left - right;
        }

        public static Wallet<T> operator *(Money<T> left, Money<T> right)
        {
            return (Wallet<T>)left * right;
        }

        public static Wallet<T> operator /(Money<T> left, Money<T> right)
        {
            return (Wallet<T>)left / right;
        }

        public static Wallet<T> operator %(Money<T> left, Money<T> right)
        {
            return (Wallet<T>)left % right;
        }
    }
}