import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { Appointment } from '../../../services/appointment';
import { Doctor } from '../../../services/doctor';
import { inject } from '@angular/core';

@Component({
  selector: 'app-book-appointment',
  imports: [FormsModule,CommonModule],
  templateUrl: './book-appointment.html',
  styleUrl: './book-appointment.css',
})
export class BookAppointment {
  //variables
  doctors: any[] = [];
  appointmentData = {
    doctorId: 0,
    appointmentDate: '',
    status: 'Scheduled'
  };
  errorMessage = '';

  //DI
  private appointmentService=inject(Appointment);
  private doctorService=inject(Doctor);
  private router=inject(Router);

  // Fetch all doctors 
  ngOnInit(): void {
    this.doctorService.getAll().subscribe({
      next: (res) => this.doctors = res,
      error: (err) => this.errorMessage = 'Could not load doctors.'
    });
  }


  //to book an appointment sending data ot the backend
  onBook() {
    const payload = {
      DoctorId: Number(this.appointmentData.doctorId), 
      PatientId: 0, 
      AppointmentDate: this.appointmentData.appointmentDate, 
      Status: "Scheduled" 
    };

    this.appointmentService.create(payload).subscribe({
      next: () => {
        alert('Appointment booked successfully!');
        this.router.navigate(['/patient/dashboard']);
      },
      error: (err) => {
        console.error(err);
        this.errorMessage = err.error?.message || 'Check if your profile is complete.';
      }
    });
  } 
}
