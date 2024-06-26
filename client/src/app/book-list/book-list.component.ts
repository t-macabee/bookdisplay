import {Component, OnInit} from '@angular/core';
import {Book} from "../_models/book";
import {BooksService} from "../_services/books.service";
import {NgForOf, NgOptimizedImage} from "@angular/common";
import {NgxPaginationModule} from "ngx-pagination";
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [
    NgForOf,
    NgOptimizedImage,
    NgxPaginationModule,
    FormsModule
  ],
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.scss'
})
export class BookListComponent implements OnInit {
  books: Book[] = [];
  filter: Book[] = [];
  search: string = '';
  page: number = 1;
  pageSize: number = 9;

  constructor(private bookService: BooksService) { }

  ngOnInit() {
        this.getBooks();
  }

  getBooks() {
    this.bookService.getAllBooks().subscribe(books => {
      this.books = books;
      this.filter = books;
    });
  }

  searchBooks() {
    this.filter = this.books.filter(book => book.title.toLowerCase().includes(this.search.toLowerCase()));
    this.page = 1;
  }
}
