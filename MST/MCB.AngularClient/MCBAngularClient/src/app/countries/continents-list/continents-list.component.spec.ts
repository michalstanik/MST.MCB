import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContinentsListComponent } from './continents-list.component';

describe('ContinentsListComponent', () => {
  let component: ContinentsListComponent;
  let fixture: ComponentFixture<ContinentsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContinentsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContinentsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
