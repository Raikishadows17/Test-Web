import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceOrdersForm } from './service-orders-form';

describe('ServiceOrdersForm', () => {
  let component: ServiceOrdersForm;
  let fixture: ComponentFixture<ServiceOrdersForm>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ServiceOrdersForm]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ServiceOrdersForm);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
