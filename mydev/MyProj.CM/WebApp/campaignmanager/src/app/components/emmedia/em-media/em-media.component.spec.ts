import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmMediaComponent } from './em-media.component';

describe('EmMediaComponent', () => {
  let component: EmMediaComponent;
  let fixture: ComponentFixture<EmMediaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmMediaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmMediaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
