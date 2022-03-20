import { Language } from './em-language.model';
export interface IMarketField {
    $id: string;
    id: number;
    name: string;
    supportPhone: string;
    code: string;
    countryCode: string;
    currencyCode: string;
    helpUser: string;
    helpPassword: string;
    helpMarket?: any;
    marketId: string;
    cultureCode: string;
    primaryLanguage: Language;
    secondaryLanguage: Language;
}