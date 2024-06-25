import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Book} from "../_models/book";

@Injectable({
  providedIn: 'root'
})
export class BooksService {
  private apiUrl = 'https://freetestapi.com/api/v1/books';

  constructor(private http: HttpClient) { }

  getAllBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.apiUrl);
  }
}
