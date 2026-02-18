import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EquipmentVisualPhotoView } from './equipment-visual-photo-view';

describe('EquipmentVisualPhotoView', () => {
  let component: EquipmentVisualPhotoView;
  let fixture: ComponentFixture<EquipmentVisualPhotoView>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EquipmentVisualPhotoView]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EquipmentVisualPhotoView);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
