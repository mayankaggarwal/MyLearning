import { DhMessageType } from './../../../enum/dh-message-type.enum';
export class DhMessage {
    public title: string;
    public description: string;
    public type: DhMessageType;
    public dhDismissible: boolean;
    private show: boolean;
}