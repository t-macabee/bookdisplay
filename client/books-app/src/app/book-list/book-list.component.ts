import {Component, OnInit} from '@angular/core';
import {BookService} from "../_services/book-service.service";

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.scss'
})
export class BookListComponent implements OnInit {
  books: any[] = [];

  constructor(private bookService: BookService) {
  }

  ngOnInit(): void {
    this.getBooks();
  }

  getBooks() {
    this.bookService.getAllBooks().subscribe((books) => {
      this.books = books;
    })
  }
}
