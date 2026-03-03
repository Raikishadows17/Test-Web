import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArmedTractView } from './armed-tract-view';

describe('ArmedTractView', () => {
  let component: ArmedTractView;
  let fixture: ComponentFixture<ArmedTractView>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ArmedTractView]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ArmedTractView);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
