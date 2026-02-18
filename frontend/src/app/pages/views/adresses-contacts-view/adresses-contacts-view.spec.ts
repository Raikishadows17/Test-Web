import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdressesContactsView } from './adresses-contacts-view';

describe('AdressesContactsView', () => {
  let component: AdressesContactsView;
  let fixture: ComponentFixture<AdressesContactsView>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdressesContactsView]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdressesContactsView);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
