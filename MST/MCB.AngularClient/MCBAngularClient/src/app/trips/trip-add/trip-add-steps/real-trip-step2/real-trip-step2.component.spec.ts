import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RealTripStep2Component } from './real-trip-step2.component';

describe('RealTripStep2Component', () => {
  let component: RealTripStep2Component;
  let fixture: ComponentFixture<RealTripStep2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RealTripStep2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RealTripStep2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
