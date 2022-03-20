import { DhMessageType } from './../../shared/enum/dh-message-type.enum';
import { EmSessionService } from './../../shared/services/em-session.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-em-dashboard',
  templateUrl: './em-dashboard.component.html',
  styleUrls: ['./em-dashboard.component.css']
})
export class EmDashboardComponent implements OnInit {

  loadingEventTypes: boolean = true;
  public messageType = DhMessageType;
  constructor(private emSessionService: EmSessionService) {
    this.emSessionService.setRoute("Dashboard");
   }

  ngOnInit() {
  }

}
