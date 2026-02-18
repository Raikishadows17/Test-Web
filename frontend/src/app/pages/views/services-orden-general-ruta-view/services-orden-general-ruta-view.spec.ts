import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicesOrdenGeneralRutaView } from './services-orden-general-ruta-view';

describe('ServicesOrdenGeneralRutaView', () => {
  let component: ServicesOrdenGeneralRutaView;
  let fixture: ComponentFixture<ServicesOrdenGeneralRutaView>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ServicesOrdenGeneralRutaView]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ServicesOrdenGeneralRutaView);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
