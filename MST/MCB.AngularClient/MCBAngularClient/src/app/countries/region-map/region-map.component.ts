import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { Router } from '@angular/router';

import * as mapsData from 'devextreme/dist/js/vectormap-data/world.js';

// Models
import { CountryWithAssessment } from 'src/app/core/model/Geo/country-with-assessment.model';
import { RegionWithCountriesAndAssessment } from 'src/app/core/model/Geo/region-with-countries-and-assessment.model';
import { DxVectorMapComponent } from 'devextreme-angular';

@Component({
  selector: 'app-region-map',
  templateUrl: './region-map.component.html',
  styleUrls: ['./region-map.component.scss']
})
export class RegionMapComponent implements OnInit {

  @ViewChild(DxVectorMapComponent, { static: false }) vectorMap: DxVectorMapComponent
  worldMap: any = mapsData.world;

  constructor(private router: Router) {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
}

  @Input() countriesForMap: CountryWithAssessment[];
  @Input() region: RegionWithCountriesAndAssessment;

  ngOnInit() {
    this.customizeLayers = this.customizeLayers.bind(this);
    //console.log(this.region.minLongitude, this.region.maxLatitude, this.region.maxLongitude, this.region.minLatitude);
    this.vectorMap.bounds.push(this.region.minLongitude, this.region.maxLatitude, this.region.maxLongitude, this.region.minLatitude);
  }

  latlongbounds(){
     //console.log(this.region.minLongitude, this.region.maxLatitude, this.region.maxLongitude, this.region.minLatitude);
     //cord.push(this.region.minLongitude, this.region.maxLatitude, this.region.maxLongitude, this.region.minLatitude);
     return "[15.5, 60, 100, 35]";
  }

  customizeLayers(elements) {
    elements.forEach((element) => {
      for (const entry of this.countriesForMap) {
        if (entry.name === element.attribute('name')) {
          if(entry.areaLevelAssessment == 0){
            element.applySettings({
              color: '#0B2146',
              hoveredColor: '#e0e000',
              selectedColor: '#008f00'
          });         
          }
          if(entry.areaLevelAssessment != 0){
            element.applySettings({
              color: '#0be66a',
              hoveredColor: '#e0e000',
              selectedColor: '#008f00'
          });         
          }
        }}
    })
  }
}
