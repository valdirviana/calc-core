namespace Calc.Core
{
    public interface ICompoundInterestCalculator
    {
        double Calculate(double amount, int period);
    }
}
