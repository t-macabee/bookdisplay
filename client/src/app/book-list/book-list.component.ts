import {Component, OnInit} from '@angular/core';
import {Book} from "../_models/book";
import {BooksService} from "../_services/books.service";
import {NgClass, NgForOf, NgOptimizedImage} from "@angular/common";
import {NgxPaginationModule} from "ngx-pagination";
import {FormsModule} from "@angular/forms";
import {MatDialog} from "@angular/material/dialog";
import {BookModalComponent} from "../book-modal/book-modal.component";
import {CommentModalComponent} from "../comment-modal/comment-modal.component";

@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [
    NgForOf,
    NgOptimizedImage,
    NgxPaginationModule,
    FormsModule,
    NgClass
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

  constructor(private bookService: BooksService, private dialog: MatDialog) { }

  ngOnInit() {
    this.getPage();
    this.getBooks();
    this.getLikes();
  }

  getPage() {
    if (typeof sessionStorage !== 'undefined') {
      const storedPage = sessionStorage.getItem('page');
      this.page = storedPage !== null ? +storedPage : 1;
    }
  }

  getBooks() {
    this.bookService.getAllBooks(this.page).subscribe(books => {
      this.books = books;
      this.filter = books;
      this.searchBooks();
    });
  }

  searchBooks() {
    this.filter = this.books.filter(book =>
      book.title.toLowerCase().includes(this.search.toLowerCase()));
  }

  like(book: Book) {
    this.bookService.likeBook(book.id).subscribe(result => {
      book.liked = result;
    });
  }


  getLikes() {
    this.books.forEach(book => {
      const liked = localStorage.getItem(`book_${book.id}`);
      if(liked) {
        book.liked = JSON.parse(liked);
      }
    })
  }

  bookDetails(book: Book) {
    const dialog = this.dialog.open(BookModalComponent, {
      height: '350px',
      width: '350px',
      data: {book: book}
    })
  }

  comments(book: Book) {
    const dialog = this.dialog.open(CommentModalComponent, {
      height: '600px',
      width: '500px',
      data: {book: book}
    })
  }

  onPageChange(page: number) {
    this.page = page;
    sessionStorage.setItem('page', this.page.toString());
  }
}
