import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardAnalysis } from './dashboard-analysis';

describe('DashboardAnalysis', () => {
  let component: DashboardAnalysis;
  let fixture: ComponentFixture<DashboardAnalysis>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DashboardAnalysis]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DashboardAnalysis);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
