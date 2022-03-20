import { Injectable } from "@angular/core";

@Injectable()
export class EventChannel{
	constructor(public id:number,public name:string,public description:string,public channelId:number,public checked:boolean){}
}
