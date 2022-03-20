import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BookstoreFormComponent } from './bookstore-form.component';

describe('BookstoreFormComponent', () => {
  let component: BookstoreFormComponent;
  let fixture: ComponentFixture<BookstoreFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BookstoreFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BookstoreFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
