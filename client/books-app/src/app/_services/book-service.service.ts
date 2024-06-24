import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class BookService {

  private apiUrl = 'https://freetestapi.com/api/v1/books';

  constructor(private http: HttpClient) { }

  getAllBooks(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
}
