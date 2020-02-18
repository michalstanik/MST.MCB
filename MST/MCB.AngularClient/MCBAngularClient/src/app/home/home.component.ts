import { Component, OnInit } from '@angular/core';

import { AuthService } from '../core/services/auth.service';
import { StatsService } from '../core/services/stats.service';

// Models
import { Stats } from '../core/model/Stats/stats-model';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  stats: Stats;

  constructor(
    private authService: AuthService,
    private statsService: StatsService
  ) {}

  ngOnInit() {
    if (this.isLoggedIn()) {
      this.statsService.GetStatsForUser().subscribe(stats => {
        this.stats = stats;
       });
    }
  }

  login() {
    this.authService.login();
  }

  isLoggedIn() {
    return this.authService.isLoggedIn();
  }
}
