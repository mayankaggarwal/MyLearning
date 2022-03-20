import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmDashboardComponent } from './em-dashboard.component';

describe('EmDashboardComponent', () => {
  let component: EmDashboardComponent;
  let fixture: ComponentFixture<EmDashboardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmDashboardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
