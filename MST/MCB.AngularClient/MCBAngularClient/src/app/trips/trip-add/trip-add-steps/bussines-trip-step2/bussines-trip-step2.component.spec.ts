import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BussinesTripStep2Component } from './bussines-trip-step2.component';

describe('BussinesTripStep2Component', () => {
  let component: BussinesTripStep2Component;
  let fixture: ComponentFixture<BussinesTripStep2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BussinesTripStep2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BussinesTripStep2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
