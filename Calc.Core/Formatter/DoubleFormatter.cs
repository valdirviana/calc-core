namespace Calc.Core.Formatter
{
    public static class DoubleFormatter
    {
        public static string FormatReturn(this double value)
        {
            var integerValue = value.ToString("F10").Split(',')[0];
            var decimalValue = value.ToString("F10").Split(',')[1].Substring(0, 2);
            return $"{integerValue},{decimalValue}";
        }
    }
}
