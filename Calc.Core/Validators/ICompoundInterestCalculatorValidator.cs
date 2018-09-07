using System;
using System.Collections.Generic;

namespace Calc.Core.Validators
{
    public interface ICompoundInterestCalculatorValidator
    {
        Tuple<bool, List<string>> Validate(string amount, string period);
    }
}
