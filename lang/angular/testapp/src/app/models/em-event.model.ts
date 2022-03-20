import { Injectable } from "@angular/core";
import { EventChannel } from "./em-event-channel.model";
import { EventType } from "./em-event-type.model";
@Injectable()
export class Event {
	constructor(public id:number,public eventChannel:Array<EventChannel>,public eventTypeId:number){}
}
