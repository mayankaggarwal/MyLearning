import { ConfigService } from './../config.service';
import { Location } from '@angular/common';
import { AuthenticationService } from './../authentication.service';
import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
  menu:any[];
  isloggedIn: boolean;
  database = 'menu';
  menuOpen: boolean;
  constructor(private location: Location, private auth: AuthenticationService, private configService: ConfigService) { }

  ngOnInit() {
    this.getMenu(this.database);
    this.menuOpen = false;
  //   $(document).ready(function() {
  //     /*Responsive Navigation*/
  //     $('#nav-mobile').html($('#nav-main').html());
  //     $('#nav-trigger span').on('click',function() {
  //       if ($('nav#nav-mobile ul').hasClass('expanded')) {
  //         $('nav#nav-mobile ul.expanded').removeClass('expanded').slideUp(250);
  //         $(this).removeClass('open');
  //       } else {
  //         $('nav#nav-mobile ul').addClass('expanded').slideDown(250);
  //         $(this).addClass('open');
  //       }
  //     });

  //     $('#nav-mobile').html($('#nav-main').html());
  //     $('#nav-mobile ul a').on('click',function() {
  //       if ($('nav#nav-mobile ul').hasClass('expanded')) {
  //         $('nav#nav-mobile ul.expanded').removeClass('expanded').slideUp(250);
  //         $('#nav-trigger span').removeClass('open');
  //       }
  //     });
  //   });
   }

  getMenu(database) {
    this.configService.getSettings(database).subscribe((settings) => {
      this.menu = settings;
    });
  }

  toggleMenu(state) {
    this.menuOpen = state;
  }

  logout() {
    this.auth.logout();
  }

}
