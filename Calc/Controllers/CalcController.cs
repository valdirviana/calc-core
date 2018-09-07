using System;
using Calc.Core;
using Calc.Core.Formatter;
using Calc.Core.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Calc.Controllers
{
    [Route("calculajuros")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        private readonly ICompoundInterestCalculator _compoundInterestCalculator;
        private readonly ICompoundInterestCalculatorValidator _compoundInterestCalculatorValidator;

        public CalcController(ICompoundInterestCalculator compoundInterestCalculator, ICompoundInterestCalculatorValidator compoundInterestCalculatorValidator)
        {
            _compoundInterestCalculator = compoundInterestCalculator;
            _compoundInterestCalculatorValidator = compoundInterestCalculatorValidator;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]string valorinicial, [FromQuery]string meses)
        {
            var validatedFields = _compoundInterestCalculatorValidator.Validate(valorinicial, meses);

            if (validatedFields.Item1)
            {
                var retorno = _compoundInterestCalculator.Calculate(Convert.ToDouble(valorinicial), Convert.ToInt32(meses));
                return Ok(retorno.FormatReturn());
            }
            else
                return BadRequest(validatedFields.Item2);           
        }

    }
}