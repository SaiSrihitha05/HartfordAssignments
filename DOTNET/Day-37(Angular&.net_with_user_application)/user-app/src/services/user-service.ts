import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface User {
  userId?: number;
  username:string,
  emailId:string,
  dateOfBirth: string;
  address: string;
  age?: number;  
}

@Injectable({
  providedIn: 'root',
})

export class UserService {
  private apiUrl = 'https://localhost:7189/api/Users';

  constructor(private http: HttpClient) { }

  // GET all users
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl);
  }

  // POST new user
  addUser(user: User): Observable<User> {
    return this.http.post<User>(this.apiUrl, user);
  }
}
