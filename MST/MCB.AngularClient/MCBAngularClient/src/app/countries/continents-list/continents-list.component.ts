import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

// Models
import { ContinentWithRegionsAndCountriesModel } from 'src/app/core/model/Geo/continent-with-regions-and-countries.model';

// Services
import { ContinentService } from 'src/app/core/services/continent.service';


@Component({
  selector: 'app-continents-list',
  templateUrl: './continents-list.component.html',
  styleUrls: ['./continents-list.component.scss']
})
export class ContinentsListComponent implements OnInit {

  myCountries: ContinentWithRegionsAndCountriesModel[];
  constructor(private myContinetService: ContinentService, private router: Router) { }

  ngOnInit() {
    this.myContinetService.GetCountriesForUserByContinent().subscribe(myCountries => { this.myCountries = myCountries; });
  }

}
