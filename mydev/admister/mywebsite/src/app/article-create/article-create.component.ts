import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { ConfigService } from '../config.service';
import { AuthenticationService } from '../authentication.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-article-create',
  templateUrl: './article-create.component.html',
  styleUrls: ['./article-create.component.css']
})
export class ArticleCreateComponent implements OnInit {

  postcreateForm: FormGroup;
  id: number;
  constructor(private fb: FormBuilder,
              private config: ConfigService,
              private auth: AuthenticationService,
              private route: ActivatedRoute,
              private router: Router,
              private location: Location) { }

  ngOnInit() {
    this.postcreateForm = this.fb.group({
      //'id' : [null, [Validators.required]],
      'title' : [null, Validators.required],
      'author' : [this.getAuthor(), Validators.required],
      'publisheddate' : [Date.now(), Validators.required],
      'excert' : [null, Validators.required],
      'image' : [null, Validators.required],
    });
  }

  createPost(formData: NgForm) {
    this.config.addPost(formData).subscribe((response) => {
      this.router.navigate([`article/${response.id}`]);
    });
  }

  getAuthor(): string {
    return this.auth.getUser()['id'];
  }

}
