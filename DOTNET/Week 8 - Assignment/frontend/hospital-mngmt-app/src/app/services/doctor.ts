import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})

export class Doctor {
  private apiUrl = 'https://localhost:7157/api/Doctor';
  private http=inject(HttpClient);

  // get all the doctors data
  getAll(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  // get the complete info of doctor
  getMyProfile(): Observable<any> {
    return this.http.get(`${this.apiUrl}/my-profile`);
  }

  // post the details of doctor
  completeProfile(data: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/complete-profile`, data, { responseType: 'text' });
  }

  // get all the appointments of logged in doctor
  getMyAppointments(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/my-appointments`);
  }

  // delete doctor - by admin only
  deleteAsync(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  // update the status of appointment
  updateAppointmentStatus(id: number, appointment: any): Observable<any> {
    const url = `https://localhost:7157/api/Appointment/${id}`;
    const obj = {
      doctorId: appointment.doctorId,
      patientId: appointment.patientId,
      appointmentDate: appointment.appointmentDate,
      status: appointment.status
    };
    console.log("Sending DTO:", obj);
    return this.http.put(url, obj);
  }
}
