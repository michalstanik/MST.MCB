// Angular
import { Component, OnInit } from '@angular/core';

// Services
import { TripService } from 'src/app/core/services/trips.service';

// Model
import { TripWithCountriesAndStatistics } from 'src/app/core/model/Trip/trip-with-countries-and-statistics.model';

@Component({
  selector: 'app-trips-list',
  templateUrl: './trips-list.component.html',
  styleUrls: ['./trips-list.component.scss']
})
export class TripsListComponent implements OnInit {
  trips: TripWithCountriesAndStatistics[];
  constructor(private tripService: TripService) {}

  ngOnInit() {
      this.tripService.getTripsWithCountriesAndStats().subscribe(trips => { this.trips = trips; });
  }
}
