import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/Observable';

// Models
import { ContinentWithRegionsAndCountriesModel } from '../model/Geo/continent-with-regions-and-countries.model';
import { CountryWithAssessment } from '../model/Geo/country-with-assessment.model';

@Injectable()
export class CountryService {

  constructor(private http: HttpClient) {}

  GetCountriesForUserByContinent(): Observable<ContinentWithRegionsAndCountriesModel[]> {
    return this.http.get<ContinentWithRegionsAndCountriesModel[]>(environment.apiRoot + 'geo',
    { headers: { Accept: 'application/vnd.mcb.cintinentWithRegionsAndCountries+json' } });
  }

  GetCountriesForUserWithAssessments(): Observable<CountryWithAssessment[]> {
    return this.http.get<CountryWithAssessment[]>(environment.apiRoot + 'geo',
    { headers: { Accept: 'application/vnd.mcb.countriesforUserWithAssessments+json' } });
  }
}
