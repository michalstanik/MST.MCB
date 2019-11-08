import { Component, OnInit, Input } from '@angular/core';

// Model
import { Country } from 'src/app/core/model/Geo/country.model';

@Component({
  selector: 'app-countries-list',
  templateUrl: './countries-list.component.html',
  styleUrls: ['./countries-list.component.scss']
})
export class CountriesListComponent implements OnInit {

  constructor() { }

  @Input() countriesForTrip: Country[];

  ngOnInit() {
  }

}
