import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmHeaderComponent } from './em-header.component';

describe('EmHeaderComponent', () => {
  let component: EmHeaderComponent;
  let fixture: ComponentFixture<EmHeaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmHeaderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
