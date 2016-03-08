using System;

namespace Money.WalletComposer
{
    internal class SingleItemWallet : Wallet
    {
        public Money Money { get; private set; }

        internal SingleItemWallet(Money money)
        {
            this.Money = money;
        }

        protected internal override string Currency { get { return this.Money.Currency; } }
    }
}