using System.Numerics;

namespace Money.Tests.Internal.Helpers
{
    public struct CustomNumber
    {
        private readonly decimal number;

        public CustomNumber(decimal number)
        {
            this.number = number;
        }

        public static implicit operator CustomNumber(short number)
        {
            return new CustomNumber(number);
        }

        public static implicit operator CustomNumber(int number)
        {
            return new CustomNumber(number);
        }

        public static implicit operator CustomNumber(long number)
        {
            return new CustomNumber(number);
        }

        public static implicit operator CustomNumber(double number)
        {
            return new CustomNumber((decimal)number);
        }

        public static implicit operator CustomNumber(decimal number)
        {
            return new CustomNumber(number);
        }

        public static implicit operator CustomNumber(BigInteger number)
        {
            return new CustomNumber((decimal)number);
        }

        public static implicit operator short(CustomNumber number)
        {
            return (short)number.number;
        }

        public static implicit operator int(CustomNumber number)
        {
            return (int)number.number;
        }

        public static implicit operator long(CustomNumber number)
        {
            return (long)number.number;
        }

        public static implicit operator double(CustomNumber number)
        {
            return (double)number.number;
        }

        public static implicit operator decimal(CustomNumber number)
        {
            return number.number;
        }

        public static implicit operator BigInteger(CustomNumber number)
        {
            return new BigInteger(number.number);
        }
    }
}