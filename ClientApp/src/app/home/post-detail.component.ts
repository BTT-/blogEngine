import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PostsService } from './posts.service';
import { IPost } from './post';

@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.css']
})
export class PostDetailComponent implements OnInit {

  post: IPost;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private postsService: PostsService) { }

  ngOnInit() {
    let id = this.route.snapshot.paramMap.get('id');
    this.postsService.getPost(id).toPromise().then(p => this.post = p);
  }

  onBack(): void {
    this.router.navigate(['']);
  }

}
