import { Component, OnInit, Input } from '@angular/core';

// Models
import { CountryWithAssessment } from 'src/app/core/model/Geo/country-with-assessment.model';

@Component({
  selector: 'app-country-thumbnail',
  templateUrl: './country-thumbnail.component.html',
  styleUrls: ['./country-thumbnail.component.scss']
})
export class CountryThumbnailComponent implements OnInit {
  @Input() country: CountryWithAssessment;
  constructor() { }

  ngOnInit() {
  }

}
