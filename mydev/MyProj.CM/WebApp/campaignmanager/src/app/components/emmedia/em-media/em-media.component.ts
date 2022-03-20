import { EmSessionService } from './../../../shared/services/em-session.service';
import { EmAuthorzationService } from './../../../shared/services/em-authorzation.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ApplicationModule } from './../../../shared/enum/em-application-module.enum';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-em-media',
  templateUrl: './em-media.component.html',
  styleUrls: ['./em-media.component.css']
})
export class EmMediaComponent implements OnInit {

  constructor(private router: Router, private route: ActivatedRoute, private authorizationService: EmAuthorzationService,
              private sessionService: EmSessionService) { }

  public applicationModule = ApplicationModule;
  public currentTab: { 'name': string} = {'name': ''};

  ngOnInit() {
    console.log('EmMediaComponent');
    const applicationName = this.sessionService.getApplicationName();
    const moduleName = this.authorizationService.getFirstModuleTab(applicationName);
    if (applicationName && moduleName && !(this.route && this.route.children && this.route.children.length > 0)) {
      this.router.navigate([moduleName], {relativeTo: this.route});
    }
  }

}
