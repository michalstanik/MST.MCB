import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserManager, User, WebStorageStateStore } from 'oidc-client';
import { environment } from 'src/environments/environment';



@Injectable()
export class AuthService {
    private userManager: UserManager;
    private user: User;

    constructor(private httpClient: HttpClient) {
        const config = {
            authority: environment.stsAuthority,
            client_id: environment.clientId,
            redirect_uri: `${environment.clientRoot}assets/oidc-login-redirect.html`,
            scope: 'openid tripwithmeapi profile role',
            response_type: 'id_token token',
            post_logout_redirect_uri: `${environment.clientRoot}?postLogout=true`,
            userStore: new WebStorageStateStore({ store: window.localStorage })
        };
        this.userManager = new UserManager(config);
        this.userManager.getUser().then(user => {
            if (user && !user.expired) {
                this.user = user;
            }
        });
    }

    login(): Promise<any> {
        return this.userManager.signinRedirect();
    }

    logout(): Promise<any> {
        return this.userManager.signoutRedirect();
    }

    isLoggedIn(): boolean {
        return this.user && this.user.access_token && !this.user.expired;
    }

    getAccessToken(): string {
        return this.user ? this.user.access_token : '';
    }

    signoutRedirectCallback(): Promise<any> {
        return this.userManager.signoutRedirectCallback();
    }
}
