import { Claim } from './em-claim.model';

export class AppRole {
    application: string;
    claims: Array<Claim>;
}