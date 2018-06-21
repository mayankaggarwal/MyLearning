import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public userClaims:any;
  constructor(private router:Router,private userService:UserService) { }

  ngOnInit() {
    this.userService.getUserClaims()
    .subscribe((data:any)=>{
      this.userClaims = data;
    })
  }

  public Logout(){
    localStorage.removeItem('userToken');
    this.router.navigate(['/login']); 
  }
}
