using System;

namespace Calc.Core
{
    public class CompoundInterestCalculator : ICompoundInterestCalculator
    {
        private const double interest = 0.01;

        public double Calculate(double amount, int period)
        {
            var finalAmount = amount * Math.Pow(1 + 0.01, period);
            var truncatedAmount = TruncateAmount(finalAmount);

            return truncatedAmount;
        }

        private double TruncateAmount(double amount)
        {
            return Math.Floor(amount * 100) / 100;
        }
    }
}
