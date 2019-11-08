import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/Observable';

// Models
import { TripWithCountriesAndStatistics } from '../model/Trip/trip-with-countries-and-statistics.model';
import { TripFull } from '../model/Trip/trip-full.model';
import { TripForCreation } from '../model/Trip/trip-for-creation.model';
import { Trip } from '../model/Trip/trip.model';

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

    addTrip(tripToAdd: TripForCreation): Observable<Trip> {
        return this.httpClient.post<Trip>(environment.apiRoot + 'trips', tripToAdd,
        { headers: { 'Content-Type' : 'application/vnd.mcb.tripforcreation+json' } });
    }
}
