import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Patient {
  private apiUrl = 'https://localhost:7157/api/Patient'; 
  private http=inject(HttpClient);

  // POST: api/Patient/complete-profile - to post the updated detailed of patient
  completeProfile(profileData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/complete-profile`, profileData, {
      responseType: 'text'
    });
  }

  // GET: api/Patient/my-profile - to get the profile data of a patient
  getMyProfile(): Observable<any> {
    return this.http.get(`${this.apiUrl}/my-profile`);
  }

  // GET: api/Patient/my-appointments - to get all the appointments specific to the logged in patient
  getMyAppointments(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/my-appointments`);
  }
}
