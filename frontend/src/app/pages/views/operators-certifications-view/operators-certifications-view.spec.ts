import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OperatorsCertificationsView } from './operators-certifications-view';

describe('OperatorsCertificationsView', () => {
  let component: OperatorsCertificationsView;
  let fixture: ComponentFixture<OperatorsCertificationsView>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OperatorsCertificationsView]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OperatorsCertificationsView);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
