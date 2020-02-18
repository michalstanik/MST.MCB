import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/Observable';

// Models
import { CountryWithAssessment } from '../model/Geo/country-with-assessment.model';

@Injectable()
export class CountryDictionaryService {

  constructor(private http: HttpClient) {}

  GetAllCountriesWithUserAssessment(): Observable<CountryWithAssessment[]> {
    return this.http.get<CountryWithAssessment[]>(environment.apiRoot + 'country/dictionary',
    { headers: { Accept: 'application/vnd.mcb.allCountriesWithUserAssessment+json' } });
  }
}
