import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OperatorsFrom } from './operators-form';

describe('OperatorsFrom', () => {
  let component: OperatorsFrom;
  let fixture: ComponentFixture<OperatorsFrom>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OperatorsFrom]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OperatorsFrom);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
