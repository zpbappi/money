using Shouldly;
using Xunit;

namespace Money.Tests
{
    public class MoneyEqualityTest
    {
        [Theory]
        [InlineData(42, 42, "AUD", true)]
        public void MoneyWithSameCurrency_ShouldSupportEqualityComparison(
            decimal amount1,
            decimal amount2,
            string currency,
            bool expectedEqualityTestResult)
        {
            var money1 = new Money(amount1, currency);
            var money2 = new Money(amount2, currency);
            
            var actualEqualityTestResult = money1 == money2;

            actualEqualityTestResult.ShouldBe(expectedEqualityTestResult);
        }
    }
}