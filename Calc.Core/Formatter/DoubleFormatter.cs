using System.Globalization;

namespace Calc.Core.Formatter
{
    public static class DoubleFormatter
    {
        public static string FormatReturn(this double value)
        {
            var integerValue = value.ToString("F10", CultureInfo.GetCultureInfo("pt-BR")).Split(',')[0];
            var decimalValue = value.ToString("F10", CultureInfo.GetCultureInfo("pt-BR")).Split(',')[1].Substring(0, 2);
            return $"{integerValue},{decimalValue}";
        }
    }
}
