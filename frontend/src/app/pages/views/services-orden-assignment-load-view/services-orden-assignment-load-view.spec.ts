import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicesOrdenAssignmentLoadView } from './services-orden-assignment-load-view';

describe('ServicesOrdenAssignmentLoadView', () => {
  let component: ServicesOrdenAssignmentLoadView;
  let fixture: ComponentFixture<ServicesOrdenAssignmentLoadView>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ServicesOrdenAssignmentLoadView]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ServicesOrdenAssignmentLoadView);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
