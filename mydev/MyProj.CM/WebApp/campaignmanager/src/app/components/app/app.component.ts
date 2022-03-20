import { LoginDetail } from './../../shared/models/em-login-detail.model';
import { environment } from './../../../environments/environment.prod';
import { EmAuthorzationService } from './../../shared/services/em-authorzation.service';
import { Router, NavigationStart, NavigationEnd } from '@angular/router';
import { EmSessionService } from './../../shared/services/em-session.service';
import { Component, OnInit, HostListener } from '@angular/core';
import { Location, PopStateEvent } from '@angular/common';
import { Application } from 'src/app/shared/enum/em-application.enum';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'campaignmanager';
  public pageModel: AppComponentPageModel;
  private lastPoppedUrl: string;
  private yScrollStack: number[] = [];
  showMenu: false;
  public applicationName: string;
  public hasOfferManagerAccess = false;
  public hasEventManagerAccess = false;
  public opensidebar = false;
  public regex = new RegExp('^[<>/\\\\`&]+$');

  constructor(private emSessionService: EmSessionService, private router: Router, private location: Location,
              private authorizationService: EmAuthorzationService) {
                this.pageModel = new AppComponentPageModel();

    }
  ngOnInit() {
    console.log('Inside App Component');
    let marketCode = (new URL(document.location.toString())).searchParams.get('marketcode');
    if (marketCode === null) {
      marketCode = environment.defaultMarketCode;
    }

    localStorage.setItem('mcMarketSelection', marketCode);
    this.showMenu = false;
    this.opensidebar = false;
    this.emSessionService.isLoggedInObservable().subscribe(loginDetail => {
      if (loginDetail.logInFlag) {
        this.loadAppAccess();
      }

      if (loginDetail.setApplicationFlag) {
        this.applicationName = this.emSessionService.getApplicationName();
      }
    });

    this.location.subscribe((ev: PopStateEvent) => {
      this.lastPoppedUrl = ev.url;
    });
    this.router.events.subscribe((ev: any) => {
      if (ev instanceof NavigationStart) {
        if (ev.url !== this.lastPoppedUrl) {
          this.yScrollStack.push(window.scrollY);
        }
      } else if (ev instanceof NavigationEnd) {
        if (ev.url === this.lastPoppedUrl) {
          this.lastPoppedUrl = undefined;
          window.scrollTo(0, this.yScrollStack.pop());
        } else {
          window.scrollTo(0, 0);
        }
      }
    });

    console.log(this.applicationName);
  }

  @HostListener('document:keypress', ['$event'])
  blockCharacterInout(event: KeyboardEvent) {
    if (event && event.key) {
      const key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
      if (this.regex.test(key)) {
        event.preventDefault();
      }
    }
  }

  @HostListener('document:paste', ['$event'])
  blockPaste(e: ClipboardEvent) {
    const copiedCode = e.clipboardData.getData('Text');
    const regex = /[<>/`&]/g;
    const res = copiedCode.match(regex);
    if (res && res.length > 0) {
      e.preventDefault();
    }
  }

  private loadAppAccess(): void {
    console.log('app component load add access');
    this.hasOfferManagerAccess = this.authorizationService.checkApplicationAuthorization(Application.offerManager);
    this.hasEventManagerAccess = this.authorizationService.checkApplicationAuthorization(Application.eventManager);
  }

  public openSideBarMenu() {
    this.applicationName = this.emSessionService.getApplicationName();
    this.opensidebar = !this.opensidebar;
  }

  private loadApplication(applicationName: string) {
    this.emSessionService.setApplicationName(applicationName);
    const logindetail: LoginDetail = {
      logInFlag: true,
      setApplicationFlag: true
    };

    this.emSessionService.setLogIn(logindetail);
    const moduleName = this.authorizationService.getFirstModuleTab(applicationName);
    if (moduleName) {
      this.router.navigate([applicationName + '/' + moduleName]);
    } else {
      this.router.navigate(['permission-denied']);
    }

    this.opensidebar = !this.opensidebar;
  }

  onSelectOfferManager() {
    if (this.hasOfferManagerAccess) {
      this.loadApplication(Application.offerManager);
      this.applicationName = this.emSessionService.getApplicationName();
    }
  }

  onSelectEventManager() {
    if (this.hasEventManagerAccess) {
      this.loadApplication(Application.eventManager);
      this.applicationName = this.emSessionService.getApplicationName();
    }
  }
}

export class AppComponentPageModel {
  public close = 'CLOSE';
  public TermsAndCondition1 = 'By clicking any of the above products, you agree to the associated ';
    public TermsAndCondition2 = 'Privacy Policy';
    public TermsAndCondition3 = ' and ';
    public TermsAndCondition4 = 'Terms and Condition.';
    public CookiePolicy = 'Cookie Policy.';
    public CookiePolicyDesc1 = 'The website uses cookies for analytics, performance and functionality purposes.';
    public CookiePolicyLinkClick = 'Click Here ';
    public CookiePolicyDesc2 = 'to learn more or change your cookie settings. By continuing to browse, you agree to our use of cookies.';
    public eventManager = 'Event Manager';
    public offerManager = 'Offer Manager';
}
