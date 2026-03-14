import { Component } from '@angular/core';
import { Patient } from '../../../services/patient';
import { CommonModule, DatePipe } from '@angular/common';
import { inject } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-my-appointments',
  imports: [FormsModule,DatePipe,CommonModule],
  templateUrl: './my-appointments.html',
  styleUrl: './my-appointments.css',
})

export class MyAppointments {
  //variables
  appointments: any[] = [];
  isLoading = true;

  //DI
  private patientService=inject(Patient);

  ngOnInit(): void {
    this.loadAppointments();
  }

  //get all appointments of the logged in patient
  loadAppointments(): void {
    this.patientService.getMyAppointments().subscribe({
      next: (data) => {
        this.appointments = data;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error loading patient appointments:', err);
        this.isLoading = false;
      }
    });
  }
}
