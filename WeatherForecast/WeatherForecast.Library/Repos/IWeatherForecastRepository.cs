using System.Threading.Tasks;
using WeatherForecast.Library.Models;

namespace WeatherForecast.Library.Repos
{
	public interface IWeatherForecastRepository
	{
		Task<WeatherForecastModel> GetForecast(string woeid);
	}
}
