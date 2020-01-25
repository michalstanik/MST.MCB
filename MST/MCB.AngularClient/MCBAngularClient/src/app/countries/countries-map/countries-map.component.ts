import { Component, OnInit } from '@angular/core';

import * as mapsData from 'devextreme/dist/js/vectormap-data/world.js';

// Models
import { CountryWithAssessment } from 'src/app/core/model/Geo/country-with-assessment.model';
import { CountryService } from 'src/app/core/services/country.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-countries-map',
  templateUrl: './countries-map.component.html',
  styleUrls: ['./countries-map.component.scss']
})
export class CountriesMapComponent implements OnInit {

  worldMap: any = mapsData.world;
  countries: CountryWithAssessment[];

  constructor(private myCountryService: CountryService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.myCountryService.GetCountriesForUserWithAssessments()
      .subscribe(countryTrips => {
        this.countries = countryTrips as CountryWithAssessment[];
      });

    this.customizeLayers = this.customizeLayers.bind(this);
  }

  customizeLayers(elements) {
    elements.forEach((element) => {

      for (const entry of this.countries) {
        if (entry.name === element.attribute('name')) {

          switch (entry.areaLevelAssessment) {
            case 100:
              element.applySettings({
                color: '#0B2146',
                hoveredColor: '#e0e000',
                selectedColor: '#008f00'
              });
              break;
            case 90:
              element.applySettings({
                color: '#0F3956',
                hoveredColor: '#e0e000',
                selectedColor: '#008f00'
              });
              break;
            case 80:
              element.applySettings({
                color: '#135666',
                hoveredColor: '#e0e000',
                selectedColor: '#008f00'
              });
              break;
            case 70:
              element.applySettings({
                color: '#187573',
                hoveredColor: '#e0e000',
                selectedColor: '#008f00'
              });
              break;
            case 60:
              element.applySettings({
                color: '#1D846C',
                hoveredColor: '#e0e000',
                selectedColor: '#008f00'
              });
              break;
            case 50:
              element.applySettings({
                color: '#3A966F',
                hoveredColor: '#e0e000',
                selectedColor: '#008f00'
              });
              break;
            case 40:
              element.applySettings({
                color: '#57A777',
                hoveredColor: '#e0e000',
                selectedColor: '#008f00'
              });
              break;
            case 30:
              element.applySettings({
                color: '#74B883',
                hoveredColor: '#e0e000',
                selectedColor: '#008f00'
              });
              break;
            case 20:
              element.applySettings({
                color: '#92C994',
                hoveredColor: '#e0e000',
                selectedColor: '#008f00'
              });
              break;
            case 10:
              element.applySettings({
                color: '#B7D9B1',
                hoveredColor: '#e0e000',
                selectedColor: '#008f00'
              });
              break;
            case 0:
              element.applySettings({
                color: '#D8E9D0',
                hoveredColor: '#e0e000',
                selectedColor: '#008f00'
              });
              break;
          }
        }
      }
    });
  }
}
