import { LoginDetail } from './../../../shared/models/em-login-detail.model';
import { EmAuthorzationService } from './../../../shared/services/em-authorzation.service';
import { EmUserDataService } from './../../../shared/services/em-user-data.service';
import { EmLoginService } from './../../../shared/services/em-login.service';
import { EmSessionService } from './../../../shared/services/em-session.service';
import { Component, OnInit } from '@angular/core';
import { AppSelectorPageModel } from './app-selector.page.model';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Application } from 'src/app/shared/enum/em-application.enum';

@Component({
  selector: 'app-app-selector',
  templateUrl: './app-selector.component.html',
  styleUrls: ['./app-selector.component.css']
})
export class AppSelectorComponent implements OnInit {

  public pageModel: AppSelectorPageModel;
  public hasOfferManagerAccess: boolean;
  public hasEventManagerAccess: boolean;
  constructor(private router: Router, private emSessionService: EmSessionService, private emLoginService: EmLoginService,
              private cookieService: CookieService, private userDataService: EmUserDataService,
              private authorizationService: EmAuthorzationService) {
                this.pageModel = new AppSelectorPageModel();
                this.hasEventManagerAccess = false;
                this.hasOfferManagerAccess = false;
              }

  ngOnInit() {
    console.log('Inside App Selector');
    this.emSessionService.removeSessionApplicationName();
    this.emLoginService.setSession('Tesco_UK').subscribe(data => {
      this.emLoginService.getProfile().subscribe(data => {
        localStorage.setItem('mcUserData', JSON.stringify(data));
        localStorage.setItem('mcMarketData', JSON.stringify(data.market));
        localStorage.setItem('mcHelpData', JSON.stringify({
          site: data.helpSite,
          market: data.market
        }));
        this.emSessionService.beginLoginSession();
        this.userDataService.loadUserRoleAndLanguage().subscribe(() => {
          this.loadAppAccess();
          const loginDetail: LoginDetail = {
            logInFlag: true,
            setApplicationFlag: false
          };
          this.emSessionService.setLogIn(loginDetail);
        });
        this.cookieService.deleteAll();
      }, error => {
      });
    });
  }

  private loadAppAccess(): void {
    console.log('app selector component load add access');
    this.hasEventManagerAccess = this.authorizationService.checkApplicationAuthorization(Application.eventManager);
    this.hasOfferManagerAccess = this.authorizationService.checkApplicationAuthorization(Application.offerManager);
  }

  private loadApplication(applicationName: string) {
    this.emSessionService.setApplicationName(applicationName);
    console.log(applicationName);
    const loginDetail: LoginDetail = {
      logInFlag: true,
      setApplicationFlag: true
    };
    this.emSessionService.setLogIn(loginDetail);
    const moduleName = this.authorizationService.getFirstModuleTab(applicationName);
    console.log(moduleName);
    if (moduleName) {
      console.log('navigating to ' + applicationName + '/' + moduleName);
      this.router.navigate([applicationName + '/' + moduleName]);
    } else {
      this.router.navigate(['permission-denied']);
    }
  }

  onSelectOfferManager() {
    console.log(this.hasOfferManagerAccess);
    if (this.hasOfferManagerAccess) {
      this.loadApplication(Application.offerManager);
    }
  }

  onSelectEventManager() {
    if (this.hasEventManagerAccess) {
      this.loadApplication(Application.eventManager);
    }
  }

}
