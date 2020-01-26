import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';

import { RootComponent } from './root/root.component';
import { RegionDetailsComponent } from './region-details/region-details.component';
import { RegionMapComponent } from './region-map/region-map.component';

export const routing: ModuleWithProviders = RouterModule.forChild([
  {
    path: 'mycountries', /*canActivate: [AuthGuardService],*/ component: RootComponent,

        children: [
          { path: 'regions/:id', component: RegionDetailsComponent }
        ]
    }
]);

