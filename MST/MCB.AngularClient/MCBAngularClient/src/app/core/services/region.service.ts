import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/Observable';

// Models
import { RegionWithCountriesAndAssessment } from '../model/Geo/region-with-countries-and-assessment.model';


@Injectable()
export class RegionService {

  constructor(private http: HttpClient) {}

  GetRegionWithUserVisits(id: number): Observable<RegionWithCountriesAndAssessment> {
    return this.http.get<RegionWithCountriesAndAssessment>(environment.apiRoot + 'regions/' + id,
    { headers: { Accept: 'application/vnd.mcb.regionwithuservisits+json' } });
  }
}
