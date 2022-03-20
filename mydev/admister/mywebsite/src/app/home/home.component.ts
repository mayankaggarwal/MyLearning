import { ConfigService } from './../config.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  header = {};
  constructor(private config: ConfigService) { }

  ngOnInit() {
    this.header = this.getHeader();
  }

  getHeader() {
    return this.config.getConfig().header;
  }
}
