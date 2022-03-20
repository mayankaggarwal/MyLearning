import { Injectable } from "@angular/core";

@Injectable()
export class EventType{
	constructor(public id:number,public name:string,public description:string,public mediaAreaId:number){}
}
