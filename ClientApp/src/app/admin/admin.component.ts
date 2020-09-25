import { Component, OnInit } from '@angular/core';
import { PostsService } from '../home/posts.service';
import { IPost } from '../home/post';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  posts: IPost[];

  constructor(private postsService: PostsService) { }

  ngOnInit() {
    this.postsService.getPosts().toPromise().then(posts => this.posts = posts);
  }

}
