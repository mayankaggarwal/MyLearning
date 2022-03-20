import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class BookstoreService {

  constructor(private http: HttpClient) { }

  create(bookstore : any){
    console.log(bookstore);
    return this.http.post('/api/bookstores',bookstore)
  }

  getBookstore(id:any){
    return this.http.get('/api/bookstores/' + id)
  }

  update(bookstore:any){
    return this.http.put('/api/bookstores/' + bookstore.id, bookstore)
  }

  delete(id:any){
    return this.http.delete('/api/bookstores/' + id)
  }

  getBookstores()
  {
    return this.http.get('/api/bookstores')
  }
}
