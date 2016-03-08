using Money.WalletComposer;

namespace Money
{
    public abstract class Wallet
    {
        protected internal abstract string Currency { get; }

        public static implicit operator Wallet(Money money)
        {
            return new SingleItemWallet(money);
        }

        public static Wallet operator +(Wallet left, Wallet right)
        {
            return new MultiItemWallet(left, right, null);
        }

        public static Wallet operator -(Wallet left, Wallet right)
        {
            return new MultiItemWallet(left, right, null);
        }

        public static Wallet operator *(Wallet left, Wallet right)
        {
            return new MultiItemWallet(left, right, null);
        }

        public static Wallet operator /(Wallet left, Wallet right)
        {
            return new MultiItemWallet(left, right, null);
        }

        public static Wallet operator %(Wallet left, Wallet right)
        {
            return new MultiItemWallet(left, right, null);
        }
    }
}