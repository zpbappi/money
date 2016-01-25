using Money.Generic;

namespace Money
{
    public class Money : Money<decimal>
    {
        public Money(decimal amount, string currency)
            : base(amount, currency)
        {
        }

        public Money(decimal amount) 
            : base(amount)
        {
        }
    }
}