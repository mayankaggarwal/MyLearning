import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmFooterComponent } from './em-footer.component';

describe('EmFooterComponent', () => {
  let component: EmFooterComponent;
  let fixture: ComponentFixture<EmFooterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmFooterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmFooterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
