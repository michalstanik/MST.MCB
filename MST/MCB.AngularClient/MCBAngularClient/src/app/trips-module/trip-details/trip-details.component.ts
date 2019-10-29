import { Component, OnInit } from '@angular/core';
import { Params, ActivatedRoute } from '@angular/router';
import { TripService } from 'src/app/core/services/trips.service';
import { TripFull } from 'src/app/core/model/Trip/trip-full.model';

@Component({
  selector: 'app-trip-details',
  templateUrl: './trip-details.component.html',
  styleUrls: ['./trip-details.component.scss']
})
export class TripDetailsComponent implements OnInit {

  trip: TripFull;
  constructor(private tripService: TripService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.forEach((params: Params) => {
      this.tripService.getFullTrip(+params.id)
          .subscribe(trip => {
              this.trip = trip;
          });
  });
  }

}
