import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryListForRegionComponent } from './country-list-for-region.component';

describe('CountryListForRegionComponent', () => {
  let component: CountryListForRegionComponent;
  let fixture: ComponentFixture<CountryListForRegionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CountryListForRegionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryListForRegionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
