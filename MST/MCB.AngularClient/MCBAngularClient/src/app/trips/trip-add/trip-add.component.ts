import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

// Extrnall
import { Subject, Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';

// Services
import { TripService } from 'src/app/core/services/trips.service';
import { CountryDictionaryService } from 'src/app/core/services/country-dictionary.service';
import { ToastrService } from 'src/app/core/services/toastr.service';

// Model
import { CountryWithAssessment } from 'src/app/core/model/Geo/country-with-assessment.model';

@Component({
  selector: 'app-trip-add',
  templateUrl: './trip-add.component.html',
  styleUrls: ['./trip-add.component.scss']
})
export class TripAddComponent implements OnInit {

  countriesList: Array<CountryWithAssessment>;
  secondFormGroup: FormGroup;

  tripTypeForm: FormGroup;

  public tripForm: FormGroup;
  tripTypes: Array<any>;

  searchText = new Subject();

  results: Observable<CountryWithAssessment[]>;
  data: any = [
    'red',
    'green',
    'blue',
    'cyan',
    'magenta',
    'yellow',
    'black',
  ];

  constructor( private formBuilder: FormBuilder,
               private tripService: TripService,
               private countryDictionaryService: CountryDictionaryService,
               private router: Router,
               private toastr: ToastrService ) { }

  ngOnInit() {
    this.countryDictionaryService.GetAllCountriesWithUserAssessment()
      .subscribe(
        (countriesList) => {
          this.countriesList = countriesList;
        });

    this.results = this.searchText.pipe(
      startWith(''),
      map((value: string) => this.filter(CountryWithAssessment.name))
    );

    this.tripTypeForm = new FormGroup({
      tripTypesOptions: new FormControl('', [Validators.required])
    });
    this.secondFormGroup = new FormGroup({
      password: new FormControl('', Validators.required)
    });
        // define the tripForm (with empty default values)
    this.tripForm = this.formBuilder.group({
          name: ['']
        });

    this.tripTypes = [
          { value: '1', label: 'Bussiness Trip' },
          { value: '2', label: 'Just Visit' },
          { value: '3', label: 'Transfer' },
          { value: '4', label: 'Real Trip' }
        ];
  }

  get tripTypesOptions() { return this.tripTypeForm.get('tripTypesOptions'); }
  get password() { return this.secondFormGroup.get('password'); }

  filter(value: string): CountryWithAssessment[] | undefined {
    const filterValue = value.toLowerCase();
    if (this.countriesList) {
      return this.countriesList.filter((item: CountryWithAssessment) => item.name.toLowerCase().includes(filterValue));
    }
  }

  onSubmit() {
    // do something here
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
