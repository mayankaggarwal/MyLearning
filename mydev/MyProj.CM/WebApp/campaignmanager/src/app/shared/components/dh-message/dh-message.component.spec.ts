import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DhMessageComponent } from './dh-message.component';

describe('DhMessageComponent', () => {
  let component: DhMessageComponent;
  let fixture: ComponentFixture<DhMessageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DhMessageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DhMessageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
