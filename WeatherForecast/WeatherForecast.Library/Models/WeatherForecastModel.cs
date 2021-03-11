namespace WeatherForecast.Library.Models
{
	public class WeatherForecastModel
	{
		public DayForecastModel[] Consolidated_weather { get; set; }
		public string Title { get; set; }
	}

	public class DayForecastModel
	{
		public string Weather_state_name { get; set; }
		public string Weather_state_abbr { get; set; }
		public string Applicable_date { get; set; }
	}
}
