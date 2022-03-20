export class EmCustomEvents {
    public static readonly evtReloadPageModel: string = 'reloadPageModel';
    public static readonly evtDocumentReloadPageModel: string = `document:${EmCustomEvents.evtReloadPageModel}`;
}