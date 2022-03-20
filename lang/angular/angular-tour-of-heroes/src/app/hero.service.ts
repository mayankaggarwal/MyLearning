import { Injectable } from '@angular/core';
import { Hero } from './Hero';
import { HEROES } from './mock-heroes';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { MessagesService } from './messages.service';

@Injectable()
export class HeroService {

	constructor(public messageService: MessagesService) {}

	getHeroes(): Observable<Hero[]> {
		this.messageService.add('Hero service: fetched heroes')
		return of(HEROES);
	}
}
