using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Calc.Core;
using Calc.Core.Validators;
using Microsoft.AspNetCore.Http;
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
        [Produces("text/plain")]
        public IActionResult Get([FromQuery]string valorinicial, [FromQuery]string meses)
        {
            var validatedFields = _compoundInterestCalculatorValidator.Validate(valorinicial, meses);

            if (validatedFields.Item1)           
                return Ok(_compoundInterestCalculator.Calculate(Convert.ToDouble(valorinicial), Convert.ToInt32(meses)));         
            else         
                return BadRequest(validatedFields.Item2);           
        }
    }
}