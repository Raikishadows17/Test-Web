import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicesOrdenOperationalMonitoringView } from './services-orden-operational-monitoring-view';

describe('ServicesOrdenOperationalMonitoringView', () => {
  let component: ServicesOrdenOperationalMonitoringView;
  let fixture: ComponentFixture<ServicesOrdenOperationalMonitoringView>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ServicesOrdenOperationalMonitoringView]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ServicesOrdenOperationalMonitoringView);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
