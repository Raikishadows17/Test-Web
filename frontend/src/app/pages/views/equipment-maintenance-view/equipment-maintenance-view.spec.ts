import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EquipmentMaintenanceView } from './equipment-maintenance-view';

describe('EquipmentMaintenanceView', () => {
  let component: EquipmentMaintenanceView;
  let fixture: ComponentFixture<EquipmentMaintenanceView>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EquipmentMaintenanceView]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EquipmentMaintenanceView);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
