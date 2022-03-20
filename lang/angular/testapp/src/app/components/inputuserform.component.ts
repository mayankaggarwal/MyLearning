import { Component } from "@angular/core";
import { User } from "../models/signup.interface";

@Component({
	selector:'signup-form',
	templateUrl:'./inputuserform.component.html'
})

export class InputUserForm{
	constructor() {}
	user: User = {
		name:'Mayank',
		account:{
			email:'',
			confirm:''
		}
	}

	onSubmit({value,valid}:{value:User,valid:boolean}){
		console.log(value,valid);
	}

}
