import { Post } from './Post';
import { Observable, of } from 'rxjs';
import { configuration } from './configuration';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { tap, catchError } from 'rxjs/operators';
import { NgForm } from '@angular/forms';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};
@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  apiUrl = 'api/posts';
  config = configuration;
  constructor(private http: HttpClient) { }

  getConfig() {
    return this.config;
  }

  getPosts(): Observable<Post[]> {
    return this.http.get<any>(this.apiUrl).pipe(
      tap(
        post =>{ console.log(post); }
        , catchError(this.handleError('getPosts', []))
      )
    );

  }

  updatePosts(formData: NgForm): Observable<Post> {
    return this.http.put<any>(`${this.apiUrl}`, formData, httpOptions).pipe(
      tap(
        post =>{ console.log(post); }
        , catchError(this.handleError('updatePost', []))
      )
    );

  }

  addPost(formData: NgForm): Observable<Post> {
    return this.http.post<any>(`${this.apiUrl}`, formData, httpOptions).pipe(
      tap(
        post =>{ console.log(post); }
        , catchError(this.handleError('Add New Post', []))
      )
    );

  }

  getPostById(id: number): Observable<Post> {
    return this.http.get<any>(`${this.apiUrl}/${id}`).pipe(
      tap(
        post =>{ console.log(post); }
        , catchError(this.handleError('getPostById', []))
      )
    );

  }

  getSettings(database: string, id?: string): Observable<any[]> {
    const uid = id || null;
    let url: string;
    uid !== null ? url = `api/${database}/${id}` : url = `api/${database}`;
    console.log(url);
    return this.http.get<any[]>(url).pipe(
      tap(
        setting =>{ console.log(setting); }
        , catchError(this.handleError('getSettings', []))
      )
    );

  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);

      console.log(`${operation} failed: ${error.message}`);

      return of(result as T);
    };
  }
}
