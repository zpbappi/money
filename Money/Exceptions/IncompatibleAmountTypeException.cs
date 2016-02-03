using System;

namespace Money.Exceptions
{
    public class IncompatibleAmountTypeException : InvalidOperationException
    {
        public Type MoneyAmountType { get; private set; }
        public Type OperandType { get; private set; }

        public IncompatibleAmountTypeException(
            Type moneyAmountType, 
            Type operandType,
            string message)
            : base(message)
        {
            this.MoneyAmountType = moneyAmountType;
            this.OperandType = operandType;
        }
    }
}