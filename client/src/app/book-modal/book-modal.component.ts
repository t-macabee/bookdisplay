import {Component, Inject, OnInit} from '@angular/core';
import {Book} from "../_models/book";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {BooksService} from "../_services/books.service";

@Component({
  selector: 'app-book-modal',
  standalone: true,
  imports: [],
  templateUrl: './book-modal.component.html',
  styleUrl: './book-modal.component.scss'
})
export class BookModalComponent implements OnInit{
  book: Book;

  constructor(
    public dialogRef: MatDialogRef<BookModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private service: BooksService
  ) {
  this.book = data.book;
  }

  ngOnInit(): void {
  }

  like(book: Book) {
    this.service.likeBook(book.id).subscribe(result => {
      book.liked = result;
    });
  }

  close() {
    this.dialogRef.close();
  }

}
