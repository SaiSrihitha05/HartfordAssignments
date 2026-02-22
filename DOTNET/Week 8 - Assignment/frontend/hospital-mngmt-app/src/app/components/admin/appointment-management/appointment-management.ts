import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Appointment } from '../../../services/appointment';
import { inject } from '@angular/core';

@Component({
  selector: 'app-appointment-management',
  imports: [CommonModule],
  templateUrl: './appointment-management.html',
  styleUrl: './appointment-management.css',
})
export class AppointmentManagement {
  //variables
  allAppointments: any[] = [];
  isLoading = true;

  //DI
  private appointmentService= inject(Appointment);

  //oninit
  ngOnInit(): void {
    this.loadAllAppointments();
  }

  //method to load all appointmnets
  loadAllAppointments() {
    this.appointmentService.getAllAdmin().subscribe({
      next: (res) => {
        this.allAppointments = res;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error fetching master appointments', err);
        this.isLoading = false;
      }
    });
  }

  //method to cancel the appointment by taking id as parameter
  cancelAppointment(id: number) {
    if (confirm('Are you sure you want to cancel this appointment?')) {
      this.appointmentService.updateStatus(id, 'Cancelled').subscribe({
        next: () => this.loadAllAppointments(),
        error: (err) => alert('Failed to update status')
      });
    }
  }
}
