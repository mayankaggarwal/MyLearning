import { Component } from "@angular/core";

@Component({
	selector:'app-key-up1',
	template:`<input (keyup)="onKey($event)">
				<p>{{values}}</p>
			  <input #box (keyup)="onKey1(box)">
				<p>{{values1}}</p>`
})

export class KeyUpComponent_V1{
	values = '';
	values1 = '';
	onKey(event:any){
		this.values += event.target.value + '|';
	}

	onKey1(box:any){
		this.values1 += box.value + '|';
	}
}
