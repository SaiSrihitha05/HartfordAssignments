import { HttpClient } from '@angular/common/http';
import { Injectable,inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Todoservice {
  private http = inject(HttpClient);
  getPosts(){
    return this.http.get<any[]>("http://localhost:3000/posts")
  }
  getPostById(id:number){
    return this.http.get<any>(`http://localhost:3000/posts/${id}`)
  }
  postUser(user:any){
    return this.http.post<any>("http://localhost:3000/posts",user)
  }
  updateUser(user:any,id:number){
    return this.http.put<any>(`http://localhost:3000/posts/${id}`,user)
  }
  deleteUser(id:number){
    return this.http.delete(`http://localhost:3000/posts/${id}`)
  }
}
