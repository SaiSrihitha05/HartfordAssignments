import { Component, inject, OnInit } from '@angular/core';
import { Todoservice } from '../../services/todoservice';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Observable, BehaviorSubject, switchMap } from 'rxjs';

@Component({
  selector: 'app-list-posts',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './list-posts.html',
  styleUrl: './list-posts.css',
})
export class ListPosts implements OnInit {
  private postsService = inject(Todoservice);
  private refreshPostsSubject = new BehaviorSubject<void>(undefined);
  
  posts$: Observable<any[]> = this.refreshPostsSubject.pipe(
    switchMap(() => this.postsService.getPosts())
  );
  
  singlePost$!: Observable<any>;
  user = { title: '', description: '' };
  isEdit = false;
  editId!: number;

  ngOnInit() {
    this.singlePost$ = this.postsService.getPostById(2);
  }

  addUser() {
    if (!this.user.title || !this.user.description) return;

    const action = this.isEdit 
      ? this.postsService.updateUser(this.user, this.editId)
      : this.postsService.postUser(this.user);

    action.subscribe(() => {
      this.refreshData();
      this.resetForm();
    });
  }

  updateUser(post: any) {
    this.user = { ...post };
    this.editId = post.id;
    this.isEdit = true;
  }

  deleteUser(id: number) {
    this.postsService.deleteUser(id).subscribe(() => this.refreshData());
  }

  private refreshData() {
    this.refreshPostsSubject.next(); 
  }

  resetForm() {
    this.user = { title: '', description: '' };
    this.isEdit = false;
  }
}