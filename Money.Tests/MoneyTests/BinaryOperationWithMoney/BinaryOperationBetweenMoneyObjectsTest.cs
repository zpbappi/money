using Xunit;
using Shouldly;

namespace Money.Tests.MoneyTests.BinaryOperationWithMoney
{
    public class BinaryOperationBetweenMoneyObjectsTest
    {
        [Fact]
        public void AdditionOfMoneyObejcts_ShouldReturnWallet()
        {
            var money1 = new Money<int>(42);
            var money2 = new Money<int>(1000);
            var actual = money1 + money2;
            actual.ShouldBeAssignableTo<Wallet<int>>();
        }

        [Fact]
        public void SubtractionOfMoneyObejcts_ShouldReturnWallet()
        {
            var money1 = new Money<int>(42);
            var money2 = new Money<int>(1000);
            var actual = money1 - money2;
            actual.ShouldBeAssignableTo<Wallet<int>>();
        }

        [Fact]
        public void MultiplicationOfMoneyObejcts_ShouldReturnWallet()
        {
            var money1 = new Money<decimal>(42);
            var money2 = new Money<decimal>(1000);
            var actual = money1 * money2;
            actual.ShouldBeAssignableTo<Wallet<decimal>>();
        }

        [Fact]
        public void DivisionOfMoneyObejcts_ShouldReturnWallet()
        {
            var money1 = new Money<long>(42);
            var money2 = new Money<long>(1000);
            var actual = money1 / money2;
            actual.ShouldBeAssignableTo<Wallet<long>>();
        }

        [Fact]
        public void ModuloOfMoneyObejcts_ShouldReturnWallet()
        {
            var money1 = new Money<int>(42);
            var money2 = new Money<int>(1000);
            var actual = money1 % money2;
            actual.ShouldBeAssignableTo<Wallet<int>>();
        }

        [Fact]
        public void AnyCombinationOfBinaryOperationsForMixOfCurrencies_ShouldReturnWallet()
        {
            var m1 = new Money<decimal>(42m, "USD");
            var m2 = new Money<decimal>(3.14159265m, "GBP");
            var m3 = new Money<decimal>(1000000m, "AUD");
            var m4 = new Money<decimal>(1234m, "EUR");

            var actual = m1 + (m2*m3)/m4 - (m3%m4);
            actual.ShouldBeAssignableTo<Wallet<decimal>>();
        }
    }
}