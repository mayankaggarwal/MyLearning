export class EmCalender {
    dateFieldValue: string;
    countryCode: string;
    disableWeekend: boolean;
    minCalDate: Date;
    dateField: EmCalender;
    // tslint:disable-next-line: ban-types
    ngOuterBlur: Function;
    disabled: boolean;
    navigation: string = "select";
    showWeekNumbers: boolean = false;
    dateComparisonConstraint: DateComparisionContraint;
}

export class DateComparisionContraint {
    public dateCompareType: EMConstraintComparisionType;
    public dateCompareToProperty: string;
    public dateTargetType: string;
    public dateCompareTarget: Date;
}

export enum EMConstraintComparisionType {
    lessThan = -2,
    lessThanOrEqualTo = -1,
    greaterThanOrEqualTo = 1,
    greaterThan = 2,
    equalTo = 3
}