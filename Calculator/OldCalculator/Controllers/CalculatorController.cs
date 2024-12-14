using Microsoft.AspNetCore.Mvc;
using OldCalculator.Models;
using OldCalculator.Services;

namespace OldCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        [Route("Addition")]
        [HttpPost()]
        public CalculationResult Addition([FromBody] CalculationRequest request)
        {
            var logger = new SqlLogger(); // Not good practice. See comments below.

            logger.LogToSql($"Adding {request.Number1} to {request.Number2}");

            return new CalculationResult
            {
                Result = request.Number1 + request.Number2,
            };
        }

        // Improvements:
        // 1. Remove direct instantiation of logger: 
        //    var logger = new SqlLogger();

        // 2. Use dependency injection (DI) to inject the logger into the constructor instead of manually creating it.

        // 3. If it's a absolute a must create a pattern like composite pattern in order to acomplish the user story.

        // 3. Use a generic logging interface (ILogger<T>) instead. Decouple logging from the business logic, relying on ASP.NET Core's built-in logging infrastructure.

    }
}
