import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})

export class Appointment {

  private http=inject(HttpClient);
  private apiUrl = 'https://localhost:7157/api/Appointment';

  // post appointmnet 
  create(data: any): Observable<any> {
  return this.http.post(`${this.apiUrl}`, data);
  }

  // get appointments spefic to doctor
  getMyAppointments(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/my-appointments`);
  }

  // get all appointments
  getAllAdmin(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/all`);
  }

  // update status of an appointment - by doctor only
  updateStatus(id: number, status: string): Observable<any> {
    return this.http.patch(`${this.apiUrl}/${id}/status`, { status });
  }
}
