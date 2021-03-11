using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WeatherForecast.Library.Models;

namespace WeatherForecast.Library.Repos
{
	public class WeatherForecastRepository : IWeatherForecastRepository
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IConfiguration _config;

		public WeatherForecastRepository(IHttpClientFactory httpClientFactory, IConfiguration config)
		{
			_httpClientFactory = httpClientFactory;
			_config = config;
		}

		/// <summary>
		/// Gets the weather forecast with provided location id
		/// </summary>
		/// <param name="woeid"></param>
		/// <returns>WeatherForecastModel</returns>
		public async Task<WeatherForecastModel> GetForecast(string woeid)
		{
			var client = _httpClientFactory.CreateClient();

			var apiUrl = _config.GetSection("AppSettings:WeatherApiUrl").Value;

			string locationForefast = apiUrl + woeid;

			WeatherForecastModel forecast;

			forecast = await client.GetFromJsonAsync<WeatherForecastModel>(locationForefast);

			return forecast;
		}
	}
}
