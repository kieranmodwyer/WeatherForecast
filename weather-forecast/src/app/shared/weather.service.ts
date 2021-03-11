import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IWeatherForecast } from './weatherforecast.model';
import { Observable } from 'rxjs';

@Injectable()
export class WeatherService {
    private _url: string = "https://localhost:44317/api/WeatherForecast";

    constructor(private http: HttpClient) { }

    getWeatherForecast(): Observable<IWeatherForecast> {
        return this.http.get<IWeatherForecast>(this._url);
    }
}