import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

// Models
import { ContinentWithRegionsAndCountriesModel } from 'src/app/core/model/Geo/continent-with-regions-and-countries.model';

// Services
import { CountryService } from 'src/app/core/services/country.service';


@Component({
  selector: 'app-continents-list',
  templateUrl: './continents-list.component.html',
  styleUrls: ['./continents-list.component.scss']
})
export class ContinentsListComponent implements OnInit {

  myCountries: ContinentWithRegionsAndCountriesModel[];
  constructor(private myCountryService: CountryService, private router: Router) { }

  ngOnInit() {
    this.myCountryService.GetCountriesForUserByContinent().subscribe(myCountries => { this.myCountries = myCountries; });
  }

}
