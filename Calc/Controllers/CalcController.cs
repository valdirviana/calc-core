using System;
using Calc.Core;
using Calc.Core.Formatter;
using Calc.Core.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Calc.Controllers
{
    [Route("calculajuros")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        private readonly ICompoundInterestCalculator _compoundInterestCalculator;
        private readonly ICompoundInterestCalculatorValidator _compoundInterestCalculatorValidator;
        private readonly ILogger _logger;

        public CalcController(ICompoundInterestCalculator compoundInterestCalculator, 
            ICompoundInterestCalculatorValidator compoundInterestCalculatorValidator,
             ILogger<CalcController> logger)
        {
            _compoundInterestCalculator = compoundInterestCalculator;
            _compoundInterestCalculatorValidator = compoundInterestCalculatorValidator;
            _logger = logger;
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


        [HttpGet]
        [Route("showmethecode")]
        public IActionResult GetShowMeTheCode() => Redirect("https://github.com/valdirviana/calc-core");
    }
}