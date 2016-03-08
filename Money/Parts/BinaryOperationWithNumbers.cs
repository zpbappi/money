using System;
using Money.Exceptions;
using Money.Internal.Helpers;

namespace Money
{
    public partial class Money<T>
    {
        public static Money<T> operator +(Money<T> money, ValueType operand)
        {
            if (operand == null)
                return money;

            var operandValue = ParseNumericOperandValue(operand);
            return PerformBinaryOperation(money, operandValue, BinaryOperationHelper.AddChecked);
        }

        public static Money<T> operator +(ValueType operand, Money<T> money)
        {
            return money + operand;
        }

        public static Money<T> operator -(Money<T> money, ValueType operand)
        {
            if (operand == null)
                return money;

            var operandValue = ParseNumericOperandValue(operand);
            return PerformBinaryOperation(money, operandValue, BinaryOperationHelper.SubtractChecked);
        }

        public static Money<T> operator -(ValueType operand, Money<T> money)
        {
            return money - operand;
        }

        public static Money<T> operator *(Money<T> money, ValueType operand)
        {
            if (operand == null)
                return money;

            var operandValue = ParseNumericOperandValue(operand);
            return PerformBinaryOperation(money, operandValue, BinaryOperationHelper.MultiplyChecked);
        }

        public static Money<T> operator *(ValueType operand, Money<T> money)
        {
            return money * operand;
        }

        public static Money<T> operator /(Money<T> money, ValueType operand)
        {
            if (operand == null)
                return money;

            var operandValue = ParseNumericOperandValue(operand);
            return PerformBinaryOperation(money, operandValue, BinaryOperationHelper.Divide);
        }

        public static Money<T> operator %(Money<T> money, ValueType operand)
        {
            if (operand == null)
                return money;

            var operandValue = ParseNumericOperandValue(operand);
            return PerformBinaryOperation(money, operandValue, BinaryOperationHelper.Modulo);
        }

        public static Money<T> operator <<(Money<T> money, int operand)
        {
            var newAmount = BinaryOperationHelper.LeftShift(money.Amount, operand);
            return new Money<T>(newAmount, money.Currency);
        }

        public static Money<T> operator >>(Money<T> money, int operand)
        {
            var newAmount = BinaryOperationHelper.RightShift(money.Amount, operand);
            return new Money<T>(newAmount, money.Currency);
        }

        private static T ParseNumericOperandValue(ValueType operand)
        {
            if (!NumericTypeHelper.CanCastTo<T>(operand))
                throw new IncompatibleAmountTypeException(
                    typeof (T),
                    operand.GetType(),
                    "Cannot convert operand type to Money amount type.");

            var operandValue = NumericTypeHelper.ConvertTo<T>(operand);
            return operandValue;
        }

        private static Money<T> PerformBinaryOperation(
            Money<T> money, 
            T operandValue, 
            Func<T, T, T> binaryOperation)
        {
            var newAmount = binaryOperation(money.Amount, operandValue);
            return new Money<T>(newAmount, money.Currency);
        }
    }
}