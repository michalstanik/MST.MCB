import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Stats } from '../model/Stats/stats-model';

@Injectable()
export class StatsService {

  constructor(private http: HttpClient) {}

  GetStatsForUser(): Observable<Stats> {
    return this.http.get<Stats>(environment.apiRoot + 'stats/',
    { headers: { Accept: 'application/vnd.mcb.basestats+json' } });
  }
}
