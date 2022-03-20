import { Hero } from './../models/hero';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-herolist',
  templateUrl: './herolist.component.html',
  styleUrls: ['./herolist.component.css']
})
export class HerolistComponent implements OnInit {
  heroes= [
    new Hero(1,"Windstorm"),
    new Hero(2,"Bombasto"),
    new Hero(3,"Magneta"),
    new Hero(4,"Tornado")
  ];

  myHero = this.heroes[0];
  title = "Tour of Heroes";
  constructor() { }

  ngOnInit() {

  }

}
