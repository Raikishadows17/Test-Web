import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OperatorsEmploymentDataView } from './operators-employment-data-view';

describe('OperatorsEmploymentDataView', () => {
  let component: OperatorsEmploymentDataView;
  let fixture: ComponentFixture<OperatorsEmploymentDataView>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OperatorsEmploymentDataView]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OperatorsEmploymentDataView);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
