import { Component, OnInit } from '@angular/core';
import { AuthService } from './core/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  firstLogin = false;
  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit() {

  }

  login() {
    this.authService.login();
  }

  isLoggedIn() {
    return this.authService.isLoggedIn();
  }
}
