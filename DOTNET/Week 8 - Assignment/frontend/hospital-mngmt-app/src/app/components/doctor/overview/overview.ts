import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Doctor } from '../../../services/doctor';
import { inject } from '@angular/core';

@Component({
  selector: 'app-overview',
  imports: [CommonModule],
  templateUrl: './overview.html',
  styleUrl: './overview.css',
})
export class Overview {
  //variables
  appointments: any[] = [];
  stats = {
    todayAppointments: 0,
    totalPatients: 0,
    pendingActions: 0
  };

  //DI
  private doctorService=inject(Doctor);

  ngOnInit(): void {
    this.loadDoctorData();
  }

  //get doctor stats
  loadDoctorData() {
    this.doctorService.getMyAppointments().subscribe({
      next: (res) => {
        this.appointments = res;
        this.stats.todayAppointments = res.filter((a: any) => a.status === 'Scheduled').length;
        const uniquePatients = new Set(res.map((a: any) => a.patientName));
        this.stats.totalPatients = uniquePatients.size;
        this.stats.pendingActions = res.filter((a: any) => a.status === 'Pending').length;
      },
      error: (err) => console.error('Error fetching doctor stats', err)
    });
  }
}
