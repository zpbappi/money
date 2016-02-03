using Money.Exceptions;
using Money.Internal.Helpers;

namespace Money
{
    public partial class Money<T>
    {
        public static Money<T> operator +(Money<T> money, object operand)
        {
            if (operand == null)
                return money;

            if (!NumericTypeHelper.CanCastTo<T>(operand))
                throw new IncompatibleAmountTypeException(
                    typeof(T),
                    operand.GetType(),
                    "Cannot convert operand type to Money amount type.");

            var operandValue = NumericTypeHelper.ConvertTo<T>(operand);
            var newAmount = BinaryOperationHelper.AddChecked(money.Amount, operandValue);
            return new Money<T>(newAmount, money.Currency);
        }

        public static Money<T> operator +(object operand, Money<T> money)
        {
            return money + operand;
        }
    }
}