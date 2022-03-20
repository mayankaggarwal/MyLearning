import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { of } from "rxjs/observable/of";
import { EventType } from "../models/em-event-type.model";
import { Event } from "../models/em-event.model";
import { EventChannel } from "../models/em-event-channel.model";
import { forkJoin } from "rxjs/observable/forkJoin";

@Injectable()
export class EventService {
	private mediaTypesLookupLoader:Observable<Object> = null;
	private mediaTypesLookup:Object = null;
	private eventTypesLoader:Observable<Array<EventType>>;
	private lookupCache:Object = {};

	public getEventTypes():Observable<Array<EventType>> {
		let eventtypes = new Array<EventType>();
		eventtypes.push(new EventType(1,"BCM","Best Customer Mailer",1));
		eventtypes.push(new EventType(2,"LCM","Loyal Customer Mailer",1));
		eventtypes.push(new EventType(3,"Statement","Statements",1));

		return of(eventtypes);
	}

	public getChannels(mediaAreaName:string):Observable<Array<EventChannel>>{
		let eventChannels = new Array<EventChannel>();
		eventChannels.push(new EventChannel(1,"App","",1,true));
		eventChannels.push(new EventChannel(2,"Web","",2,true));
		eventChannels.push(new EventChannel(3,"At Till","",3,true));
		return of(eventChannels);

	}
	public preloadEventTypes():Observable<Array<EventType>>{
		this.eventTypesLoader = this.eventTypesLoader || this.getEventTypes();
		return this.eventTypesLoader;
	}

	public preloadMediaTypesLookup():Observable<Object>{
		if(null != this.mediaTypesLookupLoader) { return this.mediaTypesLookupLoader;}

		this.preloadEventTypes().subscribe( result => {
			if(null === this.mediaTypesLookup) {
				let newLookup: Object = new Object();
				for(let mediaType of result){
					newLookup[mediaType.id] = mediaType;
					newLookup[mediaType.name] = mediaType;
				}

				this.mediaTypesLookup = newLookup;
			}
			this.mediaTypesLookupLoader = of(this.mediaTypesLookup);

			});
		this.mediaTypesLookupLoader = of(this.mediaTypesLookup);
		return this.mediaTypesLookupLoader;
	}
	

	public updateEventType(targetModel:Event,mediaTypeName:string):Observable<any>{
		if((null === mediaTypeName) || (!mediaTypeName)){
			targetModel.eventTypeId = null;
			return of(null)
		} else {
			this.preloadMediaTypesLookup().subscribe(result =>{
				targetModel.eventTypeId = result[mediaTypeName].id;
			});
		}

		return of(targetModel.id);
	}

	public reloadChannels(targetModel:Event, mediaAreaName:string):Observable<any>{
		targetModel.eventChannel = new Array<EventChannel>();
		this.getEventChannelModel(mediaAreaName)
				.subscribe(result =>{
					targetModel.eventChannel = result;
				});
		return of(targetModel.eventChannel);
	}

	public getEventChannelModel(mediaAreaName:string):Observable<Array<EventChannel>> {
		if(!mediaAreaName){
			return of(new Array<EventChannel>());
		}
		if(mediaAreaName in this.lookupCache){
			return of(this.lookupCache[mediaAreaName]);
		}

		this.getChannels(mediaAreaName).subscribe(result=>{
			this.lookupCache[mediaAreaName] = result;
		});
		return of(this.lookupCache[mediaAreaName]);
	}

	public updateChannelsAndMediaType(targetModel:Event,mediaTypeName:string):Observable<any>{
		targetModel.eventChannel = null;
		return forkJoin(this.updateEventType(targetModel,mediaTypeName),this.reloadChannels(targetModel,mediaTypeName));
	}
}
