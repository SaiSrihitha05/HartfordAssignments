import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class User {
  private apiUrl = 'https://localhost:7157/api/User';
  private http=inject(HttpClient);

  // get all users data
  getAllAsync(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  // delete user
  deleteAsync(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
