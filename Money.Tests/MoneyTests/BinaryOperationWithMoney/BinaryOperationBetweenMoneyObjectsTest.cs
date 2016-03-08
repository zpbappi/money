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
            var money2 = new Money<decimal>(1000);
            var actual = money1 + money2;
            actual.ShouldBeAssignableTo<Wallet>();
        }

        [Fact]
        public void SubtractionOfMoneyObejcts_ShouldReturnWallet()
        {
            var money1 = new Money<int>(42);
            var money2 = new Money<decimal>(1000);
            var actual = money1 - money2;
            actual.ShouldBeAssignableTo<Wallet>();
        }

        [Fact]
        public void MultiplicationOfMoneyObejcts_ShouldReturnWallet()
        {
            var money1 = new Money<int>(42);
            var money2 = new Money<decimal>(1000);
            var actual = money1 * money2;
            actual.ShouldBeAssignableTo<Wallet>();
        }

        [Fact]
        public void DivisionOfMoneyObejcts_ShouldReturnWallet()
        {
            var money1 = new Money<int>(42);
            var money2 = new Money<decimal>(1000);
            var actual = money1 / money2;
            actual.ShouldBeAssignableTo<Wallet>();
        }

        [Fact]
        public void ModuloOfMoneyObejcts_ShouldReturnWallet()
        {
            var money1 = new Money<int>(42);
            var money2 = new Money<decimal>(1000);
            var actual = money1 % money2;
            actual.ShouldBeAssignableTo<Wallet>();
        }
    }
}