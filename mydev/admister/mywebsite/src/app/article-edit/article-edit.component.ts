import { Location } from '@angular/common';
import { ConfigService } from './../config.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { AuthenticationService } from '../authentication.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-article-edit',
  templateUrl: './article-edit.component.html',
  styleUrls: ['./article-edit.component.css']
})
export class ArticleEditComponent implements OnInit {

  posteditForm: FormGroup;
  id: number;
  constructor(private fb: FormBuilder,
              private config: ConfigService,
              private auth: AuthenticationService,
              private route: ActivatedRoute,
              private router: Router,
              private location: Location) { }

  ngOnInit() {
    this.posteditForm = this.fb.group({
      'id' : [null, [Validators.required]],
      'title' : [null, Validators.required],
      'author' : [null, Validators.required],
      'publisheddate' : [null, Validators.required],
      'excert' : [null, Validators.required],
      'image' : [null, Validators.required],
    });

    this.id = this.route.snapshot.params['id'] || null;
    if (this.id) {
      this.getPostById(this.id);
    }
  }

  getPostById(id: number) {
    this.config.getPostById(id).subscribe((post) => {
      console.log(post);
      this.posteditForm.setValue({
        id: post.id,
        title: post.title,
        author: post.author,
        excert: post.excert,
        publisheddate: post.publisheddate,
        image: post.image
      });
    });
  }

  updatePost(formData: NgForm) {
    this.config.updatePosts(formData).subscribe((response) => {
      this.location.back();
    });
  }

}
