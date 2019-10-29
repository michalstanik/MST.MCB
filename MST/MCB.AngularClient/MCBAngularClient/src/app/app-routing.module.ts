import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ModuleWithProviders } from '@angular/core';

const appRoutes: Routes = [
  { path: '', component: HomeComponent }

];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes, { useHash: false });
