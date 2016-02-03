using System;

namespace Money.Exceptions
{
    public class IncompatibleMoneyTypeException : InvalidOperationException
    {
        public Type SourceType { get; private set; }
        public Type DestinationType { get; private set; }

        public IncompatibleMoneyTypeException(
            Type sourceType,
            Type destinationType,
            string message)
            : base(message)
        {
            this.SourceType = sourceType;
            this.DestinationType = destinationType;
        }
    }
}