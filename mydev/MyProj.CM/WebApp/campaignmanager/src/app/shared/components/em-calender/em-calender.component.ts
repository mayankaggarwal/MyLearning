import { Component, OnInit, Input, Output, EventEmitter, ViewChildren, forwardRef } from '@angular/core';
import { NgbDateStruct, NgbDatepickerConfig, NgbDatepickerI18n, NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import { EmCalender } from './em-calender.model';
import * as moment from 'moment';
import { NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-em-calender',
  templateUrl: './em-calender.component.html',
  styleUrls: ['./em-calender.component.css'],
  providers: [
    I18n, {provide: NgbDatepickerI18n, useClass: EMCalenderI18n},
    NgbDatepickerConfig,
    {provide: NgbDateParserFormatter, useClass: NgbDateCustomParserFormatter },
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => EmCalenderComponent),
      multi: true
    }
  ]
})
export class EmCalenderComponent implements OnInit {

  @Input('name') name:string;
  @Input('displayMonths') displayMonths: any;
  @Input('navigation') navigation: any;
  @Input("showWeekNumbers") showWeekNumbers: any;
  @Input("disabled") disabled: any;
  @Input("minDate") minDate:NgbDateStruct

  @Input("emCalenderOptions") emCalenderOptions:EmCalender;
  @Output() dateChange: EventEmitter<string> = new EventEmitter<string>();
  @ViewChildren("d") datePicker: any;

  protected onChange: any = () => {};
  protected onTouched: any = () => {};
  pruvate now = new Date();

  editDateField: NgbDateStruct;
  constructor(private config: NgbDatepickerConfig) { }

  ngOnInit() {
    enum localizedDateOptions {
      "BR" = 0,
      "CA" = 0,
      "CN" = 1,
      "default" = 0
    }

    if (this.emCalenderOptions.minCalDate != null && this.emCalenderOptions.minCalDate !== undefined) {
      this.config.minDate = { 
        year: this.emCalenderOptions.minCalDate.getFullYear()
        , month: this.emCalenderOptions.minCalDate.getMonth() + 1
        , day: this.emCalenderOptions.minCalDate.getDate()
      };
    }

    this.config.startDate = localizedDateOptions[this.emCalenderOptions.countryCode] || localizedDateOptions["default"];

    if (!this.emCalenderOptions.dateField || !this.emCalenderOptions.dateField.dateFieldValue) {
      this.editDateField = null;
    } else {
      const parsedDate = moment(this.emCalenderOptions.dateField.dateFieldValue);
      if (parsedDate && (parsedDate.year() === 1970 || parsedDate.year() === 1969)) {
        this.editDateField = null;
      } else {
        const date = new Date(this.emCalenderOptions.dateField.dateFieldValue);
        this.editDateField = { day: date.getDate(), month: date.getMonth() + 1, year: date.getFullYear()};
      }
    }
  }

  dateModelChange() {
    if (!this.editDateField) {
      this.emCalenderOptions.dateField = null;
    } else {
      const utcTimestamp = moment.utc(
        moment.utc(this.editDateField.year + "-" + this.editDateField.month + "-" + this.editDateField.day, 'YYYY-MM-D')
        .toISOString()).valueOf();
      this.emCalenderOptions.dateField.dateFieldValue = moment.utc(utcTimestamp).toISOString();
    }
    this.dateChange.next(this.emCalenderOptions.dateField.dateFieldValue);
  }

  onInnerBlur = function() {
    (this.ngOuterBlur || function(){})();
  }

  public writeValue(value: any): void {
    if(value) {
      if (value === '') value = null;
      this.emCalenderOptions.dateField.dateFieldValue = value;
    }
  }

  public registerOnChange(fn: (_: any) => {}): void { this.onChange = fn; }

  public registerOnTouched(fn: () => {}): void { this.onTouched = fn; }

}
