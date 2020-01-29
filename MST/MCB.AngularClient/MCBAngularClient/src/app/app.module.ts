import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MDBSpinningPreloader, MDBBootstrapModulesPro, ToastModule } from 'ng-uikit-pro-standard';

// Maps Module
import { MangolModule } from 'mangol';

// Components
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './header/header.component';

// Modules
import { CoreModule } from './core/core.module';
import { TripsModuleModule } from './trips/trips-module.module';
import { CountriesModule } from './countries/countries.module';

import { routing } from './app-routing.module';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastModule.forRoot(),
    MDBBootstrapModulesPro.forRoot(),
    MangolModule,
    CoreModule,
    routing,
    TripsModuleModule,
    CountriesModule
  ],
  providers: [MDBSpinningPreloader],
  bootstrap: [AppComponent],
  exports: [ReactiveFormsModule]
})
export class AppModule { }
