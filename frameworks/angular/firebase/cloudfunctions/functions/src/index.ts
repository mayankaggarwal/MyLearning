import * as functions from 'firebase-functions';
//import { urlMetadata } from 'url-metadata';
import urlMetadata = require("../node_modules/url-metadata")
// // Start writing Firebase Functions
// // https://firebase.google.com/docs/functions/typescript
//
export const helloWorld = functions.https.onRequest((request, response) => {
    const url:any = request.query.text;
    const valueBase64 = decodeURI(url);
    urlMetadata(valueBase64).then(
        (resp:any) => {
           response.send(resp);
        },
        (error:any) => {
           response.send(error).status(500);
        }
     );
});