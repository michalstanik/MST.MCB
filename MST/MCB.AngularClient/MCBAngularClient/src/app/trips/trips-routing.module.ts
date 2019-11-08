import { RouterModule, Routes } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';

// Components
import { TripsRootComponent } from './trips-root/trips-root.component';
import { TripDetailsComponent } from './trip-details/trip-details.component';
import { TripAddComponent } from './trip-add/trip-add.component';


export const routing: ModuleWithProviders = RouterModule.forChild([
  {
    path: 'trips', /*canActivate: [AuthGuardService],*/ component: TripsRootComponent,

    children: [

      { path: 'trip-add', component: TripAddComponent},
      { path: ':id', component: TripDetailsComponent },
      ]
    }
]);
