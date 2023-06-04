using Microsoft.AspNetCore.Mvc;
using TemplateWebAPI.Models;

namespace TemplateWebAPI.Controllers
{
    [ApiController]
    //[Route("api/weather/forecast")]
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

        [HttpGet("{days}", Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get(Days days)
        {
            return Enumerable.Range(days.From, days.To).Select(index => new WeatherForecast {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
        }

        /*public IActionResult Get()
        {
            var store = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
            return Ok(store.First());
        }*/
    }
}