using Microsoft.AspNetCore.Mvc;

namespace CoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        [Route("postdata/{myId}")]
        public IActionResult PostData([FromBody] object formData, [FromRoute] string myId, [FromQuery] string queryParam )
        {
            var headers = HttpContext.Request.Headers;
            // Process the custom header
            //if (string.IsNullOrEmpty(customHeader))
            //{
            //    return BadRequest("Custom-Header is required.");
            //}

            // Validate and process form data
            if (formData == null)
            {
                return BadRequest("Invalid form data.");
            }

            // Example: Access specific headers if needed
            //Request.Headers.TryGetValue("Another-Header", out StringValues anotherHeader);

            // Handle your logic here
            var response = new
            {
                Message = "Data received successfully",
                Header = headers,                
                myId = myId,
                Data = formData
            };

            return Ok(response);
        }

    }
}