import { Component, OnInit, Input } from '@angular/core';

import * as mapsData from 'devextreme/dist/js/vectormap-data/world.js';

// Models
import { CountryWithAssessment } from 'src/app/core/model/Geo/country-with-assessment.model';

@Component({
  selector: 'app-region-map',
  templateUrl: './region-map.component.html',
  styleUrls: ['./region-map.component.scss']
})
export class RegionMapComponent implements OnInit {

  worldMap: any = mapsData.world;

  constructor() { }

  @Input() countriesForRegion: CountryWithAssessment[];
  
  ngOnInit() {
    this.customizeLayers = this.customizeLayers.bind(this);
  }

  customizeLayers(elements) {
    elements.forEach((element) => {
      for (const entry of this.countriesForRegion) {
        if (entry.name === element.attribute('name')) {
          element.applySettings({
            color: '#0B2146',
            hoveredColor: '#e0e000',
            selectedColor: '#008f00'
          });
        }}
    })
  }
}
