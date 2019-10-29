import { Injectable } from '@angular/core';
import {
  HttpEvent,
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/do';

import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService, private router: Router) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (req.url.startsWith(environment.apiRoot)) {
      const accessToken = this.authService.getAccessToken();
      const headers = req.headers.set('Authorization', `Bearer ${accessToken}`);
      const authReq = req.clone({ headers });
      return next.handle(authReq).do(() => {}, error => {
        const respError = error as HttpErrorResponse;
        if (respError && (respError.status === 401 || respError.status === 403)) {
          this.router.navigate(['/unauthorized']);
        }
      });
    } else {
      return next.handle(req);
    }
  }
}
