import { Component, OnInit, Input } from '@angular/core';

// Models
import { CountryWithAssessment } from 'src/app/core/model/Geo/country-with-assessment.model';

@Component({
  selector: 'app-country-list-for-region',
  templateUrl: './country-list-for-region.component.html',
  styleUrls: ['./country-list-for-region.component.scss']
})
export class CountryListForRegionComponent implements OnInit {

  constructor() { }

  @Input() countriesForRegion: CountryWithAssessment[];

  ngOnInit() {

  }
}
