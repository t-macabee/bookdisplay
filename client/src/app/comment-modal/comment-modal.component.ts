import {Component, Inject, OnInit} from '@angular/core';
import { CommonModule } from '@angular/common';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {Book} from "../_models/book";
import {FormsModule} from "@angular/forms";

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
  comment: string = '';

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: { book: Book },
    public dialogRef: MatDialogRef<CommentModalComponent>
  ) {}

  ngOnInit() {
    this.loadData();
  }

 loadData() {
   const stored = localStorage.getItem(`book_${this.data.book.id}`);
   if (stored) {
     this.data.book = JSON.parse(stored);
   }
 }

 add() {
    if (this.comment.trim() !== '') {
      this.data.book.comments = this.data.book.comments || []; // Initialize comments if undefined
      this.data.book.comments.push(this.comment.trim());
      this.save();
      this.comment = '';
    }
  }

  save() {
    localStorage.setItem(`book_${this.data.book.id}`, JSON.stringify(this.data.book));
  }

  closeDialog() {
    this.dialogRef.close();
  }
}
