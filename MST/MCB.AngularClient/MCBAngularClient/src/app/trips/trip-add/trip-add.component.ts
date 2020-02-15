import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';
import { Router } from '@angular/router';

// Services
import { TripService } from 'src/app/core/services/trips.service';
import { ToastrService } from 'src/app/core/services/toastr.service';

@Component({
  selector: 'app-trip-add',
  templateUrl: './trip-add.component.html',
  styleUrls: ['./trip-add.component.scss']
})
export class TripAddComponent implements OnInit {
  public tripForm: FormGroup;
  constructor( private formBuilder: FormBuilder,
               private tripService: TripService,
               private router: Router,
               private toastr: ToastrService ) { }

  ngOnInit() {
        // define the tripForm (with empty default values)
        this.tripForm = this.formBuilder.group({
          name: ['']
        });
  }

  addTrip(): void {
    if (this.tripForm.dirty) {

      // Create TripForCreation from form model
      const trip = automapper.map(
        'TripFormModel',
        'TripForCreation',
        this.tripForm.value);

      this.tripService.addTrip(trip)
          .subscribe(
            () => {
              this.router.navigateByUrl('/trips');
            });

      this.toastr.success('Trip created: ' + trip.name);
    }
  }
}
