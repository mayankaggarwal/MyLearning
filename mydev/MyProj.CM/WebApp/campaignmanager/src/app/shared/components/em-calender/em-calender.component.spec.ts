import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmCalenderComponent } from './em-calender.component';

describe('EmCalenderComponent', () => {
  let component: EmCalenderComponent;
  let fixture: ComponentFixture<EmCalenderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmCalenderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmCalenderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
