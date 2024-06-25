import {Component, OnInit} from '@angular/core';
import {Book} from "../_models/book";
import {BooksService} from "../_services/books.service";
import {NgForOf, NgOptimizedImage} from "@angular/common";

@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [
    NgForOf,
    NgOptimizedImage
  ],
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.scss'
})
export class BookListComponent implements OnInit {
  books: Book[] = [];

  constructor(private bookService: BooksService) { }

  ngOnInit() {
        this.getBooks();
  }

  getBooks() {
    this.bookService.getAllBooks().subscribe(books => this.books = books);
  }
}
