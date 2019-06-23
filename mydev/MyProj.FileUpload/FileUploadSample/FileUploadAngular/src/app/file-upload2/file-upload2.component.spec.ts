import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FileUpload2Component } from './file-upload2.component';

describe('FileUpload2Component', () => {
  let component: FileUpload2Component;
  let fixture: ComponentFixture<FileUpload2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FileUpload2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FileUpload2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
