namespace Money
{
    public sealed partial class Money<T>
    {
        public static Wallet operator +(Money<T> left, Money right)
        {
            return (Wallet) left + right;
        }

        public static Wallet operator -(Money<T> left, Money right)
        {
            return (Wallet)left - right;
        }

        public static Wallet operator *(Money<T> left, Money right)
        {
            return (Wallet)left * right;
        }

        public static Wallet operator /(Money<T> left, Money right)
        {
            return (Wallet)left / right;
        }

        public static Wallet operator %(Money<T> left, Money right)
        {
            return (Wallet)left % right;
        }
    }
}