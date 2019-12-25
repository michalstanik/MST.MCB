import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

// Services
import { RegionService } from 'src/app/core/services/region.service';
import { RegionWithCountriesAndAssessment } from 'src/app/core/model/Geo/region-with-countries-and-assessment.model';

@Component({
  selector: 'app-region-details',
  templateUrl: './region-details.component.html',
  styleUrls: ['./region-details.component.scss']
})
export class RegionDetailsComponent implements OnInit {

  region: RegionWithCountriesAndAssessment;

  constructor(private regionService: RegionService,
              private route: ActivatedRoute) { }

              ngOnInit() {
                this.route.params.forEach((params: Params) => {
                  console.log('Param', params.id);
                  this.regionService.GetRegionWithUserVisits(+params.id)
                      .subscribe(region => {
                          this.region = region;
                      });
              });
                console.log('Countries length', this.region.countries.length);
              }

}
