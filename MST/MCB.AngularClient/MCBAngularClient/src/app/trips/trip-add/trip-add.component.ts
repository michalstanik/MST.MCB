import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';

@Component({
  selector: 'app-trip-add',
  templateUrl: './trip-add.component.html',
  styleUrls: ['./trip-add.component.scss']
})
export class TripAddComponent implements OnInit {
  public tripForm: FormGroup;
  constructor( private formBuilder: FormBuilder) { }

  ngOnInit() {
        // define the tripForm (with empty default values)
        this.tripForm = this.formBuilder.group({
          name: ['']
        });
  }

  addTrip(): void {
    if (this.tripForm.dirty) {

    }
  }
}
