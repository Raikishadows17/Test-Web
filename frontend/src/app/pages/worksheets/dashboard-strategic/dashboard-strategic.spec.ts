import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardStrategic } from './dashboard-strategic';

describe('DashboardStrategic', () => {
  let component: DashboardStrategic;
  let fixture: ComponentFixture<DashboardStrategic>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DashboardStrategic]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DashboardStrategic);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
