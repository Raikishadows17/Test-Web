import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EquipmentGeneralView } from './equipment-general-view';

describe('EquipmentGeneralView', () => {
  let component: EquipmentGeneralView;
  let fixture: ComponentFixture<EquipmentGeneralView>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EquipmentGeneralView]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EquipmentGeneralView);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
