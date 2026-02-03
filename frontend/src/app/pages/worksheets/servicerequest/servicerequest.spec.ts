import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Servicerequest } from './servicerequest';

describe('Servicerequest', () => {
  let component: Servicerequest;
  let fixture: ComponentFixture<Servicerequest>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Servicerequest]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Servicerequest);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
