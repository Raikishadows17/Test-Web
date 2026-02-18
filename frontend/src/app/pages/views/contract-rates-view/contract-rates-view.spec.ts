import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContractRatesView } from './contract-rates-view';

describe('ContractRatesView', () => {
  let component: ContractRatesView;
  let fixture: ComponentFixture<ContractRatesView>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ContractRatesView]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ContractRatesView);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
