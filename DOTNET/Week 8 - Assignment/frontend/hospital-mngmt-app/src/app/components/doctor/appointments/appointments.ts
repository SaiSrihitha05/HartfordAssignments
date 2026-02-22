import { Component } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { Doctor } from '../../../services/doctor';
import { FormsModule } from '@angular/forms';
import { inject } from '@angular/core';

@Component({
  selector: 'app-appointments',
  imports: [DatePipe,CommonModule,FormsModule],
  templateUrl: './appointments.html',
  styleUrl: './appointments.css',
})
export class Appointments {
  //variables
  appointments: any[] = [];
  statusOptions = ['Scheduled', 'Completed', 'Cancelled', 'In-Progress'];

  //DI
  private doctorService=inject(Doctor);

  ngOnInit(): void {
      this.loadAppointments();
  }

  //get all appointments of a specific doctor
  loadAppointments() {
    this.doctorService.getMyAppointments().subscribe({
      next: (res) => this.appointments = res,
      error: (err) => console.error('Error fetching appointments', err)
    });
  }

  //update status of an appointment
  onStatusChange(appt: any) {
    this.doctorService.updateAppointmentStatus(appt.id, appt).subscribe({
      next: () => {
        console.log('Update successful');
        alert('Status updated to ' + appt.status); 
      },
      error: (err) => {
        console.error('Update Failed:', err);
        alert('Failed to update status.');
        this.loadAppointments(); // Revert UI
      }
    });
  }
}
