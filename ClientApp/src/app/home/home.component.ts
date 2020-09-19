import { Component, OnInit } from '@angular/core';
import { PostsService } from './posts.service';

import { IPost } from './post'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  posts: IPost[] = [];
  errorMessage: string;

  constructor(private postsService: PostsService) { }

  ngOnInit(): void {
    //this.postsService.getPosts().toPromise().then(data => this.posts = data);
    this.postsService.getPosts().subscribe({
      next: posts => {
      this.posts = posts;
      },
      error: err => this.errorMessage = err
    });
  }

}
