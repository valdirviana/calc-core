using Calc.Core;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calc.Test.Unit
{
    public class CompoundInterestCalculatorTest
    {
        private readonly CompoundInterestCalculator _compoundInterestCalculator;

        public CompoundInterestCalculatorTest()
        {
            _compoundInterestCalculator = new CompoundInterestCalculator();
        }

        [Theory]
        [InlineData(100, 5, 105.10100501000001)]
        [InlineData(234, 5, 245.93635172340004)]
        [InlineData(985.96, 2, 1005.7777960000001)]
        [InlineData(15, 1, 15.15)]
        [InlineData(1, 25, 1.2824319950172338)]
        [InlineData(1256.6942, 75, 2650.529513237967)]
        [InlineData(75.123654, 360, 2700.6684165251113)]
        [InlineData(423.36, 21, 521.745451865495)]
        [InlineData(154.6, 33, 214.69148718991673)]
        public void ShouldCalculateAndReturnTruncateValue(double amount, int period, double finalAmount)
        {
            var result = _compoundInterestCalculator.Calculate(amount, period);
            result.Should().Be(finalAmount);
        }
    }
}
