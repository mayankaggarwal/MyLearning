import {Component,OnInit } from "@angular/core";
import { FormBuilder,FormGroup,Validators,FormArray } from "@angular/forms";
import { EventType } from "../models/em-event-type.model";
import { EventService } from "../services/eventservice";
import { Event } from "../models/em-event.model";
import { EventChannel } from "../models/em-event-channel.model";

@Component({
	selector:"eventformcomponent",
	templateUrl:"./eventformcomponent.html"
})

export class EventFormComponent implements OnInit {
	private eventTypes:Array<EventType>;
	private eventForm:FormGroup;
	private selectedEventType:EventType;
	private eventModel:Event;
	public eventChannels:Array<EventChannel>;
	public selectedChannelsArray:number[];
	constructor(private fb:FormBuilder,private eventService:EventService){
		eventService.getEventTypes().subscribe(result=>{
			this.eventTypes = result;
		});
		this.selectedEventType = null;
		this.eventModel = new Event(0,new Array<EventChannel>(),0);
		this.eventService.getChannels("temp").subscribe(result=>{
			this.eventChannels = result;
		});
	}
	ngOnInit(){
		this.createForm();
		console.log(this.eventChannels);
		console.log(this.channels);
		this.selectedChannelsArray = this.mapChannels(this.eventChannels);
	}

	createForm(){
		let eventChannelsArray = this.fb.array(this.eventChannels.map((ev)=>{
	return this.fb.group({
		key:[ev.id],
		value:[ev.name],
		checked:[ev.checked]
	});
}));
		this.eventForm = this.fb.group({
			eventType:['',Validators.required],
			eventName:['',Validators.required],
			//channelsKey:eventChannelsArray,
			selectedChannels: [this.selectedChannelsArray,Validators.required],
			//skills: this.buildEventChannels()
		});
	}

	mapChannels(chs){
		console.log(chs);
		//let selectedChannels = chs.filter((c) => c.checked).map((c) => c.key);
		//return selectedChannels.length?selectedChannels:null;
		let selectedChannels = chs.filter((c) => c.checked).map((c) => c.id);
		return selectedChannels?selectedChannels.length?selectedChannels:null:null;
	}
	
	get channels(){
		return this.eventForm.get('channelsKey');
	}
	get selectedChannels(){
		return this.eventForm.get('selectedChannels');
	}
	buildEventChannels() {
		if(this.eventModel && this.eventModel.eventChannel){
    		const arr = this.eventModel.eventChannel.map(ev => {
     	 		return this.fb.control('');
    		});
    		return this.fb.array(arr);
		}
		else{
			return this.fb.array([]);
		}	
  	}

	onEventTypeChange($eventType){
		//console.log($eventType);
		if($eventType){
		this.eventService.updateChannelsAndMediaType(this.eventModel,$eventType.name).subscribe(result => {
			//console.log(this.eventModel.eventTypeId);
			console.log(this.eventModel);
		});
		}
		//console.log(this.eventModel.eventTypeId);
		const control = <FormArray>this.eventForm.controls['skills'];
		if(control){
		if(control.controls && control.controls.length>0)
		{
			for(var i=0;i < control.controls.length;i++){
				control.removeAt(i);
			}
		}
		//control.push(this.eventModel.eventChannel.map((ev) => {
		//	return this.fb.group({
		//		key:[ev.id],
		//		value:[ev.name],
		//		checked:[ev.checked],
		//	});
		//}));
		}
		console.log(control);
		
	}
}
