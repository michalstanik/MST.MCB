import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/Observable';
import { TripWithCountriesAndStatistics } from '../model/Trip/trip-with-countries-and-statistics.model';
import { TripFull } from '../model/Trip/trip-full.model';

@Injectable()
export class TripService {
    tripWithCountriesAndStatistics: TripWithCountriesAndStatistics;
    constructor(private httpClient: HttpClient) { }

    getTripsWithCountriesAndStats(): Observable<TripWithCountriesAndStatistics[]> {
        return this.httpClient.get<TripWithCountriesAndStatistics[]>(environment.apiRoot + 'trips',
        { headers: { Accept: 'application/vnd.mcb.tripwithcountriesandstats+json' } });
    }
    getFullTrip(id: number): Observable<TripFull> {
        return this.httpClient.get<TripFull>(environment.apiRoot + 'trips/' + id,
        { headers: { Accept: 'application/vnd.mcb.tripfull+json' } });
    }
}
