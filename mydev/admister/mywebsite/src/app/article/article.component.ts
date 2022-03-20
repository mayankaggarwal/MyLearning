import { Post } from './../Post';
import { ConfigService } from './../config.service';
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent implements OnInit {
  post: Post;
  constructor(private route: ActivatedRoute, private config: ConfigService,private loc: Location) { }

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.getPostByID(id);
  }

  getPostByID(id: number) {
    return this.config.getPostById(id).subscribe((post) => {
      this.post = post;
    });
  }

  getBack() {
    this.loc.back();
  }
}
