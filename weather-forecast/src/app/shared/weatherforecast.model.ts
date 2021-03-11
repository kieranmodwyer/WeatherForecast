export interface IWeatherForecast {
    consolidated_weather: DayForecastModel[];
    title: string;
}

interface DayForecastModel {
    weather_state_name: string;
    weather_state_abbr: string;
    applicable_date: string;
}