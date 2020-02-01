import { Component, OnInit } from '@angular/core';
import View from 'ol/View';
import { fromLonLat } from 'ol/proj.js';
import TileLayer from 'ol/layer/Tile';
import OSM from 'ol/source/OSM';
import { MangolConfig, MangolLayer } from 'mangol';

@Component({
  selector: 'app-region-map-mangol',
  templateUrl: './region-map-mangol.component.html',
  styleUrls: ['./region-map-mangol.component.scss']
})
export class RegionMapMangolComponent implements OnInit {

  mangolConfig: MangolConfig;
  constructor() { }

  ngOnInit() {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(this.displayLocation, this.displayLocationError);
    }

    this.mangolConfig = {
      map: {
        target: 'mangol-demo',
        view: new View({
          projection: 'EPSG:900913',
          center: fromLonLat(
            [19.3956393810065, 47.168464955013],
            'EPSG:900913'
          ),
          zoom: 3,
          enableRotation: true
        }),
        controllers: {
          zoom: {
            show: true,
            showTooltip: true,
            dictionary: {
              zoomIn: 'Zoom in',
              zoomOut: 'Zoom out'
            }
          },
          position: {
            show: true,
            precision: 2
          },
          rotation: {
            show: true,
            dictionary: {
              rotateToNorth: 'Rotate to North'
            },
            showTooltip: true
          }
        },
        layers: [
          new MangolLayer({
            name: 'OpenStreetMap Layer',
            details: 'Here are the OSM layer details',
            layer: new TileLayer({
              source: new OSM(),
              visible: true
            })
          })
        ]
      },
      sidebar: {
        opened: false,
        toolbar: {
          layertree: {},
          measure: {}
        }
      },
    };
  }

  private displayLocation(position) {
    const latitude = position.coords.latitude;
    const longitude = position.coords.longitude;

    const pLocation = document.getElementById('location');
    pLocation.innerHTML += latitude + ', ' + longitude + '<br>';

    const pInfo = document.getElementById('info');
    const date = new Date(position.timestamp);
    pInfo.innerHTML = 'Location timestamp: ' + date + '<br>';
    pInfo.innerHTML += 'Accuracy of location: ' + position.coords.Accuracy + ' meters<br>';
  }

  private displayLocationError(error) {
    const errors = [
      'Unknown Error',
      'Permission denied by user',
      'Position not avaliable',
      'Timeout error'
    ];
    const message = errors[error.code];
    console.warn('Error in getting location: ' + message, error.message);
  }
}
