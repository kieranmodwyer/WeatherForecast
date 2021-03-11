import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subject } from 'rxjs';
import { WeatherService } from 'src/app/shared/weather.service';
import { IWeatherForecast } from 'src/app/shared/weatherforecast.model';

@Component({
  selector: 'app-weatherforecast',
  templateUrl: './weatherforecast.component.html',
  styleUrls: ['./weatherforecast.component.scss']
})
export class WeatherForecastComponent implements OnInit {

  weather: IWeatherForecast;

  targetElement: Element;
  spinnerSpeed: number = 30;

  url = "https://localhost:44317/api/WeatherForecast";

  constructor(private jwtHelper: JwtHelperService, private weatherService: WeatherService) {}

    isUserAuthenticated() {

    const token: string = localStorage.getItem("jwt");

    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else {
      return false;
    }
  }

  logOut() {
    localStorage.removeItem("jwt");
  }

  myRefreshEvent(event: Subject<any>) {
    this.weatherService.getWeatherForecast()
      .subscribe(data => {
        this.weather = data;
        event.next();
        console.log("Updated weather: ", this.weather);
      }, err => {
       console.log(err);
     });
  }

  ngOnInit() {
    this.targetElement = document.querySelector('html');

    this.weatherService.getWeatherForecast()
      .subscribe(data => {
        this.weather = data;
        console.log("Initial weather: ", this.weather);
      }, err => {
       console.log(err);
     });
  }
}
