import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TripsRootComponent } from './trips-root.component';

describe('TripsRootComponent', () => {
  let component: TripsRootComponent;
  let fixture: ComponentFixture<TripsRootComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TripsRootComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TripsRootComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
