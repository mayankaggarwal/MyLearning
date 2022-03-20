import { Injectable } from '@angular/core';
import { Market } from './em-market.model';
import { Language } from './em-language.model';
import { AppRole } from './em-app-role.model';

@Injectable()
export class GlobalSession {
    constructor(private marketDetails: Market) {
        this.market = marketDetails;
        this.authorization = { pending: true, authorized: false };
        this.helpConstants = {
            product: 'event_manager',
            version: '0.1.0',
            languageCode: 'en-GB'
        };
        this.user = new User();
        this.help = new Help();
    }

    market: Market;
    currentPermissionSet: any = null;
    currentPermissionPromise: any = null;
    authorization: IAuthorization;
    locale: Locale;
    user: User;
    help: Help;
    helpConstants: any;
    applicationName: string;
}

export class User {
    fullName: string;
    email: string;
    accountId: number;
    isTermNotAccepted: boolean;
    preferredLanguageId: number;
    preferredLanguage: Language;
    appRoles: Array<AppRole>;
    isSupplier: boolean;

}

export class Help {
    site: string;
    market: string;
}

export class Locale {
    constructor(public country: string, public currency: string, public language: string) {}

    getCulture(): string {
        return this.language;
    }
}

export interface IAuthorization {
    pending: boolean;
    authorized: boolean;
}

