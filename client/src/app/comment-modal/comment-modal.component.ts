import {Component, Inject, OnInit} from '@angular/core';
import { CommonModule } from '@angular/common';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {Book} from "../_models/book";
import {FormsModule} from "@angular/forms";
import {BooksService} from "../_services/books.service";

@Component({
  selector: 'app-comment-modal',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './comment-modal.component.html',
  styleUrl: './comment-modal.component.scss'
})
export class CommentModalComponent implements OnInit{
  book: Book;
  newComment: any;

  constructor(
    public dialogRef: MatDialogRef<CommentModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private service: BooksService
  ) {
    this.book = data.book;
  }

  addComment(content: string) {
    this.service.addComment(this.book.id, content).subscribe({
      next: (result: any) => {
        if (!this.book.comments) {
          this.book.comments = [];
        }
        this.book.comments.push(result);
      }
    });
  }

  ngOnInit(): void {

  }

  closeDialog() {
    this.dialogRef.close();
  }



}
