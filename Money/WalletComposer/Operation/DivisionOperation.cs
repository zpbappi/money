using Money.Internal.Helpers;

namespace Money.WalletComposer.Operation
{
    internal class DivisionOperation : BinaryOperation
    {
        public override Money<T> Operate<T>(Money<T> left, Money<T> right)
        {
            return base.ApplyBinaryOperation(left, right, BinaryOperationHelper.Divide);
        }
    }
}