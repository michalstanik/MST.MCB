import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

// Interceptors
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { EnsureAcceptHeaderInterceptor } from './interceptors/ensure-accept-header-interceptor';

// Services
import { TripService } from './services/trips.service';
import { AuthService } from './services/auth.service';
import { CountryService } from './services/country.service';
import { CountryDictionaryService } from './services/country-dictionary.service';
import { ContinentService } from './services/continent.service';
import { RegionService } from './services/region.service';
import { ToastrService } from './services/toastr.service';
import { StatsService } from './services/stats.service';

@NgModule({
    imports: [],
    exports: [],
    declarations: [],
    providers: [
      {
        provide: HTTP_INTERCEPTORS,
        useClass: AuthInterceptor,
        multi: true },
      {
        provide: HTTP_INTERCEPTORS,
        useClass: EnsureAcceptHeaderInterceptor,
        multi: true
      },
        AuthService,
        TripService,
        CountryService,
        CountryDictionaryService,
        ContinentService,
        RegionService,
        ToastrService,
        StatsService
    ],
})
export class CoreModule { }
