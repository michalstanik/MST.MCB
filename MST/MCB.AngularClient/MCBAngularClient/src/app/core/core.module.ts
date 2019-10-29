import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

// Interceptors
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { EnsureAcceptHeaderInterceptor } from './interceptors/ensure-accept-header-interceptor';

// Services
import { TripService } from './services/trips.service';
import { AuthService } from './services/auth.service';


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
        TripService
    ],
})
export class CoreModule { }
