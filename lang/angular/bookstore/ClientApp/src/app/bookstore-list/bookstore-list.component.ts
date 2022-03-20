import { BookstoreService } from './../services/bookstore.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bookstore-list',
  templateUrl: './bookstore-list.component.html',
  styleUrls: ['./bookstore-list.component.css']
})
export class BookstoreListComponent implements OnInit {

  bookstores: any[];
  constructor(private bookstoreService:BookstoreService) { }

  ngOnInit() {
    this.bookstoreService.getBookstores()
      .subscribe((bookstores:any[]) => this.bookstores = bookstores);
  }

}
