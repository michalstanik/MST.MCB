import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryThumbnailComponent } from './country-thumbnail.component';

describe('CountryThumbnailComponent', () => {
  let component: CountryThumbnailComponent;
  let fixture: ComponentFixture<CountryThumbnailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CountryThumbnailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryThumbnailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
