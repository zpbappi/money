using Money.Internal.Helpers;

namespace Money.WalletComposer.Operation
{
    internal class SubtractionOperation : BinaryOperation
    {
        public override Money<T> Operate<T>(Money<T> left, Money<T> right)
        {
            return base.ApplyBinaryOperation(left, right, BinaryOperationHelper.SubtractChecked);
        }
    }
}