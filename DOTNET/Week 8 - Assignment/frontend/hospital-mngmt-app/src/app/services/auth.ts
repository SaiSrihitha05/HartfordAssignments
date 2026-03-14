import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthResponse } from '../models/auth-response';
import { tap } from 'rxjs';
import { Observable } from 'rxjs';
import { inject } from '@angular/core';

@Injectable({ 
  providedIn: 'root' 
})

export class Auth {

  private apiUrl = 'https://localhost:7157/api/Auth'; 
  private http=inject(HttpClient);

  // login service - sets token in local storage
  login(credentials: any) {
    return this.http.post<AuthResponse>(`${this.apiUrl}/login`, credentials).pipe(
      tap(res => {
        localStorage.setItem('token', res.token);
        localStorage.setItem('role', res.role);
      })
    );
  }

  getToken() { 
    return localStorage.getItem('token'); 
  }

  // clear token from local storage in order to logout
  logout() { 
    localStorage.clear(); 
  }

  // check if the user is logged in
  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  // get the role from localstorage(key value pair)
  getRole(): string | null {
    return localStorage.getItem('role');
  }

  // register service - post req
  register(user: any) {
    return this.http.post(`${this.apiUrl}/register`, user);
  }

  // get captcha from backend - get req
  getCaptcha(): Observable<{ captchaCode: string }> {
    return this.http.get<{ captchaCode: string }>(`${this.apiUrl}/get-captcha`);
  } 

  // to generate token in backend inorder to reset password 
  forgotPassword(email: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/forgot-password`, { email }); 
  }

  // To actually change the password using the token
  resetPassword(resetData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/reset-password`, resetData); //
  }
}