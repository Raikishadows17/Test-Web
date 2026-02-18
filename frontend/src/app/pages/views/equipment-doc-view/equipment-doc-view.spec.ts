import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EquipmentDocView } from './equipment-doc-view';

describe('EquipmentDocView', () => {
  let component: EquipmentDocView;
  let fixture: ComponentFixture<EquipmentDocView>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EquipmentDocView]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EquipmentDocView);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
