namespace Money.WalletComposer
{
    internal class MultiItemWallet : Wallet
    {
        public Wallet Left { get; private set; }
        public Wallet Right { get; private set; }
        public IOperation Operation { get; private set; }

        internal MultiItemWallet(Wallet left, Wallet right, IOperation operation)
        {
            this.Left = left;
            this.Right = right;
            this.Operation = operation;
        }

        protected internal override string Currency
        {
            get
            {
                var leftCurrency = this.Left.Currency;
                var rightCurrency = this.Left.Currency;

                return leftCurrency == rightCurrency ? leftCurrency : null;
            }
        }
    }
}