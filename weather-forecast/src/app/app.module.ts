import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AuthGuard } from './guards/auth-guard.service';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { NgxPullToRefreshModule } from 'ngx-pull-to-refresh';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { LoginComponent } from './components/login/login.component';
import { WeatherForecastComponent } from './components/weatherforecast/weatherforecast.component';
import { HomeComponent } from './components/home/home.component';
import { WeatherService } from './shared/weather.service';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    WeatherForecastComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NgxPullToRefreshModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:44317"],
        disallowedRoutes: []
      }
    })
  ],
  providers: [AuthGuard, WeatherService],
  bootstrap: [AppComponent]
})
export class AppModule { }
