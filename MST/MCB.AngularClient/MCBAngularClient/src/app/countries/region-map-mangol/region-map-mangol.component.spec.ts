import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegionMapMangolComponent } from './region-map-mangol.component';

describe('RegionMapMangolComponent', () => {
  let component: RegionMapMangolComponent;
  let fixture: ComponentFixture<RegionMapMangolComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegionMapMangolComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegionMapMangolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
