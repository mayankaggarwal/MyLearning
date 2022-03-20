import { Component, OnInit } from '@angular/core';
import { ConfigService } from '../config.service';

@Component({
  selector: 'app-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.css']
})
export class ServicesComponent implements OnInit {

  services = {};
  constructor(private config: ConfigService) { }

  ngOnInit() {
    this.services = this.getServices();
  }

  getServices() {
    return this.config.getConfig().services;
  }

}
