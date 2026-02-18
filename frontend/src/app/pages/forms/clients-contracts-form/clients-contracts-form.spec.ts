import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientsContractsForm } from './clients-contracts-form';

describe('ClientsContractsForm', () => {
  let component: ClientsContractsForm;
  let fixture: ComponentFixture<ClientsContractsForm>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClientsContractsForm]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientsContractsForm);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
