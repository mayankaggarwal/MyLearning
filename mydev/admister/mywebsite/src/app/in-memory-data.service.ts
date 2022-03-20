import { Injectable } from '@angular/core';
import { InMemoryDbService, RequestInfo, ResponseOptions, STATUS } from 'angular-in-memory-web-api';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InMemoryDataService implements InMemoryDbService {
  createDb(reqInfo?: RequestInfo): {} | Observable<{}> | Promise<{}> {
    const users = [
      { id: 11, firstName: 'rahul', lastName: 'gupta', email: 'test123@gmail.com', password: 'Welcome'},
      { id: 12, firstName: 'rohan', lastName: 'gupta', email: 'test456@gmail.com', password: 'Welcome'},
    ];

    const  posts = [
      // tslint:disable-next-line: max-line-length
      {id: 1, title: 'The first Article', author: 'AD', publisheddate: '2012-03-19T07:22Z',
        excert: 'This is the summary of the article...', image: 'gallery-image-1.jpg'},
      {id: 2, title: 'The second Article', author: 'AD', publisheddate: '2012-03-19T07:22Z',
        excert: 'This is the summary of the article...', image: 'gallery-image-2.jpg'},
      {id: 3, title: 'The third Article', author: 'AD', publisheddate: '2012-03-19T07:22Z',
        excert: 'This is the summary of the article...', image: 'gallery-image-3.jpg'},
      {id: 4, title: 'The fourth Article', author: 'AD', publisheddate: '2012-03-19T07:22Z',
        excert: 'This is the summary of the article...', image: 'gallery-image-4.jpg'},
      {id: 5, title: 'The fifth Article', author: 'AD', publisheddate: '2012-03-19T07:22Z',
        excert: 'This is the summary of the article...', image: 'gallery-image-5.jpg'},
      {id: 6, title: 'The sixth Article', author: 'AD', publisheddate: '2012-03-19T07:22Z',
        excert: 'This is the summary of the article...', image: 'gallery-image-6.jpg'},
      {id: 7, title: 'The seventh Article', author: 'AD', publisheddate: '2012-03-19T07:22Z',
        excert: 'This is the summary of the article...', image: 'gallery-image-2.jpg'},
      {id: 8, title: 'The eighth Article', author: 'AD', publisheddate: '2012-03-19T07:22Z',
        excert: 'This is the summary of the article...', image: 'gallery-image-3.jpg'},
      {id: 9, title: 'The ninth Article', author: 'AD', publisheddate: '2012-03-19T07:22Z',
        excert: 'This is the summary of the article...', image: 'gallery-image-4.jpg'},
      {id: 10, title: 'The tenth Article', author: 'AD', publisheddate: '2012-03-19T07:22Z',
        excert: 'This is the summary of the article...', image: 'gallery-image-5.jpg'},
    ];

    const menu = [
      {id: 1, title: 'home', link: '/home'},
      {id: 2, title: 'about', link: '/about'},
      {id: 3, title: 'gallery', link: '/gallery'},
      {id: 4, title: 'services', link: '/services'},
      {id: 5, title: 'testimonials', link: '/testimonials'},
      {id: 6, title: 'clients', link: '/clients'},
      {id: 7, title: 'pricing', link: '/pricing'},
      {id: 8, title: 'blog', link: '/blog'},
    ];

    return {users, posts, menu};
  }

  constructor() { }

  getToken(user) {
    return 'this is a token';
  }

  post(reqInfo: RequestInfo) {
    if (reqInfo.id === 'login') {
      console.log('from login');

      return reqInfo.utils.createResponse$(() => {
        const dataEncapsulation = reqInfo.utils.getConfig().dataEncapsulation;
        const users = reqInfo.collection.find(user => {
          return reqInfo.req['body'].email === user.email && reqInfo.req['body'].password === user.password;
        });

        let responseBody = {};
        if (users) {
          responseBody = {
            id: users.id,
            firstName: users.firstName,
            lastName: users.lastName,
            email: users.email,
            token: this.getToken(users)
          };
        }

        const options: ResponseOptions = responseBody ?
        {
          body: dataEncapsulation ? { responseBody } : responseBody,
          status: STATUS.OK
        } :
        {
          body: { error: `'User' with email='${reqInfo.req['body'].email}' not found`},
          status: STATUS.NOT_FOUND
        };

        options.statusText = options.status === 200 ? 'ok' : 'Not Found';
        options.headers = reqInfo.headers;
        options.url = reqInfo.url;
        return options;
      });
    } else if (reqInfo.id === 'signup') {
      reqInfo.id = null;
      console.log(' from signup');
    }
  }

  get(reqInfo: RequestInfo) {
    console.log(reqInfo);
    if (reqInfo.collectionName === 'posts') {
      return this.getArticles(reqInfo);
    }

    return undefined;
}

getArticles(reqInfo: RequestInfo) {
  return reqInfo.utils.createResponse$(() => {
    const dataEncapsulation = reqInfo.utils.getConfig().dataEncapsulation;
    const collection = reqInfo.collection;
    const id = reqInfo.id;
    const data = id === undefined ? collection : reqInfo.utils.findById(collection, id);

    const options: ResponseOptions = data ?
    {
      body: dataEncapsulation ? { data } : data,
      status: STATUS.OK
    } :
    {
      body: { error: 'Post Not found'},
      status: STATUS.NOT_FOUND
    };

    options.statusText = options.status === 200 ? 'ok' : 'Not Found';
    options.headers = reqInfo.headers;
    options.url = reqInfo.url;
    return options;
});
}

}
