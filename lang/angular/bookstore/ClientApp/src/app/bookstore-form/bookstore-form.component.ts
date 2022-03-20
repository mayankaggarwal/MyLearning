import { BookstoreService } from './../services/bookstore.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-bookstore-form',
  templateUrl: './bookstore-form.component.html',
  styleUrls: ['./bookstore-form.component.css']
})
export class BookstoreFormComponent implements OnInit {

  bookstore:any = {
    id : 0,
  };
  id:any;
  name: any;
  title: any;
  authorName:any;
  publisherName: any;

  constructor(private route: ActivatedRoute,
    private router:Router,
    private bookstoreService: BookstoreService) {
      route.params.subscribe(p => {
        this.bookstore.id = +p['id'];
        if(isNaN(this.bookstore.id)){
          this.bookstore.id = 0;
        }
      }, err => {
        if(err.status == 404) {
          this.router.navigate(['/bookstore']);
        }
      });
     }

  ngOnInit() {
    this.bookstoreService.getBookstore(this.bookstore.id)
    .subscribe(b => {
      this.bookstore = b;
    })
  }

  submit(){
    if(this.bookstore.id && this.bookstore.id != 0)
    {
      this.bookstoreService.update(this.bookstore)
        .subscribe( x => 
          {
            console.log(x),
            this.router.navigate(['/bookstore'])
          });
    }
    else{
      this.bookstoreService.create(this.bookstore)
        .subscribe( x => 
          {
            console.log(x),
            this.router.navigate(['/bookstore'])
          });
    }
  }

  delete(){
    if(confirm("Are you sure?")){
      this.bookstoreService.delete(this.bookstore.id)
        .subscribe(x => {
          console.log(x),
          this.router.navigate(['/bookstore'])
        });
    }
  }
}
