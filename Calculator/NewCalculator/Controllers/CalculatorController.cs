using Microsoft.AspNetCore.Mvc;
using NewCalculator.Core.Interfaces;
using NewCalculator.Core.Models.Calculator;

namespace NewCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ILoggerService loggerService, ICalculatorService calculatorService)
        {
            _loggerService = loggerService;
            _calculatorService = calculatorService;
        }

        [HttpPost("api/v1/divide")]
        [ProducesResponseType<CalculationResult>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DivideNumbers([FromBody] DivisionRequest request)
        {

            try
            {
                if(request.Divisor == 0)
                {
                    return BadRequest(new CalculationResult("divide", request, errorMessage: "Cannot divide by zero. "));
                }

                var quotient = _calculatorService.Divide([request.Dividend, request.Divisor]);

                return Ok(new CalculationResult("divide", request, result: quotient));
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex.Message, ex);
                return StatusCode(500, new CalculationResult("divide", request, errorMessage: "An error occurred during division."));
            }

        }

        // Version 2: Allow between 2 and 5 numbers
        [HttpPost("api/v2/add")]
        [ProducesResponseType<CalculationResult>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddMultipleNumbers([FromBody] MultiNumberAdditionRequest request)
        {
            try
            {
                if (request.Numbers == null || request.Numbers.Length < 2 || request.Numbers.Length > 5)
                {
                    return BadRequest(new CalculationResult("add", request, errorMessage: "You must provide between 2 and 5 numbers."));
                }

                var result = _calculatorService.Add(request.Numbers);
                return Ok(new CalculationResult("add", request, result: result));
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex.Message, ex);
                return StatusCode(500, new CalculationResult("add", request, errorMessage: "An error occurred during addition."));
            }
        }

        // Version 1: Add two numbers
        [HttpPost("api/v1/add")]
        [ProducesResponseType<CalculationResult>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddNumbers([FromBody] AdditionRequest request)
        {
            try
            {
                var sum = _calculatorService.Add(request.Number1, request.Number2);
                return Ok(new CalculationResult("add", request, sum));
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex.Message, ex);
                return StatusCode(500, new CalculationResult("add", request, errorMessage: "An error occurred during addition."));
            }
        }
    }
}
