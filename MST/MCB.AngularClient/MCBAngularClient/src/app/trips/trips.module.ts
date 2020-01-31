import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

// Components
import { TripsRootComponent } from './trips-root/trips-root.component';
import { TripsListComponent } from './trips-list/trips-list.component';
import { TripDetailsComponent } from './trip-details/trip-details.component';
import { CountriesListComponent } from './countries-list/countries-list.component';
import { TripThumbnailComponent } from './trip-thumbnail/trip-thumbnail.component';
import { StopsListComponent } from './stops-list/stops-list.component';
import { TripAddComponent } from './trip-add/trip-add.component';

// Modules
import { CoreModule } from '../core/core.module';
import { routing } from './trips-routing.module';
import { MDBBootstrapModulesPro } from 'ng-uikit-pro-standard';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    TripsRootComponent,
    TripsListComponent,
    TripThumbnailComponent,
    TripDetailsComponent,
    CountriesListComponent,
    StopsListComponent,
    TripAddComponent],
  imports: [
    MDBBootstrapModulesPro.forRoot(),
    CommonModule,
    CoreModule,
    routing,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class TripsModule {

  constructor() {
     automapper.createMap('TripFormModel', 'TripForCreation');
  }
}
