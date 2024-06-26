import {Component, Inject, OnInit} from '@angular/core';
import {Book} from "../_models/book";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-book-modal',
  standalone: true,
  imports: [],
  templateUrl: './book-modal.component.html',
  styleUrl: './book-modal.component.scss'
})
export class BookModalComponent {
  book: Book;

  constructor(
    public dialogRef: MatDialogRef<BookModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) {
  this.book = data.book;
  }

  like(book: Book) {
    book.liked = !book.liked;
    if (book.liked) {
      localStorage.setItem(`book_${book.id}`, 'true');
    } else {
      localStorage.removeItem(`book_${book.id}`);
    }
  }

  close() {
    this.dialogRef.close();
  }

}
