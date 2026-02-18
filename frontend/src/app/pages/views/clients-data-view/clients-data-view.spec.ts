import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientsDataView } from './clients-data-view';

describe('ClientsDataView', () => {
  let component: ClientsDataView;
  let fixture: ComponentFixture<ClientsDataView>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClientsDataView]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientsDataView);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
