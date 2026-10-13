using Microsoft.AspNetCore.Mvc;
using UnitConversion.Services;

namespace UnitConversion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversionController : ControllerBase
    {
        private readonly IConversionService _conversionService;

        public ConversionController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpGet("convert")]
        public IActionResult Convert(double value, string from, string to)
        {
            try
            {
                double result = _conversionService.Convert(value, from, to);

                return Ok(new
                {
                    Value = value,
                    FromUnit = from,
                    ToUnit = to,
                    Result = Math.Round(result, 4)
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
