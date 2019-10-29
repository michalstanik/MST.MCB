// Angular
import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

// Model
import { TripWithCountriesAndStatistics } from 'src/app/core/model/Trip/trip-with-countries-and-statistics.model';

@Component({
  selector: 'app-trip-thumbnail',
  templateUrl: './trip-thumbnail.component.html',
  styleUrls: ['./trip-thumbnail.component.scss']
})

export class TripThumbnailComponent {
   @Input() trip: TripWithCountriesAndStatistics;

  constructor(private router: Router) {}

  navigate() {
      this.router.navigate(['/trips', this.trip.id]);
  }
}
