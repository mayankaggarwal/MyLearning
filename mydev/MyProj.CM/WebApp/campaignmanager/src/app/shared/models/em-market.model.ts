import { Injectable } from '@angular/core';
import { Language } from './em-language.model';

@Injectable()
export class Market {
    marketName: string;
    marketCode: string;
    markets: object;
    returnMarketCode: number;
    primaryLanguage: Language;
    secondaryLanguage: Language;
}