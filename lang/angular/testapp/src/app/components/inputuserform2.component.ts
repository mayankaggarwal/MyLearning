import { Component,OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { User } from "../models/signup.interface";

@Component({
	selector:'signup-form2',
	templateUrl:'./inputuserform2.component.html'
})

export class InputUserForm2{
	constructor() {}

	user: FormGroup;

	ngOnInit() {
		this.user = new FormGroup({
			name : new FormControl(''),
			account: new FormGroup({
				email: new FormControl(''),
				confirm: new FormControl('')
			})
		});
	}

	onSubmit(){
		console.log(this.user.value,this.user.valid);
	}
}
