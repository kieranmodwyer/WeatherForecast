using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WeatherForecast.Library.Repos;

namespace WeatherForecast.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class WeatherForecastController : ControllerBase
	{
		private readonly ILogger<WeatherForecastController> _logger;
		private readonly IWeatherForecastRepository _weatherForecastRepo;
		private readonly IConfiguration _config;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastRepository weatherForecastRepo, IConfiguration config)
		{
			_logger = logger;
			_weatherForecastRepo = weatherForecastRepo;
			_config = config;
		}

		/// <summary>
		/// HttpGet to retrieve weather forecast - calls GetForecast method from Weather Forecast Repo
		/// </summary>
		/// <returns>IActionResult</returns>
		[HttpGet]
		public async Task<IActionResult> GetWeatherForecast()
		{
			try
			{
				var result = await _weatherForecastRepo.GetForecast(_config.GetSection("AppSettings:BelfastWoeId").Value);

				_logger.LogInformation($"Weather information retrieved: {result}");

				return Ok(result);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);

				return BadRequest();
			}
		}
	}
}
