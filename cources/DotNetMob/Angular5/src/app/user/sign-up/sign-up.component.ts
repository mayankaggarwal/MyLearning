import { UserService } from './../../shared/user.service';
import { User } from './../../shared/user.model';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  user: User;
  roles:any;
  constructor(private userService:UserService,private toastr:ToastrService) { }

  ngOnInit() {
    this.user = new User();
    this.resetForm();
    this.userService.getAllRoles().subscribe(
      (data:any)=>{
        data.forEach(element => {
          element.selected = false;
          element.NewName = element.Name;
        });

        this.roles = data;
      }
    )
  }

  resetForm(form?:NgForm){
    if(form!=null){
      form.reset();
      this.user = {
        UserName:'',
        Password:'',
        Email:'',
        FirstName:'',
        LastName:'',
        Roles:[]
      }

      if(this.roles){
        this.roles.map(x=>x.selected = false);
      }
    }
  }

  OnSubmit(form:NgForm){
    var x= this.roles.filter(x=>x.selected).map(y=>y.Name);
    this.userService.registerUser(form.value,x)
    .subscribe((data)=>{
      if(data){
        this.resetForm(form);
        this.toastr.success('User Registration Success');
      }
      else{
        this.toastr.error('User Registration Failed');
      }
    });
  }

  updateSelectedRoles(index:number){
    if(this.roles && this.roles.length>0){
      this.roles.forEach(element => {
        if(element.Id == index+1){
          if(element.selected == false){
            element.selected = true;
            element.NewName = element.Name + " Selected";
          }else{
            element.selected = false;
            element.NewName = element.Name;
          }
        }
      });
    }
  }

}
