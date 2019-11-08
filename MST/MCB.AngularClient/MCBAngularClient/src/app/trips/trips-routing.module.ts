import { RouterModule, Routes } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';

// Components
import { TripsRootComponent } from './trips-root/trips-root.component';
import { TripDetailsComponent } from './trip-details/trip-details.component';


export const routing: ModuleWithProviders = RouterModule.forChild([
  {
    path: 'trips', /*canActivate: [AuthGuardService],*/ component: TripsRootComponent,

    children: [
      { path: ':id', component: TripDetailsComponent }
      ]
    }
]);
