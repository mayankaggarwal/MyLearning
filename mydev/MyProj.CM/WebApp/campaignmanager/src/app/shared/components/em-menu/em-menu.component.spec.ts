import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmMenuComponent } from './em-menu.component';

describe('EmMenuComponent', () => {
  let component: EmMenuComponent;
  let fixture: ComponentFixture<EmMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmMenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
