import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicesOrdenEvidenceView } from './services-orden-evidence-view';

describe('ServicesOrdenEvidenceView', () => {
  let component: ServicesOrdenEvidenceView;
  let fixture: ComponentFixture<ServicesOrdenEvidenceView>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ServicesOrdenEvidenceView]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ServicesOrdenEvidenceView);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
