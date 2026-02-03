import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EquipmentCatalogForm } from './equipment-catalog-form';

describe('EquipmentCatalogForm', () => {
  let component: EquipmentCatalogForm;
  let fixture: ComponentFixture<EquipmentCatalogForm>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EquipmentCatalogForm]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EquipmentCatalogForm);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
