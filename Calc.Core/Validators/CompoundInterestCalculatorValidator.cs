using System;
using System.Collections.Generic;

namespace Calc.Core.Validators
{
    public class CompoundInterestCalculatorValidator : ICompoundInterestCalculatorValidator
    {
        public Tuple<bool, List<string>> Validate(string amount, string period)
        {
            bool isValid = true;
            var validateMessages = new List<string>();

            CheckAmount(amount, ref isValid, ref validateMessages);

            CheckPeriod(period, ref isValid, ref validateMessages);

            return new Tuple<bool, List<string>>(isValid, validateMessages);
        }

        private static void CheckAmount(string amount, ref bool isValid, ref List<string> validateMessages)
        {
            if (string.IsNullOrEmpty(amount))
            {
                isValid = false;
                validateMessages.Add("Amount is invalid");
                return;
            }

            if (!double.TryParse(amount, out double convert))
            {
                isValid = false;
                validateMessages.Add("Amount is not a valid float number");
            }

            if (amount.Contains(" "))
            {
                isValid = false;
                validateMessages.Add("Amount contains a blank space");
            }

            if (amount.Contains("."))
            {
                isValid = false;
                validateMessages.Add("Amount contains a dot, replace to comma");
            }
        }

        private static void CheckPeriod(string period,ref bool isValid,ref List<string> validateMessages)
        {
            if(string.IsNullOrEmpty(period))
            {
                isValid = false;
                validateMessages.Add("Period is null or empty");
                return;
            }

            if(!int.TryParse(period,out int convert))
            {
                isValid = false;
                validateMessages.Add("Period is not a valid number");
            }

            if (period.Contains(" "))
            {
                isValid = false;
                validateMessages.Add("Period contains a blank space");
            }

        }
    }
}
