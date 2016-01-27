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

        static public implicit operator CustomNumber(short number)
        {
            return new CustomNumber(number);
        }

        static public implicit operator CustomNumber(int number)
        {
            return new CustomNumber(number);
        }

        static public implicit operator CustomNumber(long number)
        {
            return new CustomNumber(number);
        }

        static public implicit operator CustomNumber(double number)
        {
            return new CustomNumber((decimal)number);
        }

        static public implicit operator CustomNumber(decimal number)
        {
            return new CustomNumber(number);
        }

        static public implicit operator CustomNumber(BigInteger number)
        {
            return new CustomNumber((decimal)number);
        }

        static public implicit operator short(CustomNumber number)
        {
            return (short)number.number;
        }

        static public implicit operator int(CustomNumber number)
        {
            return (int)number.number;
        }

        static public implicit operator long(CustomNumber number)
        {
            return (long)number.number;
        }

        static public implicit operator double(CustomNumber number)
        {
            return (double)number.number;
        }

        static public implicit operator decimal(CustomNumber number)
        {
            return number.number;
        }

        static public implicit operator BigInteger(CustomNumber number)
        {
            return new BigInteger(number.number);
        }
    }
}