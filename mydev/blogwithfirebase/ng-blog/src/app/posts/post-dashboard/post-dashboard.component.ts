import { Observable } from 'rxjs';
import { PostService } from './../post.service';
import { AuthService } from './../../core/auth.service';
import { Component, OnInit } from '@angular/core';
import { AngularFireStorage } from '@angular/fire/storage';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-post-dashboard',
  templateUrl: './post-dashboard.component.html',
  styleUrls: ['./post-dashboard.component.css']
})
export class PostDashboardComponent implements OnInit {

  title: string
  image: string = null
  content: string;

  buttonText: string = 'Create Post'

  uploadPercent: Observable<number>
  downloadURL: Observable<string>
  constructor(private auth: AuthService, private postService: PostService, private storage: AngularFireStorage) { }

  ngOnInit() {
  }

  createPost() {
    const data = {
      author: this.auth.authState.displayName || this.auth.authState.email,
      authorId: this.auth.currentUserId,
      content: this.content,
      image: this.image,
      published: new Date(),
      title: this.title
    };

    this.postService.create(data);
    this.title = '';
    this.content = '';
    this.buttonText = 'Post Created';
    setTimeout(() => {this.buttonText = "Create Post"}, 3000)
  }

  uploadImage(event) {
    const file = event.target.files[0]
    const path = `posts/${file.name}`
    if(file.type.split('/')[0] !== 'image') {
      return alert('only image files');
    } else {
      const fileRef = this.storage.ref(path);
      const task = this.storage.upload(path, file);
      this.uploadPercent = task.percentageChanges();
      task.snapshotChanges().pipe(
        finalize(() => {
          this.downloadURL = fileRef.getDownloadURL()
          this.downloadURL.subscribe(url => this.image = url);
        } )
     )
    .subscribe()
      
    }
  }

}
