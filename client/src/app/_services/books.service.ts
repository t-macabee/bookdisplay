import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {map, Observable} from "rxjs";
import {Book} from "../_models/book";


@Injectable({
  providedIn: 'root'
})
export class BooksService {
  private apiUrl = 'https://localhost:5001/Books/';

  constructor(private http: HttpClient) { }

  getAllBooks(page: number): Observable<Book[]> {
    const params = new HttpParams()
      .set('page', page.toString());

    const options = {
      headers: new HttpHeaders({'Content-Type': 'application/json'}),
      params: params,
      withCredentials: true
    };

    return this.http.get<Book[]>(this.apiUrl, options);
  }

  addComment(id: number, content: string) {
    const params = new HttpParams().set('comment', content);
    return this.http.post(`${this.apiUrl}${id}/comment`, null, { params });
  }

  likeBook(id: number): Observable<boolean> {
    return this.http.post<boolean>(`${this.apiUrl}${id}/like`, null);
  }
}
