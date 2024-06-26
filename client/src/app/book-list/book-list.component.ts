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
    if (typeof sessionStorage !== 'undefined') {
      const storedPage = sessionStorage.getItem('page');
      this.page = +(storedPage ?? '1');
    }
    this.getBooks();
    this.getLikes();
  }

  getBooks() {
    this.bookService.getAllBooks().subscribe(books => {
      this.books = books;
      this.filter = books;
    });
  }

  addFilter() {
    this.filter = this.books.filter(book =>
      book.title.toLowerCase().includes(this.search.toLowerCase()));
  }

  searchBooks() {
    this.addFilter();
  }

  like(book: Book) {
    book.liked = !book.liked
    if(book.liked) {
      localStorage.setItem(`book_${book.id}`, 'true');
    }
    else {
      localStorage.removeItem(`book_${book.id}`);
    }
  }

  getLikes() {
    this.books.forEach(book => {
      const liked = localStorage.getItem(`book_${book.id}`);
      if(liked) {
        book.liked = JSON.parse(liked);
      }
    })
  }

  onPageChange(page: number) {
    this.page = page;
    sessionStorage.setItem('page', this.page.toString());
  }
}
