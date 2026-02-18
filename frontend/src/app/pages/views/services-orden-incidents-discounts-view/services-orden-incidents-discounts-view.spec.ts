import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicesOrdenIncidentsDiscountsView } from './services-orden-incidents-discounts-view';

describe('ServicesOrdenIncidentsDiscountsView', () => {
  let component: ServicesOrdenIncidentsDiscountsView;
  let fixture: ComponentFixture<ServicesOrdenIncidentsDiscountsView>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ServicesOrdenIncidentsDiscountsView]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ServicesOrdenIncidentsDiscountsView);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
