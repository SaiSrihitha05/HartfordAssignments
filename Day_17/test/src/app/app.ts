import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ListPosts } from '../components/list-posts/list-posts';

@Component({
  selector: 'app-root',
  imports: [ListPosts],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('test');
}
