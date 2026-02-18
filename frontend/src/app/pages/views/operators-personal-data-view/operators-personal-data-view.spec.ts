import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OperatorsPersonalDataView } from './operators-personal-data-view';

describe('OperatorsPersonalDataView', () => {
  let component: OperatorsPersonalDataView;
  let fixture: ComponentFixture<OperatorsPersonalDataView>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OperatorsPersonalDataView]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OperatorsPersonalDataView);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
